using System.Numerics;
using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Physics;

/// <summary>16.16 signed fixed-point — bit-identical across machines for lockstep.</summary>
public readonly struct Fixed : IEquatable<Fixed>, IComparable<Fixed>
{
    public const int Shift = 16;
    public const int OneRaw = 1 << Shift;
    public static readonly Fixed Zero = new(0);
    public static readonly Fixed One = new(OneRaw);

    public Fixed(int raw) => Raw = raw;

    public int Raw { get; }

    public static Fixed FromInt(int value) => new(value * OneRaw);

    public static Fixed FromFloat(float value) => new((int)MathF.Round(value * OneRaw));

    public float ToFloat() => Raw / (float)OneRaw;

    public int ToIntFloor() => Raw >> Shift;

    public static Fixed operator +(Fixed a, Fixed b) => new(a.Raw + b.Raw);
    public static Fixed operator -(Fixed a, Fixed b) => new(a.Raw - b.Raw);
    public static Fixed operator -(Fixed a) => new(-a.Raw);

    public static Fixed operator *(Fixed a, Fixed b) =>
        new((int)((long)a.Raw * b.Raw >> Shift));

    public static Fixed operator /(Fixed a, Fixed b)
    {
        if (b.Raw == 0)
            throw new DivideByZeroException();
        return new((int)(((long)a.Raw << Shift) / b.Raw));
    }

    public static bool operator <(Fixed a, Fixed b) => a.Raw < b.Raw;
    public static bool operator >(Fixed a, Fixed b) => a.Raw > b.Raw;
    public static bool operator <=(Fixed a, Fixed b) => a.Raw <= b.Raw;
    public static bool operator >=(Fixed a, Fixed b) => a.Raw >= b.Raw;
    public static bool operator ==(Fixed a, Fixed b) => a.Raw == b.Raw;
    public static bool operator !=(Fixed a, Fixed b) => a.Raw != b.Raw;

    public static Fixed Min(Fixed a, Fixed b) => a.Raw <= b.Raw ? a : b;
    public static Fixed Max(Fixed a, Fixed b) => a.Raw >= b.Raw ? a : b;
    public static Fixed Abs(Fixed a) => a.Raw < 0 ? -a : a;

    public int CompareTo(Fixed other) => Raw.CompareTo(other.Raw);
    public bool Equals(Fixed other) => Raw == other.Raw;
    public override bool Equals(object? obj) => obj is Fixed other && Equals(other);
    public override int GetHashCode() => Raw;
    public override string ToString() => ToFloat().ToString("0.###");
}

public static class DeterministicMath
{
    public static Vector2 Quantize(Vector2 value) =>
        new(Fixed.FromFloat(value.X).ToFloat(), Fixed.FromFloat(value.Y).ToFloat());

    public static float Quantize(float value) => Fixed.FromFloat(value).ToFloat();

    public static Vector2 Add(Vector2 a, Vector2 b) => Quantize(a + b);

    public static Vector2 Scale(Vector2 v, float scalar) => Quantize(v * scalar);

    public static int Sign(float value) => value > 0f ? 1 : value < 0f ? -1 : 0;
}
