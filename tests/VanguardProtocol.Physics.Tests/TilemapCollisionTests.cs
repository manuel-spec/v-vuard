using System.Numerics;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Physics.Tests;

public class FixedTests
{
    [Fact]
    public void Multiply_IsDeterministic()
    {
        var a = Fixed.FromFloat(2.5f);
        var b = Fixed.FromFloat(4f);
        var product = a * b;
        Assert.Equal(Fixed.FromFloat(10f).Raw, product.Raw);
    }

    [Fact]
    public void Quantize_RoundsConsistently()
    {
        var q = DeterministicMath.Quantize(new Vector2(1.234567f, -9.876543f));
        var again = DeterministicMath.Quantize(q);
        Assert.Equal(q, again);
    }
}

public class AabbTests
{
    [Fact]
    public void Intersects_DetectsOverlap()
    {
        var a = new Aabb(0, 0, 10, 10);
        var b = new Aabb(5, 5, 10, 10);
        var c = new Aabb(20, 20, 5, 5);
        Assert.True(a.Intersects(b));
        Assert.False(a.Intersects(c));
    }
}

public class TilemapCollisionTests
{
    private static CollisionTilemap FlatFloor(int width = 10, int height = 8, int tile = 16)
    {
        var tiles = new TileFlags[width * height];
        for (var x = 0; x < width; x++)
            tiles[(height - 1) * width + x] = TileFlags.Solid;
        return new CollisionTilemap(width, height, tile, tiles);
    }

    [Fact]
    public void Falling_LandsOnFloor()
    {
        var map = FlatFloor();
        var pos = new Vector2(32, 80);
        var delta = new Vector2(0, 40);
        var size = new Vector2(14, 22);

        TilemapCollision.Resolve(map, ref pos, ref delta, size, wasOnGround: false, out var onGround);

        Assert.True(onGround);
        Assert.Equal(0f, delta.Y);
        Assert.Equal((map.Height - 1) * map.TileSize - size.Y, pos.Y);
    }

    [Fact]
    public void Horizontal_StopsAtWall()
    {
        var width = 8;
        var height = 6;
        var tile = 16;
        var tiles = new TileFlags[width * height];
        for (var y = 0; y < height; y++)
            tiles[y * width + 5] = TileFlags.Solid;

        var map = new CollisionTilemap(width, height, tile, tiles);
        var pos = new Vector2(40, 20);
        var delta = new Vector2(30, 0);
        var size = new Vector2(14, 22);

        TilemapCollision.Resolve(map, ref pos, ref delta, size, false, out _);

        Assert.Equal(0f, delta.X);
        Assert.Equal(5 * tile - size.X, pos.X);
    }

    [Fact]
    public void OneWay_AllowsPassFromBelow()
    {
        var width = 6;
        var height = 6;
        var tile = 16;
        var tiles = new TileFlags[width * height];
        for (var x = 0; x < width; x++)
            tiles[3 * width + x] = TileFlags.OneWay;

        var map = new CollisionTilemap(width, height, tile, tiles);
        var size = new Vector2(14, 22);

        // Jumping up through
        var pos = new Vector2(16, 3 * tile + 4);
        var up = new Vector2(0, -20);
        TilemapCollision.Resolve(map, ref pos, ref up, size, false, out var onGroundUp);
        Assert.False(onGroundUp);

        // Landing from above
        pos = new Vector2(16, 3 * tile - size.Y - 2);
        var down = new Vector2(0, 10);
        TilemapCollision.Resolve(map, ref pos, ref down, size, false, out var onGroundDown);
        Assert.True(onGroundDown);
        Assert.Equal(3 * tile - size.Y, pos.Y);
    }

    [Fact]
    public void IdenticalInputs_ProduceIdenticalState()
    {
        var map = FlatFloor();
        var size = new Vector2(14, 22);

        Vector2 Simulate()
        {
            var pos = new Vector2(32, 40);
            var vel = new Vector2(60f, 0f);
            for (var i = 0; i < 120; i++)
            {
                vel.Y = DeterministicMath.Quantize(vel.Y + 1800f * (1f / 60f));
                var delta = DeterministicMath.Scale(vel, 1f / 60f);
                TilemapCollision.Resolve(map, ref pos, ref delta, size, false, out _);
                if (1f / 60f > 0f)
                    vel = DeterministicMath.Quantize(new Vector2(delta.X / (1f / 60f), delta.Y / (1f / 60f)));
            }

            return pos;
        }

        Assert.Equal(Simulate(), Simulate());
    }
}
