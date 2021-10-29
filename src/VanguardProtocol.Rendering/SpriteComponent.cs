using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Rendering;

public enum RenderLayer : int
{
    Background = 0,
    Midground = 100,
    Gameplay = 200,
    Foreground = 300,
    Ui = 400,
}

public struct SpriteComponent : IComponent
{
    public int SourceX;
    public int SourceY;
    public int SourceWidth;
    public int SourceHeight;
    public float DisplayWidth;
    public float DisplayHeight;
    public uint ColorRgba;
    public RenderLayer Layer;
    public bool FlipX;

    public SpriteComponent(float width, float height, uint colorRgba = 0xFFFFFFFF, RenderLayer layer = RenderLayer.Gameplay)
    {
        SourceX = 0;
        SourceY = 0;
        SourceWidth = 1;
        SourceHeight = 1;
        DisplayWidth = width;
        DisplayHeight = height;
        ColorRgba = colorRgba;
        Layer = layer;
        FlipX = false;
    }
}

public struct Particle
{
    public float X, Y, Vx, Vy;
    public float Life;
    public float MaxLife;
    public uint ColorRgba;
    public float Size;
}

public sealed class ParticleSystem
{
    private readonly Particle[] _particles;
    private int _count;

    public ParticleSystem(int capacity = 256)
    {
        _particles = new Particle[capacity];
    }

    public ReadOnlySpan<Particle> Active => _particles.AsSpan(0, _count);

    public void Emit(float x, float y, float vx, float vy, float life, uint color, float size = 2f)
    {
        if (_count >= _particles.Length)
            return;

        _particles[_count++] = new Particle
        {
            X = x,
            Y = y,
            Vx = vx,
            Vy = vy,
            Life = life,
            MaxLife = life,
            ColorRgba = color,
            Size = size,
        };
    }

    public void Update(float dt)
    {
        for (var i = _count - 1; i >= 0; i--)
        {
            ref var p = ref _particles[i];
            p.Life -= dt;
            if (p.Life <= 0f)
            {
                _particles[i] = _particles[_count - 1];
                _count--;
                continue;
            }

            p.X += p.Vx * dt;
            p.Y += p.Vy * dt;
        }
    }
}

public static class PostEffects
{
    public static float ScreenFlash { get; private set; }

    public static void Flash(float intensity = 0.45f) =>
        ScreenFlash = Math.Max(ScreenFlash, intensity);

    public static void Update(float dt) =>
        ScreenFlash = Math.Max(0f, ScreenFlash - dt * 2.5f);
}
