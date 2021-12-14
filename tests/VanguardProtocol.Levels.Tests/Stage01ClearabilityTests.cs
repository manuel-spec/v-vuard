using System.Numerics;
using VanguardProtocol.AI;
using VanguardProtocol.Combat;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Levels;
using VanguardProtocol.Levels.Campaign;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels.Tests;

/// <summary>
/// Headless bot run: prove Stage 1 is completable under the same systems the Game host uses.
/// </summary>
public sealed class Stage01ClearabilityTests
{
    private const float MoveSpeed = 160f;
    private const float JumpSpeed = 420f;
    private const float Dt = 1f / 60f;

    [Fact]
    public void Stage01_scripted_run_reaches_exit()
    {
        var level = Stage01ValeOutpost.Build();
        var collision = LevelLoader.LoadCollision(level);
        var world = new World();

        var physics = new PhysicsSystem();
        physics.SetTilemap(collision);
        var projectiles = new ProjectileSystem();
        projectiles.SetTilemap(collision);
        var weapons = new WeaponSystem();
        var contact = new ContactDamageSystem();
        var damage = new DamageSystem();
        var pickups = new PickupSystem();
        var ai = new AiSystem();
        var buffer = new InputBuffer();

        var spawn = level.Spawns.First(s => s.Type.Equals("Player", StringComparison.OrdinalIgnoreCase));
        var player = CreatePlayer(world, new Vector2(spawn.X, spawn.Y));
        SpawnEntities(world, level);

        var exit = level.Triggers.First(t => t.Kind == TriggerKind.LevelExit);
        var prevButtons = InputButtons.None;
        var cleared = false;
        var maxTicks = 60 * 45; // 45 seconds of sim

        for (var tick = 0; tick < maxTicks && !cleared; tick++)
        {
            var buttons = InputButtons.Right | InputButtons.Shoot;
            if (world.TryGet<Transform>(player, out var t) &&
                world.TryGet<RigidBody>(player, out var grounded) &&
                grounded.OnGround)
            {
                // Edge-triggered jump just before each pit.
                if (t.Position.X is >= 320 and < 328 or >= 736 and < 744)
                    buttons |= InputButtons.Jump;
            }

            var frame = InputFrame.FromEdges(prevButtons, buttons);
            prevButtons = buttons;
            buffer.Push(frame.Pressed); // buffer rising edges, not holds

            ApplyPlayerInput(world, player, frame, buffer);
            weapons.SetInput(frame);

            ai.Update(world, Dt);
            physics.Update(world, Dt);
            weapons.Update(world, Dt);
            projectiles.Update(world, Dt);
            contact.Update(world, Dt);
            if (contact.HitsThisTick.Count > 0)
                damage.EnqueueRange(contact.HitsThisTick);
            if (projectiles.DamageThisTick.Count > 0)
                damage.EnqueueRange(projectiles.DamageThisTick);
            damage.Update(world, Dt);
            pickups.Update(world, Dt);

            UpdateFacing(world, player);

            if (!world.TryGet<HealthComponent>(player, out var hp) || hp.Current <= 0)
            {
                Assert.Fail($"Player died at tick {tick} before reaching exit.");
                return;
            }

            if (!world.TryGet<Transform>(player, out var pos) ||
                !world.TryGet<RigidBody>(player, out var body))
            {
                Assert.Fail("Player missing transform/body.");
                return;
            }

            if (pos.Position.Y > level.Height * level.TileSize + 48)
            {
                Assert.Fail($"Fell into a pit at x={pos.Position.X:F1}.");
                return;
            }

            var box = new Aabb(pos.Position.X, pos.Position.Y, body.Size.X, body.Size.Y);
            var zone = new Aabb(exit.X, exit.Y, exit.Width, exit.Height);
            if (box.Intersects(zone))
                cleared = true;
        }

        Assert.True(cleared,
            $"Scripted Stage 1 run failed to reach the EXIT trigger. lastX={GetX(world, player):F1}");
    }

    private static float GetX(World world, Entity player) =>
        world.TryGet<Transform>(player, out var t) ? t.Position.X : -1f;

    private static Entity CreatePlayer(World world, Vector2 position)
    {
        var entity = world.CreateEntity();
        var size = new Vector2(14, 22);
        world.Add(entity, new Transform(position));
        world.Add(entity, new Velocity(Vector2.Zero));
        world.Add(entity, new RigidBody(size));
        world.Add(entity, new PlayerControlled(0));
        world.Add(entity, new HealthComponent(3));
        world.Add(entity, new WeaponComponent { Definition = WeaponDefinition.PulseRifle, Facing = 1 });
        return entity;
    }

    private static void SpawnEntities(World world, LevelData level)
    {
        foreach (var spawn in level.Spawns)
        {
            var type = spawn.Type.ToLowerInvariant();
            if (type == "player")
                continue;

            if (type == "walker")
            {
                var hp = spawn.Properties is not null && spawn.Properties.TryGetValue("hp", out var raw) && int.TryParse(raw, out var v) ? v : 1;
                var left = ParseFloat(spawn, "left", spawn.X - 40);
                var right = ParseFloat(spawn, "right", spawn.X + 40);
                var enemy = world.CreateEntity();
                var size = new Vector2(16, 22);
                world.Add(enemy, new Transform(new Vector2(spawn.X, spawn.Y)));
                world.Add(enemy, new Velocity(Vector2.Zero));
                world.Add(enemy, new RigidBody(size));
                world.Add(enemy, new HealthComponent(Math.Max(1, hp)));
                world.Add(enemy, new EnemyTag { TouchDamage = 1 });
                world.Add(enemy, new AiControlled { Root = WalkerBehavior.Create(45f, left, right) });
            }
            else if (type.StartsWith("pickup_"))
            {
                var pickup = world.CreateEntity();
                world.Add(pickup, new Transform(new Vector2(spawn.X, spawn.Y)));
                world.Add(pickup, new PickupComponent
                {
                    Kind = type.Contains("weapon") ? PickupKind.Weapon : PickupKind.Health,
                    WeaponId = spawn.Properties?.GetValueOrDefault("weapon") ?? "spread_cannon",
                    Amount = 1,
                });
            }
        }
    }

    private static float ParseFloat(EntitySpawn spawn, string key, float fallback) =>
        spawn.Properties is not null && spawn.Properties.TryGetValue(key, out var raw) && float.TryParse(raw, out var v) ? v : fallback;

    private static void ApplyPlayerInput(World world, Entity player, InputFrame frame, InputBuffer buffer)
    {
        if (!world.TryGet<Velocity>(player, out var velocity) || !world.TryGet<RigidBody>(player, out var body))
            return;

        var axis = 0f;
        if (frame.IsDown(InputButtons.Left))
            axis -= 1f;
        if (frame.IsDown(InputButtons.Right))
            axis += 1f;
        velocity.Value.X = DeterministicMath.Quantize(axis * MoveSpeed);

        var wantsJump = frame.WasPressed(InputButtons.Jump) ||
                        buffer.ConsumedPress(InputButtons.Jump, lookbackFrames: 6);
        if (wantsJump && body.OnGround)
        {
            velocity.Value.Y = DeterministicMath.Quantize(-JumpSpeed);
            body.OnGround = false;
            world.GetStore<RigidBody>().Set(player, body);
        }

        world.GetStore<Velocity>().Set(player, velocity);
    }

    private static void UpdateFacing(World world, Entity player)
    {
        if (!world.TryGet<WeaponComponent>(player, out var weapon) || !world.TryGet<Velocity>(player, out var velocity))
            return;
        if (velocity.Value.X > 1f)
            weapon.Facing = 1;
        else if (velocity.Value.X < -1f)
            weapon.Facing = -1;
        world.GetStore<WeaponComponent>().Set(player, weapon);
    }
}
