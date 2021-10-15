using System.Numerics;

namespace VanguardProtocol.Physics;

public static class OneWayPlatforms
{
    /// <summary>
    /// Collide only when landing from above (or already standing). Jumping up through is allowed.
    /// </summary>
    public static void Resolve(
        ref Vector2 position,
        ref Vector2 frameDelta,
        Vector2 size,
        Aabb platform,
        bool wasOnGround,
        ref bool onGround)
    {
        if (frameDelta.Y < 0f)
            return;

        var bounds = new Aabb(position.X, position.Y, size.X, size.Y);
        if (!bounds.Intersects(platform))
            return;

        var previousFeet = position.Y + size.Y - frameDelta.Y;
        var platformTop = platform.Min.Y;

        if (previousFeet <= platformTop + 2f || wasOnGround)
        {
            position.Y = DeterministicMath.Quantize(platformTop - size.Y);
            frameDelta.Y = 0f;
            onGround = true;
        }
    }
}
