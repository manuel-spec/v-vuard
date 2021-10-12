using System.Numerics;

namespace VanguardProtocol.Physics;

public sealed class CollisionTilemap
{
    public CollisionTilemap(int width, int height, int tileSize, TileFlags[] tiles)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentOutOfRangeException(nameof(width));
        if (tileSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(tileSize));
        if (tiles.Length != width * height)
            throw new ArgumentException("Tile array length must equal width * height.", nameof(tiles));

        Width = width;
        Height = height;
        TileSize = tileSize;
        Tiles = tiles;
    }

    public int Width { get; }
    public int Height { get; }
    public int TileSize { get; }
    public TileFlags[] Tiles { get; }

    public TileFlags Get(int tx, int ty)
    {
        if ((uint)tx >= (uint)Width || (uint)ty >= (uint)Height)
            return TileFlags.None;
        return Tiles[ty * Width + tx];
    }

    public void Set(int tx, int ty, TileFlags flags)
    {
        if ((uint)tx >= (uint)Width || (uint)ty >= (uint)Height)
            return;
        Tiles[ty * Width + tx] = flags;
    }

    public Aabb TileBounds(int tx, int ty) =>
        new(tx * TileSize, ty * TileSize, TileSize, TileSize);
}

[Flags]
public enum TileFlags : byte
{
    None = 0,
    Solid = 1 << 0,
    OneWay = 1 << 1,
    SlopeUpRight = 1 << 2,
    SlopeUpLeft = 1 << 3,
    Hazard = 1 << 4,
}

public static class TilemapCollision
{
    /// <summary>
    /// Moves <paramref name="position"/> by <paramref name="frameDelta"/> (pixels this tick)
    /// and resolves against the tilemap. Zeroes blocked axes on <paramref name="frameDelta"/>.
    /// </summary>
    public static void Resolve(
        CollisionTilemap map,
        ref Vector2 position,
        ref Vector2 frameDelta,
        Vector2 size,
        bool wasOnGround,
        out bool onGround)
    {
        onGround = false;
        position = DeterministicMath.Quantize(position);
        frameDelta = DeterministicMath.Quantize(frameDelta);

        position.X = DeterministicMath.Quantize(position.X + frameDelta.X);
        ResolveAxis(map, ref position, ref frameDelta, size, horizontal: true, wasOnGround, ref onGround);

        position.Y = DeterministicMath.Quantize(position.Y + frameDelta.Y);
        ResolveAxis(map, ref position, ref frameDelta, size, horizontal: false, wasOnGround, ref onGround);

        position = DeterministicMath.Quantize(position);
        frameDelta = DeterministicMath.Quantize(frameDelta);
    }

    private static void ResolveAxis(
        CollisionTilemap map,
        ref Vector2 position,
        ref Vector2 frameDelta,
        Vector2 size,
        bool horizontal,
        bool wasOnGround,
        ref bool onGround)
    {
        var bounds = new Aabb(position.X, position.Y, size.X, size.Y);
        var minTx = Math.Max(0, (int)MathF.Floor(bounds.Min.X / map.TileSize));
        var maxTx = Math.Min(map.Width - 1, (int)MathF.Floor((bounds.Max.X - 0.001f) / map.TileSize));
        var minTy = Math.Max(0, (int)MathF.Floor(bounds.Min.Y / map.TileSize));
        var maxTy = Math.Min(map.Height - 1, (int)MathF.Floor((bounds.Max.Y - 0.001f) / map.TileSize));

        for (var ty = minTy; ty <= maxTy; ty++)
        for (var tx = minTx; tx <= maxTx; tx++)
        {
            var flags = map.Get(tx, ty);
            if (flags == TileFlags.None)
                continue;

            var tile = map.TileBounds(tx, ty);

            if ((flags & (TileFlags.SlopeUpLeft | TileFlags.SlopeUpRight)) != 0)
            {
                if (!horizontal)
                    SlopeResolution.Resolve(ref position, ref frameDelta, size, tile, flags, ref onGround);
                continue;
            }

            if ((flags & TileFlags.OneWay) != 0)
            {
                if (!horizontal)
                    OneWayPlatforms.Resolve(ref position, ref frameDelta, size, tile, wasOnGround, ref onGround);
                continue;
            }

            if ((flags & TileFlags.Solid) == 0)
                continue;

            bounds = new Aabb(position.X, position.Y, size.X, size.Y);
            if (!bounds.Intersects(tile))
                continue;

            if (horizontal)
            {
                if (frameDelta.X > 0f)
                    position.X = tile.Min.X - size.X;
                else if (frameDelta.X < 0f)
                    position.X = tile.Max.X;
                frameDelta.X = 0f;
            }
            else
            {
                if (frameDelta.Y > 0f)
                {
                    position.Y = tile.Min.Y - size.Y;
                    frameDelta.Y = 0f;
                    onGround = true;
                }
                else if (frameDelta.Y < 0f)
                {
                    position.Y = tile.Max.Y;
                    frameDelta.Y = 0f;
                }
            }
        }
    }
}
