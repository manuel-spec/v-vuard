using System.Numerics;
using VanguardProtocol.Physics;
using Xunit;

namespace VanguardProtocol.Physics.Tests;

public class SpatialHashFixtureTests
{

    [Fact]
    public void SpatialHash_Case_000()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(0, 0), new Vector2(10, 10)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(2, 2), new Vector2(8, 8)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_001()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(1, 1), new Vector2(11, 11)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(3, 3), new Vector2(9, 9)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_002()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(2, 2), new Vector2(12, 12)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(4, 4), new Vector2(10, 10)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_003()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(3, 3), new Vector2(13, 13)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(5, 5), new Vector2(11, 11)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_004()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(4, 4), new Vector2(14, 14)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(6, 6), new Vector2(12, 12)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_005()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(5, 5), new Vector2(15, 15)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(7, 7), new Vector2(13, 13)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_006()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(6, 6), new Vector2(16, 16)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(8, 8), new Vector2(14, 14)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_007()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(7, 0), new Vector2(17, 10)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(9, 2), new Vector2(15, 8)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_008()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(8, 1), new Vector2(18, 11)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(10, 3), new Vector2(16, 9)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_009()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(9, 2), new Vector2(19, 12)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(11, 4), new Vector2(17, 10)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_010()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(10, 3), new Vector2(20, 13)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(12, 5), new Vector2(18, 11)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_011()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(11, 4), new Vector2(21, 14)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(13, 6), new Vector2(19, 12)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_012()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(12, 5), new Vector2(22, 15)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(14, 7), new Vector2(20, 13)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_013()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(13, 6), new Vector2(23, 16)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(15, 8), new Vector2(21, 14)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_014()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(14, 0), new Vector2(24, 10)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(16, 2), new Vector2(22, 8)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_015()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(15, 1), new Vector2(25, 11)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(17, 3), new Vector2(23, 9)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_016()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(16, 2), new Vector2(26, 12)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(18, 4), new Vector2(24, 10)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_017()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(17, 3), new Vector2(27, 13)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(19, 5), new Vector2(25, 11)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_018()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(18, 4), new Vector2(28, 14)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(20, 6), new Vector2(26, 12)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_019()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(19, 5), new Vector2(29, 15)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(21, 7), new Vector2(27, 13)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_020()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(20, 6), new Vector2(30, 16)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(22, 8), new Vector2(28, 14)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_021()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(21, 0), new Vector2(31, 10)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(23, 2), new Vector2(29, 8)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_022()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(22, 1), new Vector2(32, 11)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(24, 3), new Vector2(30, 9)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_023()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(23, 2), new Vector2(33, 12)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(25, 4), new Vector2(31, 10)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_024()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(24, 3), new Vector2(34, 13)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(26, 5), new Vector2(32, 11)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_025()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(25, 4), new Vector2(35, 14)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(27, 6), new Vector2(33, 12)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_026()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(26, 5), new Vector2(36, 15)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(28, 7), new Vector2(34, 13)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_027()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(27, 6), new Vector2(37, 16)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(29, 8), new Vector2(35, 14)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_028()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(28, 0), new Vector2(38, 10)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(30, 2), new Vector2(36, 8)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_029()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(29, 1), new Vector2(39, 11)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(31, 3), new Vector2(37, 9)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_030()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(30, 2), new Vector2(40, 12)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(32, 4), new Vector2(38, 10)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_031()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(31, 3), new Vector2(41, 13)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(33, 5), new Vector2(39, 11)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_032()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(32, 4), new Vector2(42, 14)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(34, 6), new Vector2(40, 12)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_033()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(33, 5), new Vector2(43, 15)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(35, 7), new Vector2(41, 13)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_034()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(34, 6), new Vector2(44, 16)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(36, 8), new Vector2(42, 14)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_035()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(35, 0), new Vector2(45, 10)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(37, 2), new Vector2(43, 8)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_036()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(36, 1), new Vector2(46, 11)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(38, 3), new Vector2(44, 9)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_037()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(37, 2), new Vector2(47, 12)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(39, 4), new Vector2(45, 10)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_038()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(38, 3), new Vector2(48, 13)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(40, 5), new Vector2(46, 11)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_039()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(39, 4), new Vector2(49, 14)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(41, 6), new Vector2(47, 12)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_040()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(40, 5), new Vector2(50, 15)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(42, 7), new Vector2(48, 13)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_041()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(41, 6), new Vector2(51, 16)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(43, 8), new Vector2(49, 14)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_042()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(42, 0), new Vector2(52, 10)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(44, 2), new Vector2(50, 8)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_043()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(43, 1), new Vector2(53, 11)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(45, 3), new Vector2(51, 9)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_044()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(44, 2), new Vector2(54, 12)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(46, 4), new Vector2(52, 10)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_045()
    {
        var hash = new SpatialHash(16f);
        var id = hash.Insert(new Aabb(new Vector2(45, 3), new Vector2(55, 13)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(47, 5), new Vector2(53, 11)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_046()
    {
        var hash = new SpatialHash(24f);
        var id = hash.Insert(new Aabb(new Vector2(46, 4), new Vector2(56, 14)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(48, 6), new Vector2(54, 12)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_047()
    {
        var hash = new SpatialHash(32f);
        var id = hash.Insert(new Aabb(new Vector2(47, 5), new Vector2(57, 15)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(49, 7), new Vector2(55, 13)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_048()
    {
        var hash = new SpatialHash(40f);
        var id = hash.Insert(new Aabb(new Vector2(48, 6), new Vector2(58, 16)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(50, 8), new Vector2(56, 14)), hits);
        Assert.Contains(id, hits);
    }

    [Fact]
    public void SpatialHash_Case_049()
    {
        var hash = new SpatialHash(48f);
        var id = hash.Insert(new Aabb(new Vector2(49, 0), new Vector2(59, 10)));
        var hits = new List<int>();
        hash.QueryOverlaps(new Aabb(new Vector2(51, 2), new Vector2(57, 8)), hits);
        Assert.Contains(id, hits);
    }
}
