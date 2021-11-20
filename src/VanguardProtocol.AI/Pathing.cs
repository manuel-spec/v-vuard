using System.Numerics;
using VanguardProtocol.Physics;

namespace VanguardProtocol.AI;

public sealed class WaypointPath
{
    private readonly Vector2[] _points;
    private int _index;

    public WaypointPath(params Vector2[] points)
    {
        if (points.Length < 1)
            throw new ArgumentException("Need waypoints");
        _points = points;
    }

    public int Count => _points.Length;
    public Vector2 Current => _points[_index];

    public bool AdvanceIfClose(Vector2 position, float threshold = 6f)
    {
        if (Vector2.Distance(position, Current) <= threshold)
        {
            _index = (_index + 1) % _points.Length;
            return true;
        }

        return false;
    }

    public Vector2 Steering(Vector2 position, float speed)
    {
        var delta = Current - position;
        if (delta.LengthSquared() < 0.0001f)
            return Vector2.Zero;
        return DeterministicMath.Quantize(Vector2.Normalize(delta) * speed);
    }
}
