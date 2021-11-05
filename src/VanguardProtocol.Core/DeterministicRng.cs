namespace VanguardProtocol.Core;

/// <summary>
/// Deterministic xorshift64* PRNG for lockstep-safe gameplay randomness.
/// Same seed + same call sequence => identical results on every peer.
/// </summary>
public struct DeterministicRng
{
    private ulong _state;

    public DeterministicRng(ulong seed)
    {
        _state = seed == 0 ? 0xA5A5A5A5A5A5A5A5UL : seed;
    }

    public ulong State => _state;

    public ulong NextUInt64()
    {
        var x = _state;
        x ^= x >> 12;
        x ^= x << 25;
        x ^= x >> 27;
        _state = x;
        return unchecked(x * 0x2545F4914F6CDD1DUL);
    }

    public uint NextUInt32() => (uint)(NextUInt64() >> 32);

    public int NextInt(int minInclusive, int maxExclusive)
    {
        if (maxExclusive <= minInclusive)
            throw new ArgumentOutOfRangeException(nameof(maxExclusive));
        var range = (uint)(maxExclusive - minInclusive);
        return minInclusive + (int)(NextUInt32() % range);
    }

    public float NextFloat01()
    {
        // 24 bits of mantissa precision, quantized for cross-platform stability.
        var bits = NextUInt32() & 0x00FFFFFF;
        return bits / 16777216f;
    }

    public bool NextBool() => (NextUInt32() & 1u) == 1u;

    public void Shuffle<T>(IList<T> items)
    {
        for (var i = items.Count - 1; i > 0; i--)
        {
            var j = NextInt(0, i + 1);
            (items[i], items[j]) = (items[j], items[i]);
        }
    }

    public DeterministicRng Fork(ulong salt)
    {
        var mixed = _state ^ (salt * 0x9E3779B97F4A7C15UL);
        return new DeterministicRng(mixed == 0 ? 1UL : mixed);
    }
}
