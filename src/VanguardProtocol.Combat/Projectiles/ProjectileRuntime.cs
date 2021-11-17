using System.Numerics;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Combat.Projectiles;

public struct ProjectileMotion : IComponent
{
    public Vector2 Velocity;
    public float HomingStrength;
    public int PierceRemaining;
    public bool BounceOffTiles;
}

public struct ProjectileOwner : IComponent
{
    public Entity Owner;
    public int OwnerPlayerIndex;
}

public sealed class ProjectilePool
{
    public int SpawnedTotal { get; private set; }

    public Entity Rent(World world)
    {
        SpawnedTotal++;
        return world.CreateEntity();
    }

    public void Despawn(World world, Entity entity)
    {
        if (world.IsAlive(entity))
            world.DestroyEntity(entity);
    }
}

public static class ProjectileSpawner
{
    public static Entity Spawn(
        World world,
        ProjectilePool pool,
        Vector2 position,
        Vector2 velocity,
        WeaponDefinition def,
        CollisionLayer ownerLayer,
        Entity owner)
    {
        var e = pool.Rent(world);
        world.Add(e, new Transform(position));
        world.Add(e, new Velocity(DeterministicMath.Quantize(velocity)));
        world.Add(e, new ProjectileComponent
        {
            Damage = def.Damage,
            Lifetime = def.LifetimeSeconds,
            OwnerLayer = ownerLayer,
        });
        world.Add(e, new ProjectileMotion
        {
            Velocity = DeterministicMath.Quantize(velocity),
        });
        world.Add(e, new ProjectileOwner { Owner = owner, OwnerPlayerIndex = -1 });
        var diameter = def.ProjectileRadius * 2f;
        world.Add(e, new ColliderComponent
        {
            Size = new Vector2(diameter, diameter),
            Offset = new Vector2(-def.ProjectileRadius, -def.ProjectileRadius),
            Layer = CollisionLayer.Projectile,
            Mask = CollisionLayer.Enemy | CollisionLayer.Solid,
        });
        return e;
    }
}

public static class ShotPatternLibrary
{
    public static IReadOnlyList<(float Ang, float Spd)> Resolve(int patternIndex, int countHint = 0)
    {
        var list = new List<(float, float)>();
        var count = countHint > 0 ? countHint : 1 + (patternIndex % 7);
        var spread = 6f * (patternIndex % 8);
        if (patternIndex % 5 == 0)
        {
            for (var i = 0; i < count; i++)
                list.Add((360f * i / count, 1f));
        }
        else
        {
            var start = -spread * 0.5f;
            var step = count == 1 ? 0f : spread / (count - 1);
            for (var i = 0; i < count; i++)
                list.Add((start + step * i, 1f + (i % 3) * 0.05f));
        }

        return list;
    }
}
