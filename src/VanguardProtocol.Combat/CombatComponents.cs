using System.Numerics;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Combat;

public sealed class WeaponDefinition
{
    public required string Id { get; init; }
    public float FireIntervalSeconds { get; init; } = 0.18f;
    public float ProjectileSpeed { get; init; } = 320f;
    public int Damage { get; init; } = 1;
    public int ProjectileCount { get; init; } = 1;
    public float SpreadDegrees { get; init; }
    public float ProjectileLifetime { get; init; } = 4f;
    public float LifetimeSeconds { get; init; } = 1.5f;
    public uint ColorRgba { get; init; } = 0xFFFFE080;

    public static WeaponDefinition PulseRifle { get; } = new()
    {
        Id = "pulse_rifle",
        FireIntervalSeconds = 0.16f,
        ProjectileSpeed = 360f,
        Damage = 1,
        ColorRgba = 0xFFE8F0FF,
    };

    public static WeaponDefinition SpreadCannon { get; } = new()
    {
        Id = "spread_cannon",
        FireIntervalSeconds = 0.28f,
        ProjectileSpeed = 300f,
        Damage = 1,
        ProjectileCount = 3,
        SpreadDegrees = 18f,
        ColorRgba = 0xFFFFB060,
    };

    public static WeaponDefinition NeedleGun { get; } = new()
    {
        Id = "needle_gun",
        FireIntervalSeconds = 0.08f,
        ProjectileSpeed = 420f,
        Damage = 1,
        ProjectileLifetime = 3f,
        ColorRgba = 0xFF80FFD0,
    };
}

public struct WeaponComponent : IComponent
{
    public WeaponDefinition? Definition;
    public float Cooldown;
    public int Facing; // -1 or 1
}

public struct ProjectileComponent : IComponent
{
    public int Damage;
    public float Lifetime;
    public CollisionLayer OwnerLayer;
}

public struct HealthComponent : IComponent
{
    public int Current;
    public int Max;

    public HealthComponent(int max)
    {
        Max = max;
        Current = max;
    }
}

public readonly struct DamageEvent
{
    public DamageEvent(Entity target, Entity source, int amount)
    {
        Target = target;
        Source = source;
        Amount = amount;
    }

    public Entity Target { get; }
    public Entity Source { get; }
    public int Amount { get; }
}

public enum PickupKind : byte
{
    Weapon = 0,
    Health = 1,
    ExtraLife = 2,
    Score = 3,
}

public struct PickupComponent : IComponent
{
    public PickupKind Kind;
    public string? WeaponId;
    public int Amount;
}
