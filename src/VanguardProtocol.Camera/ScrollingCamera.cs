using System.Numerics;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Camera;

public struct CameraFocus : IComponent
{
    public float Weight;
}

public sealed class ScrollingCamera
{
    public Vector2 Position { get; private set; }
    public Vector2 ViewSize { get; set; } = new(640, 360);
    public Vector2 LevelBounds { get; set; } = new(640, 360);
    public float SmoothSpeed { get; set; } = 8f;

    private Vector2 _lockMin = new(float.NegativeInfinity, float.NegativeInfinity);
    private Vector2 _lockMax = new(float.PositiveInfinity, float.PositiveInfinity);
    private bool _locked;

    public void Lock(Vector2 min, Vector2 max)
    {
        _lockMin = min;
        _lockMax = max;
        _locked = true;
    }

    public void Unlock() => _locked = false;

    public void Follow(World world, float dt)
    {
        var focus = Vector2.Zero;
        var weightSum = 0f;
        var focuses = world.GetStore<CameraFocus>();
        var transforms = world.GetStore<Transform>();

        foreach (var (entity, cam) in focuses)
        {
            if (!transforms.TryGet(entity, out var t))
                continue;
            focus += t.Position * cam.Weight;
            weightSum += cam.Weight;
        }

        if (weightSum <= 0f)
            return;

        focus /= weightSum;
        var target = focus - ViewSize * new Vector2(0.35f, 0.45f);

        if (_locked)
        {
            target = Vector2.Clamp(target, _lockMin, _lockMax);
        }
        else
        {
            var max = new Vector2(
                Math.Max(0f, LevelBounds.X - ViewSize.X),
                Math.Max(0f, LevelBounds.Y - ViewSize.Y));
            target = Vector2.Clamp(target, Vector2.Zero, max);
        }

        var tSmooth = 1f - MathF.Exp(-SmoothSpeed * dt);
        Position = Vector2.Lerp(Position, target, tSmooth);
    }
}

public sealed class ScreenShake
{
    private float _trauma;

    public void AddTrauma(float amount) => _trauma = Math.Clamp(_trauma + amount, 0f, 1f);

    public Vector2 Update(float dt, Random? rng = null)
    {
        rng ??= Random.Shared;
        _trauma = Math.Max(0f, _trauma - dt);
        if (_trauma <= 0f)
            return Vector2.Zero;

        var shake = _trauma * _trauma;
        return new Vector2(
            (float)(rng.NextDouble() * 2 - 1) * shake * 6f,
            (float)(rng.NextDouble() * 2 - 1) * shake * 6f);
    }
}

public readonly struct BossLockRegion
{
    public BossLockRegion(float minX, float maxX, float minY, float maxY)
    {
        MinX = minX;
        MaxX = maxX;
        MinY = minY;
        MaxY = maxY;
    }

    public float MinX { get; }
    public float MaxX { get; }
    public float MinY { get; }
    public float MaxY { get; }
}
