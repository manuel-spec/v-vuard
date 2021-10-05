namespace VanguardProtocol.Core.Ecs;

/// <summary>
/// Stable entity handle. Index addresses sparse storage; Generation detects reuse after destroy.
/// </summary>
public readonly struct Entity : IEquatable<Entity>
{
    public static readonly Entity None = new(0, 0);

    public Entity(uint index, uint generation)
    {
        Index = index;
        Generation = generation;
    }

    public uint Index { get; }
    public uint Generation { get; }
    public bool IsNone => Index == 0 && Generation == 0;

    public bool Equals(Entity other) => Index == other.Index && Generation == other.Generation;
    public override bool Equals(object? obj) => obj is Entity other && Equals(other);
    public override int GetHashCode() => HashCode.Combine(Index, Generation);
    public static bool operator ==(Entity left, Entity right) => left.Equals(right);
    public static bool operator !=(Entity left, Entity right) => !left.Equals(right);
    public override string ToString() => IsNone ? "Entity.None" : $"Entity({Index}:{Generation})";
}
