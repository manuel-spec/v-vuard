using VanguardProtocol.Physics;
using Xunit;

namespace VanguardProtocol.Physics.Tests;

public class DeterminismFixtureTests
{

    [Fact]
    public void FixedMath_Case_000_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(0.000f);
        var b = Fixed.FromFloat(0.000f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_001_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(0.370f);
        var b = Fixed.FromFloat(0.130f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_002_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(0.740f);
        var b = Fixed.FromFloat(0.260f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_003_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(1.110f);
        var b = Fixed.FromFloat(0.390f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_004_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(1.480f);
        var b = Fixed.FromFloat(0.520f);
        var c1 = a * b + Fixed.FromInt(4);
        var c2 = a * b + Fixed.FromInt(4);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_005_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(1.850f);
        var b = Fixed.FromFloat(0.650f);
        var c1 = a * b + Fixed.FromInt(5);
        var c2 = a * b + Fixed.FromInt(5);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_006_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(2.220f);
        var b = Fixed.FromFloat(0.780f);
        var c1 = a * b + Fixed.FromInt(6);
        var c2 = a * b + Fixed.FromInt(6);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_007_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(2.590f);
        var b = Fixed.FromFloat(0.910f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_008_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(2.960f);
        var b = Fixed.FromFloat(1.040f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_009_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(3.330f);
        var b = Fixed.FromFloat(1.170f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_010_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(3.700f);
        var b = Fixed.FromFloat(1.300f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_011_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(4.070f);
        var b = Fixed.FromFloat(1.430f);
        var c1 = a * b + Fixed.FromInt(4);
        var c2 = a * b + Fixed.FromInt(4);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_012_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(4.440f);
        var b = Fixed.FromFloat(1.560f);
        var c1 = a * b + Fixed.FromInt(5);
        var c2 = a * b + Fixed.FromInt(5);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_013_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(4.810f);
        var b = Fixed.FromFloat(1.690f);
        var c1 = a * b + Fixed.FromInt(6);
        var c2 = a * b + Fixed.FromInt(6);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_014_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(5.180f);
        var b = Fixed.FromFloat(1.820f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_015_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(5.550f);
        var b = Fixed.FromFloat(1.950f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_016_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(5.920f);
        var b = Fixed.FromFloat(2.080f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_017_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(6.290f);
        var b = Fixed.FromFloat(2.210f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_018_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(6.660f);
        var b = Fixed.FromFloat(2.340f);
        var c1 = a * b + Fixed.FromInt(4);
        var c2 = a * b + Fixed.FromInt(4);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_019_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(7.030f);
        var b = Fixed.FromFloat(2.470f);
        var c1 = a * b + Fixed.FromInt(5);
        var c2 = a * b + Fixed.FromInt(5);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_020_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(7.400f);
        var b = Fixed.FromFloat(2.600f);
        var c1 = a * b + Fixed.FromInt(6);
        var c2 = a * b + Fixed.FromInt(6);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_021_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(7.770f);
        var b = Fixed.FromFloat(2.730f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_022_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(8.140f);
        var b = Fixed.FromFloat(2.860f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_023_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(8.510f);
        var b = Fixed.FromFloat(2.990f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_024_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(8.880f);
        var b = Fixed.FromFloat(3.120f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_025_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(9.250f);
        var b = Fixed.FromFloat(3.250f);
        var c1 = a * b + Fixed.FromInt(4);
        var c2 = a * b + Fixed.FromInt(4);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_026_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(9.620f);
        var b = Fixed.FromFloat(3.380f);
        var c1 = a * b + Fixed.FromInt(5);
        var c2 = a * b + Fixed.FromInt(5);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_027_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(9.990f);
        var b = Fixed.FromFloat(3.510f);
        var c1 = a * b + Fixed.FromInt(6);
        var c2 = a * b + Fixed.FromInt(6);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_028_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(10.360f);
        var b = Fixed.FromFloat(3.640f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_029_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(10.730f);
        var b = Fixed.FromFloat(3.770f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_030_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(11.100f);
        var b = Fixed.FromFloat(3.900f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_031_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(11.470f);
        var b = Fixed.FromFloat(4.030f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_032_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(11.840f);
        var b = Fixed.FromFloat(4.160f);
        var c1 = a * b + Fixed.FromInt(4);
        var c2 = a * b + Fixed.FromInt(4);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_033_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(12.210f);
        var b = Fixed.FromFloat(4.290f);
        var c1 = a * b + Fixed.FromInt(5);
        var c2 = a * b + Fixed.FromInt(5);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_034_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(12.580f);
        var b = Fixed.FromFloat(4.420f);
        var c1 = a * b + Fixed.FromInt(6);
        var c2 = a * b + Fixed.FromInt(6);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_035_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(12.950f);
        var b = Fixed.FromFloat(4.550f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_036_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(13.320f);
        var b = Fixed.FromFloat(4.680f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_037_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(13.690f);
        var b = Fixed.FromFloat(4.810f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_038_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(14.060f);
        var b = Fixed.FromFloat(4.940f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_039_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(14.430f);
        var b = Fixed.FromFloat(5.070f);
        var c1 = a * b + Fixed.FromInt(4);
        var c2 = a * b + Fixed.FromInt(4);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_040_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(14.800f);
        var b = Fixed.FromFloat(5.200f);
        var c1 = a * b + Fixed.FromInt(5);
        var c2 = a * b + Fixed.FromInt(5);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_041_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(15.170f);
        var b = Fixed.FromFloat(5.330f);
        var c1 = a * b + Fixed.FromInt(6);
        var c2 = a * b + Fixed.FromInt(6);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_042_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(15.540f);
        var b = Fixed.FromFloat(5.460f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_043_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(15.910f);
        var b = Fixed.FromFloat(5.590f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_044_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(16.280f);
        var b = Fixed.FromFloat(5.720f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_045_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(16.650f);
        var b = Fixed.FromFloat(5.850f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_046_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(17.020f);
        var b = Fixed.FromFloat(5.980f);
        var c1 = a * b + Fixed.FromInt(4);
        var c2 = a * b + Fixed.FromInt(4);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_047_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(17.390f);
        var b = Fixed.FromFloat(6.110f);
        var c1 = a * b + Fixed.FromInt(5);
        var c2 = a * b + Fixed.FromInt(5);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_048_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(17.760f);
        var b = Fixed.FromFloat(6.240f);
        var c1 = a * b + Fixed.FromInt(6);
        var c2 = a * b + Fixed.FromInt(6);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_049_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(18.130f);
        var b = Fixed.FromFloat(6.370f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_050_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(18.500f);
        var b = Fixed.FromFloat(6.500f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_051_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(18.870f);
        var b = Fixed.FromFloat(6.630f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_052_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(19.240f);
        var b = Fixed.FromFloat(6.760f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_053_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(19.610f);
        var b = Fixed.FromFloat(6.890f);
        var c1 = a * b + Fixed.FromInt(4);
        var c2 = a * b + Fixed.FromInt(4);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_054_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(19.980f);
        var b = Fixed.FromFloat(7.020f);
        var c1 = a * b + Fixed.FromInt(5);
        var c2 = a * b + Fixed.FromInt(5);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_055_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(20.350f);
        var b = Fixed.FromFloat(7.150f);
        var c1 = a * b + Fixed.FromInt(6);
        var c2 = a * b + Fixed.FromInt(6);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_056_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(20.720f);
        var b = Fixed.FromFloat(7.280f);
        var c1 = a * b + Fixed.FromInt(0);
        var c2 = a * b + Fixed.FromInt(0);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_057_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(21.090f);
        var b = Fixed.FromFloat(7.410f);
        var c1 = a * b + Fixed.FromInt(1);
        var c2 = a * b + Fixed.FromInt(1);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_058_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(21.460f);
        var b = Fixed.FromFloat(7.540f);
        var c1 = a * b + Fixed.FromInt(2);
        var c2 = a * b + Fixed.FromInt(2);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }

    [Fact]
    public void FixedMath_Case_059_Is_Bit_Identical()
    {
        var a = Fixed.FromFloat(21.830f);
        var b = Fixed.FromFloat(7.670f);
        var c1 = a * b + Fixed.FromInt(3);
        var c2 = a * b + Fixed.FromInt(3);
        Assert.Equal(c1.Raw, c2.Raw);
        Assert.Equal(DeterministicMath.Quantize(c1.ToFloat()), DeterministicMath.Quantize(c2.ToFloat()));
    }
}
