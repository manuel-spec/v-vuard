using System.Numerics;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Physics;

/// <summary>
/// Platformer character controller layered on tilemap collision:
/// coyote time, jump buffer consumption, grounded snap, ceiling cancel.
/// </summary>
public sealed class CharacterController
{
    public float Gravity { get; set; } = 980f;
    public float MoveSpeed { get; set; } = 140f;
    public float JumpSpeed { get; set; } = 320f;
    public float CoyoteTimeSeconds { get; set; } = 0.08f;
    public float MaxFallSpeed { get; set; } = 520f;

    private float _coyoteRemaining;

    public void ApplyHorizontal(ref Velocity velocity, int moveAxis)
    {
        var target = moveAxis * MoveSpeed;
        velocity.Value = DeterministicMath.Quantize(new Vector2(target, velocity.Value.Y));
    }

    public bool TryJump(ref Velocity velocity, bool grounded, bool jumpPressed)
    {
        if (grounded)
            _coyoteRemaining = CoyoteTimeSeconds;

        if (!jumpPressed)
            return false;

        if (!grounded && _coyoteRemaining <= 0f)
            return false;

        velocity.Value = DeterministicMath.Quantize(new Vector2(velocity.Value.X, -JumpSpeed));
        _coyoteRemaining = 0f;
        return true;
    }

    public void Integrate(ref Velocity velocity, float dt, bool grounded)
    {
        if (grounded && velocity.Value.Y > 0f)
            velocity.Value = DeterministicMath.Quantize(new Vector2(velocity.Value.X, 0f));

        if (!grounded)
        {
            _coyoteRemaining = MathF.Max(0f, _coyoteRemaining - dt);
            var vy = velocity.Value.Y + Gravity * dt;
            if (vy > MaxFallSpeed)
                vy = MaxFallSpeed;
            velocity.Value = DeterministicMath.Quantize(new Vector2(velocity.Value.X, vy));
        }
    }

    public void CancelUpwardOnCeiling(ref Velocity velocity, bool hitCeiling)
    {
        if (hitCeiling && velocity.Value.Y < 0f)
            velocity.Value = DeterministicMath.Quantize(new Vector2(velocity.Value.X, 0f));
    }
}

public struct MovingPlatformComponent : IComponent
{
    public Vector2 PointA;
    public Vector2 PointB;
    public float Speed;
    public float Phase; // 0..1 along A->B->A
    public bool PingPong;
}

public static class MovingPlatformSolver
{
    public static Vector2 EvaluatePosition(in MovingPlatformComponent platform)
    {
        var t = platform.Phase;
        if (platform.PingPong)
        {
            var cycle = t % 2f;
            if (cycle < 0f)
                cycle += 2f;
            t = cycle <= 1f ? cycle : 2f - cycle;
        }
        else
        {
            t -= MathF.Floor(t);
        }

        return DeterministicMath.Quantize(Vector2.Lerp(platform.PointA, platform.PointB, t));
    }

    public static void Advance(ref MovingPlatformComponent platform, float dt)
    {
        var distance = Vector2.Distance(platform.PointA, platform.PointB);
        if (distance <= 0.001f || platform.Speed <= 0f)
            return;
        platform.Phase = DeterministicMath.Quantize(platform.Phase + (platform.Speed * dt) / distance);
    }
}

public enum HazardKind : byte
{
    Spikes = 0,
    Lava = 1,
    Electric = 2,
}

public struct HazardComponent : IComponent
{
    public HazardKind Kind;
    public int DamagePerHit;
    public float HitCooldownSeconds;
    public float CooldownRemaining;
}
