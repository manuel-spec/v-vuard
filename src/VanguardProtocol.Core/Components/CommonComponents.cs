using System.Numerics;
using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Core.Components;

public struct Transform : IComponent
{
    public Vector2 Position;
    public float Rotation;

    public Transform(Vector2 position, float rotation = 0f)
    {
        Position = position;
        Rotation = rotation;
    }
}

public struct Velocity : IComponent
{
    public Vector2 Value;

    public Velocity(Vector2 value) => Value = value;
}

public struct PlayerControlled : IComponent
{
    public int PlayerIndex;

    public PlayerControlled(int playerIndex) => PlayerIndex = playerIndex;
}

public struct DrawableRect : IComponent
{
    public float Width;
    public float Height;
    public uint ColorRgba;

    public DrawableRect(float width, float height, uint colorRgba = 0xFFFFFFFF)
    {
        Width = width;
        Height = height;
        ColorRgba = colorRgba;
    }
}
