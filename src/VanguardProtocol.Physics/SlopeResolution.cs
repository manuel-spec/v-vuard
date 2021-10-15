using System.Numerics;

namespace VanguardProtocol.Physics;

public static class SlopeResolution
{
    /// <summary>
    /// Y-down coordinates: SlopeUpRight (/) is low on the left, high on the right.
    /// SlopeUpLeft (\) is high on the left, low on the right.
    /// </summary>
    public static void Resolve(
        ref Vector2 position,
        ref Vector2 frameDelta,
        Vector2 size,
        Aabb tile,
        TileFlags flags,
        ref bool onGround)
    {
        var feetX = position.X + size.X * 0.5f;
        if (feetX < tile.Min.X || feetX > tile.Max.X)
            return;

        var t = (feetX - tile.Min.X) / tile.Width;
        float surfaceY;
        if ((flags & TileFlags.SlopeUpRight) != 0)
            surfaceY = tile.Max.Y - t * tile.Height;
        else if ((flags & TileFlags.SlopeUpLeft) != 0)
            surfaceY = tile.Min.Y + t * tile.Height;
        else
            return;

        var feetY = position.Y + size.Y;
        if (frameDelta.Y >= 0f && feetY >= surfaceY - 4f && feetY <= surfaceY + tile.Height)
        {
            position.Y = DeterministicMath.Quantize(surfaceY - size.Y);
            if (frameDelta.Y > 0f)
                frameDelta.Y = 0f;
            onGround = true;
        }
    }
}
