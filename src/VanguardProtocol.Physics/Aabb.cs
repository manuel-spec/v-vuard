using System.Numerics;

namespace VanguardProtocol.Physics;

public readonly struct Aabb : IEquatable<Aabb>
{
    public Aabb(Vector2 min, Vector2 max)
    {
        Min = min;
        Max = max;
    }

    public Aabb(float x, float y, float width, float height)
    {
        Min = new Vector2(x, y);
        Max = new Vector2(x + width, y + height);
    }

    public Vector2 Min { get; }
    public Vector2 Max { get; }
    public Vector2 Center => (Min + Max) * 0.5f;
    public Vector2 Size => Max - Min;
    public float Width => Max.X - Min.X;
    public float Height => Max.Y - Min.Y;

    public static Aabb FromCenter(Vector2 center, Vector2 size)
    {
        var half = size * 0.5f;
        return new Aabb(center - half, center + half);
    }

    public Aabb Translated(Vector2 delta) => new(Min + delta, Max + delta);

    public bool Intersects(Aabb other) =>
        Min.X < other.Max.X && Max.X > other.Min.X &&
        Min.Y < other.Max.Y && Max.Y > other.Min.Y;

    public bool Contains(Vector2 point) =>
        point.X >= Min.X && point.X <= Max.X &&
        point.Y >= Min.Y && point.Y <= Max.Y;

    public bool Equals(Aabb other) => Min == other.Min && Max == other.Max;
    public override bool Equals(object? obj) => obj is Aabb other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(Min, Max);
}

[Flags]
public enum CollisionLayer : uint
{
    None = 0,
    Solid = 1 << 0,
    OneWay = 1 << 1,
    Slope = 1 << 2,
    Hazard = 1 << 3,
    Player = 1 << 4,
    Enemy = 1 << 5,
    Projectile = 1 << 6,
}

public enum CollisionShapeKind : byte
{
    Aabb = 0,
    Slope = 1,
}

public struct ColliderComponent : VanguardProtocol.Core.Ecs.IComponent
{
    public Vector2 Size;
    public Vector2 Offset;
    public CollisionLayer Layer;
    public CollisionLayer Mask;
    public CollisionShapeKind Shape;
    /// <summary>For slopes: rise over run in tile space (e.g. 1 = 45°).</summary>
    public float SlopeRise;
    public bool IsTrigger;

    public Aabb WorldBounds(Vector2 position) =>
        new(position + Offset, position + Offset + Size);
}
