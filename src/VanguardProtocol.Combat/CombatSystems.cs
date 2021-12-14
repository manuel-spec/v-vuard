using System.Numerics;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Combat;

public sealed class WeaponSystem : SystemBase
{
    private InputFrame _input;
    private readonly List<(Entity Owner, Vector2 Origin, float Angle)> _pending = new();

    public override int Order => SystemOrders.Combat;

    public void SetInput(InputFrame input) => _input = input;

    public override void Update(World world, float fixedDeltaSeconds)
    {
        _pending.Clear();
        var weapons = world.GetStore<WeaponComponent>();
        var transforms = world.GetStore<Transform>();
        var players = world.GetStore<PlayerControlled>();

        foreach (var (entity, weapon) in weapons)
        {
            var copy = weapon;
            if (copy.Definition is null)
                continue;

            copy.Cooldown = Math.Max(0f, copy.Cooldown - fixedDeltaSeconds);

            var isPlayer = players.Has(entity);
            var wantsFire = isPlayer && _input.IsDown(InputButtons.Shoot);

            if (wantsFire && copy.Cooldown <= 0f)
            {
                copy.Cooldown = copy.Definition.FireIntervalSeconds;
                if (transforms.TryGet(entity, out var transform))
                {
                    var origin = transform.Position + new Vector2(
                        copy.Facing >= 0 ? 14f : -2f,
                        8f);
                    var def = copy.Definition;
                    var baseAngle = copy.Facing >= 0 ? 0f : MathF.PI;
                    if (def.ProjectileCount <= 1)
                    {
                        _pending.Add((entity, origin, baseAngle));
                    }
                    else
                    {
                        var spread = def.SpreadDegrees * (MathF.PI / 180f);
                        var start = baseAngle - spread * 0.5f;
                        var step = spread / (def.ProjectileCount - 1);
                        for (var i = 0; i < def.ProjectileCount; i++)
                            _pending.Add((entity, origin, start + step * i));
                    }
                }
            }

            weapons.Set(entity, copy);
        }

        foreach (var (owner, origin, angle) in _pending)
        {
            if (!weapons.TryGet(owner, out var weapon) || weapon.Definition is null)
                continue;

            SpawnProjectile(world, owner, origin, angle, weapon.Definition);
        }
    }

    public static Entity SpawnProjectile(World world, Entity owner, Vector2 origin, float angle, WeaponDefinition def)
    {
        var projectile = world.CreateEntity();
        var dir = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
        var speed = DeterministicMath.Quantize(def.ProjectileSpeed);
        world.Add(projectile, new Transform(DeterministicMath.Quantize(origin)));
        world.Add(projectile, new Velocity(DeterministicMath.Quantize(dir * speed)));
        world.Add(projectile, new ProjectileComponent
        {
            Damage = def.Damage,
            Lifetime = def.LifetimeSeconds,
            OwnerLayer = CollisionLayer.Player,
            Owner = owner,
        });
        world.Add(projectile, new DrawableRect(6, 3, def.ColorRgba));
        return projectile;
    }
}

public sealed class ProjectileSystem : SystemBase
{
    private CollisionTilemap? _tilemap;
    private readonly List<Entity> _toDestroy = new();
    private readonly List<DamageEvent> _damage = new();

    public override int Order => SystemOrders.Combat + 10;
    public IReadOnlyList<DamageEvent> DamageThisTick => _damage;

    public void SetTilemap(CollisionTilemap? tilemap) => _tilemap = tilemap;

    public override void Update(World world, float fixedDeltaSeconds)
    {
        _toDestroy.Clear();
        _damage.Clear();

        var projectiles = world.GetStore<ProjectileComponent>();
        var transforms = world.GetStore<Transform>();
        var velocities = world.GetStore<Velocity>();
        var healths = world.GetStore<HealthComponent>();

        foreach (var (entity, projectile) in projectiles)
        {
            var copy = projectile;
            copy.Lifetime -= fixedDeltaSeconds;
            if (copy.Lifetime <= 0f)
            {
                _toDestroy.Add(entity);
                continue;
            }

            if (!transforms.Has(entity) || !velocities.Has(entity))
            {
                projectiles.Set(entity, copy);
                continue;
            }

            ref var transform = ref transforms.Get(entity);
            ref var velocity = ref velocities.Get(entity);
            var delta = DeterministicMath.Scale(velocity.Value, fixedDeltaSeconds);
            transform.Position = DeterministicMath.Add(transform.Position, delta);

            if (_tilemap is not null)
            {
                var bounds = new Aabb(transform.Position.X, transform.Position.Y, 6, 3);
                var tx = (int)(bounds.Center.X / _tilemap.TileSize);
                var ty = (int)(bounds.Center.Y / _tilemap.TileSize);
                var flags = _tilemap.Get(tx, ty);
                if ((flags & TileFlags.Solid) != 0)
                {
                    _toDestroy.Add(entity);
                    projectiles.Set(entity, copy);
                    continue;
                }
            }

            // Hit hostile health entities only — never the owner or other players.
            foreach (var (target, _) in healths)
            {
                if (target == entity || target == copy.Owner)
                    continue;
                if (world.Has<PlayerControlled>(target) && copy.OwnerLayer == CollisionLayer.Player)
                    continue;
                if (!transforms.TryGet(target, out var targetTransform))
                    continue;
                if (!world.TryGet<RigidBody>(target, out var body))
                    continue;

                var targetBounds = new Aabb(targetTransform.Position.X, targetTransform.Position.Y, body.Size.X, body.Size.Y);
                var projBounds = new Aabb(transform.Position.X, transform.Position.Y, 6, 3);
                if (projBounds.Intersects(targetBounds))
                {
                    _damage.Add(new DamageEvent(target, entity, copy.Damage));
                    _toDestroy.Add(entity);
                    break;
                }
            }

            projectiles.Set(entity, copy);
        }

        for (var i = 0; i < _toDestroy.Count; i++)
            world.DestroyEntity(_toDestroy[i]);
    }
}

public struct InvulnFrames : IComponent
{
    public float Remaining;
}

public struct EnemyTag : IComponent
{
    public int TouchDamage;
}

public sealed class DamageSystem : SystemBase
{
    private readonly List<DamageEvent> _queue = new();
    private readonly List<Entity> _dead = new();

    public override int Order => SystemOrders.Combat + 20;
    public IReadOnlyList<Entity> DiedThisTick => _dead;

    public void Enqueue(DamageEvent evt) => _queue.Add(evt);

    public void EnqueueRange(IEnumerable<DamageEvent> events) => _queue.AddRange(events);

    public override void Update(World world, float fixedDeltaSeconds)
    {
        _dead.Clear();

        var invuln = world.GetStore<InvulnFrames>();
        var invulnEntities = invuln.EntitiesSpan().ToArray();
        var invulnFrames = invuln.AsSpan().ToArray();
        for (var i = 0; i < invulnEntities.Length; i++)
        {
            var entity = invulnEntities[i];
            var next = invulnFrames[i].Remaining - fixedDeltaSeconds;
            if (next <= 0f)
                invuln.Remove(entity);
            else
                invuln.Set(entity, new InvulnFrames { Remaining = next });
        }

        var healths = world.GetStore<HealthComponent>();
        for (var i = 0; i < _queue.Count; i++)
        {
            var evt = _queue[i];
            if (!healths.TryGet(evt.Target, out var health))
                continue;
            if (world.Has<InvulnFrames>(evt.Target))
                continue;

            health.Current = Math.Max(0, health.Current - evt.Amount);
            healths.Set(evt.Target, health);
            if (world.Has<PlayerControlled>(evt.Target))
                world.Add(evt.Target, new InvulnFrames { Remaining = 1.0f });

            if (health.Current == 0)
                _dead.Add(evt.Target);
        }

        _queue.Clear();

        for (var i = 0; i < _dead.Count; i++)
        {
            if (!world.Has<PlayerControlled>(_dead[i]))
                world.DestroyEntity(_dead[i]);
        }
    }
}

/// <summary>Player takes contact damage from tagged enemies.</summary>
public sealed class ContactDamageSystem : SystemBase
{
    private readonly List<DamageEvent> _hits = new();

    public override int Order => SystemOrders.Combat + 15;
    public IReadOnlyList<DamageEvent> HitsThisTick => _hits;

    public override void Update(World world, float fixedDeltaSeconds)
    {
        _hits.Clear();
        var players = world.GetStore<PlayerControlled>();
        var enemies = world.GetStore<EnemyTag>();
        var transforms = world.GetStore<Transform>();

        foreach (var (player, _) in players)
        {
            if (!transforms.TryGet(player, out var pt) || !world.TryGet<RigidBody>(player, out var pb))
                continue;
            if (world.Has<InvulnFrames>(player))
                continue;

            var playerBox = new Aabb(pt.Position.X, pt.Position.Y, pb.Size.X, pb.Size.Y);
            foreach (var (enemy, tag) in enemies)
            {
                if (!transforms.TryGet(enemy, out var et) || !world.TryGet<RigidBody>(enemy, out var eb))
                    continue;
                var enemyBox = new Aabb(et.Position.X, et.Position.Y, eb.Size.X, eb.Size.Y);
                if (!playerBox.Intersects(enemyBox))
                    continue;
                _hits.Add(new DamageEvent(player, enemy, Math.Max(1, tag.TouchDamage)));
                break;
            }
        }
    }
}

public sealed class PickupSystem : SystemBase
{
    public override int Order => SystemOrders.Combat + 30;

    public override void Update(World world, float fixedDeltaSeconds)
    {
        var pickups = world.GetStore<PickupComponent>();
        var transforms = world.GetStore<Transform>();
        var players = world.GetStore<PlayerControlled>();
        var toRemove = new List<Entity>();

        foreach (var (pickupEntity, pickup) in pickups)
        {
            if (!transforms.TryGet(pickupEntity, out var pickupTransform))
                continue;

            var pickupBounds = new Aabb(pickupTransform.Position.X, pickupTransform.Position.Y, 12, 12);

            foreach (var (playerEntity, _) in players)
            {
                if (!transforms.TryGet(playerEntity, out var playerTransform))
                    continue;
                if (!world.TryGet<RigidBody>(playerEntity, out var body))
                    continue;

                var playerBounds = new Aabb(playerTransform.Position.X, playerTransform.Position.Y, body.Size.X, body.Size.Y);
                if (!playerBounds.Intersects(pickupBounds))
                    continue;

                ApplyPickup(world, playerEntity, pickup);
                toRemove.Add(pickupEntity);
                break;
            }
        }

        for (var i = 0; i < toRemove.Count; i++)
            world.DestroyEntity(toRemove[i]);
    }

    private static void ApplyPickup(World world, Entity player, PickupComponent pickup)
    {
        switch (pickup.Kind)
        {
            case PickupKind.Health when world.TryGet<HealthComponent>(player, out var health):
                health.Current = Math.Min(health.Max, health.Current + Math.Max(1, pickup.Amount));
                world.GetStore<HealthComponent>().Set(player, health);
                break;
            case PickupKind.Weapon when world.TryGet<WeaponComponent>(player, out var weapon):
                weapon.Definition = ResolveWeapon(pickup.WeaponId);
                world.GetStore<WeaponComponent>().Set(player, weapon);
                break;
        }
    }

    private static WeaponDefinition ResolveWeapon(string? id) => id switch
    {
        "spread_cannon" => WeaponDefinition.SpreadCannon,
        "needle_gun" => WeaponDefinition.NeedleGun,
        _ => WeaponDefinition.PulseRifle,
    };
}
