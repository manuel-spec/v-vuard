namespace VanguardProtocol.Animation;

public sealed class FrameEventHook
{
    private readonly List<(string EventId, Action Invoke)> _handlers = new();

    public void On(string eventId, Action handler) => _handlers.Add((eventId, handler));

    public void Dispatch(string? eventId)
    {
        if (eventId is null)
            return;
        foreach (var (id, invoke) in _handlers)
        {
            if (id == eventId)
                invoke();
        }
    }
}

public enum AimDirection : byte
{
    East = 0,
    NorthEast = 1,
    North = 2,
    NorthWest = 3,
    West = 4,
    SouthWest = 5,
    South = 6,
    SouthEast = 7,
}

public static class DirectionalPoses
{
    public static AimDirection FromVector(float x, float y)
    {
        if (MathF.Abs(x) < 0.01f && MathF.Abs(y) < 0.01f)
            return AimDirection.East;
        var angle = MathF.Atan2(-y, x) * (180f / MathF.PI);
        if (angle < 0)
            angle += 360f;
        var sector = (int)MathF.Floor((angle + 22.5f) / 45f) % 8;
        return sector switch
        {
            0 => AimDirection.East,
            1 => AimDirection.NorthEast,
            2 => AimDirection.North,
            3 => AimDirection.NorthWest,
            4 => AimDirection.West,
            5 => AimDirection.SouthWest,
            6 => AimDirection.South,
            _ => AimDirection.SouthEast,
        };
    }

    public static string ClipName(string baseName, AimDirection dir) =>
        $"{baseName}_{dir}".ToLowerInvariant();
}
