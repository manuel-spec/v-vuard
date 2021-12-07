using VanguardProtocol.Core;
using Xunit;

namespace VanguardProtocol.Core.Tests;

public class DeterministicRngFixtureTests
{

    [Fact]
    public void Rng_Sequence_000_Is_Stable()
    {
        var rng = new DeterministicRng(1000UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1000UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_001_Is_Stable()
    {
        var rng = new DeterministicRng(1001UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1001UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_002_Is_Stable()
    {
        var rng = new DeterministicRng(1002UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1002UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_003_Is_Stable()
    {
        var rng = new DeterministicRng(1003UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1003UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_004_Is_Stable()
    {
        var rng = new DeterministicRng(1004UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1004UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_005_Is_Stable()
    {
        var rng = new DeterministicRng(1005UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1005UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_006_Is_Stable()
    {
        var rng = new DeterministicRng(1006UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1006UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_007_Is_Stable()
    {
        var rng = new DeterministicRng(1007UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1007UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_008_Is_Stable()
    {
        var rng = new DeterministicRng(1008UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1008UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_009_Is_Stable()
    {
        var rng = new DeterministicRng(1009UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1009UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_010_Is_Stable()
    {
        var rng = new DeterministicRng(1010UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1010UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_011_Is_Stable()
    {
        var rng = new DeterministicRng(1011UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1011UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_012_Is_Stable()
    {
        var rng = new DeterministicRng(1012UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1012UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_013_Is_Stable()
    {
        var rng = new DeterministicRng(1013UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1013UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_014_Is_Stable()
    {
        var rng = new DeterministicRng(1014UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1014UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_015_Is_Stable()
    {
        var rng = new DeterministicRng(1015UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1015UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_016_Is_Stable()
    {
        var rng = new DeterministicRng(1016UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1016UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_017_Is_Stable()
    {
        var rng = new DeterministicRng(1017UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1017UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_018_Is_Stable()
    {
        var rng = new DeterministicRng(1018UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1018UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_019_Is_Stable()
    {
        var rng = new DeterministicRng(1019UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1019UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_020_Is_Stable()
    {
        var rng = new DeterministicRng(1020UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1020UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_021_Is_Stable()
    {
        var rng = new DeterministicRng(1021UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1021UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_022_Is_Stable()
    {
        var rng = new DeterministicRng(1022UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1022UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_023_Is_Stable()
    {
        var rng = new DeterministicRng(1023UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1023UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_024_Is_Stable()
    {
        var rng = new DeterministicRng(1024UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1024UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_025_Is_Stable()
    {
        var rng = new DeterministicRng(1025UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1025UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_026_Is_Stable()
    {
        var rng = new DeterministicRng(1026UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1026UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_027_Is_Stable()
    {
        var rng = new DeterministicRng(1027UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1027UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_028_Is_Stable()
    {
        var rng = new DeterministicRng(1028UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1028UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_029_Is_Stable()
    {
        var rng = new DeterministicRng(1029UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1029UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_030_Is_Stable()
    {
        var rng = new DeterministicRng(1030UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1030UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_031_Is_Stable()
    {
        var rng = new DeterministicRng(1031UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1031UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_032_Is_Stable()
    {
        var rng = new DeterministicRng(1032UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1032UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_033_Is_Stable()
    {
        var rng = new DeterministicRng(1033UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1033UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_034_Is_Stable()
    {
        var rng = new DeterministicRng(1034UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1034UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_035_Is_Stable()
    {
        var rng = new DeterministicRng(1035UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1035UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_036_Is_Stable()
    {
        var rng = new DeterministicRng(1036UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1036UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_037_Is_Stable()
    {
        var rng = new DeterministicRng(1037UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1037UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_038_Is_Stable()
    {
        var rng = new DeterministicRng(1038UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1038UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }

    [Fact]
    public void Rng_Sequence_039_Is_Stable()
    {
        var rng = new DeterministicRng(1039UL);
        Span<uint> a = stackalloc uint[32];
        for (var n = 0; n < a.Length; n++) a[n] = rng.NextUInt32();
        var rng2 = new DeterministicRng(1039UL);
        for (var n = 0; n < a.Length; n++)
            Assert.Equal(a[n], rng2.NextUInt32());
    }
}
