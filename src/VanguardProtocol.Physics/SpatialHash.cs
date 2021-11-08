using System.Numerics;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Core.Memory;

namespace VanguardProtocol.Physics;

/// <summary>
/// Uniform-grid spatial hash for broad-phase AABB overlap queries.
/// Cell size is fixed for a session so peer checksums stay aligned.
/// </summary>
public sealed class SpatialHash
{
    private readonly float _cellSize;
    private readonly Dictionary<long, List<int>> _cells = new();
    private readonly List<Aabb> _boxes = new();
    private readonly List<int> _queryScratch = new(64);
    private readonly HashSet<int> _queryUnique = new();

    public SpatialHash(float cellSize = 64f)
    {
        if (cellSize <= 0f)
            throw new ArgumentOutOfRangeException(nameof(cellSize));
        _cellSize = cellSize;
    }

    public int Count => _boxes.Count;
    public float CellSize => _cellSize;

    public void Clear()
    {
        _cells.Clear();
        _boxes.Clear();
    }

    public int Insert(in Aabb box)
    {
        var id = _boxes.Count;
        _boxes.Add(box);
        ForEachCell(box, key =>
        {
            if (!_cells.TryGetValue(key, out var list))
            {
                list = new List<int>(4);
                _cells[key] = list;
            }

            list.Add(id);
        });
        return id;
    }

    public void QueryOverlaps(in Aabb box, List<int> results)
    {
        results.Clear();
        _queryUnique.Clear();
        var minX = Floor(box.Min.X);
        var minY = Floor(box.Min.Y);
        var maxX = Floor(box.Max.X);
        var maxY = Floor(box.Max.Y);
        for (var y = minY; y <= maxY; y++)
        {
            for (var x = minX; x <= maxX; x++)
            {
                if (!_cells.TryGetValue(Pack(x, y), out var list))
                    continue;
                for (var i = 0; i < list.Count; i++)
                {
                    var id = list[i];
                    if (!_queryUnique.Add(id))
                        continue;
                    if (_boxes[id].Intersects(box))
                        results.Add(id);
                }
            }
        }
    }

    public void QueryOverlaps(in Aabb box, Span<int> buffer, out int count)
    {
        _queryScratch.Clear();
        QueryOverlaps(box, _queryScratch);
        count = Math.Min(buffer.Length, _queryScratch.Count);
        for (var i = 0; i < count; i++)
            buffer[i] = _queryScratch[i];
    }

    public Aabb Get(int id) => _boxes[id];

    private void ForEachCell(in Aabb box, Action<long> visitor)
    {
        var minX = Floor(box.Min.X);
        var minY = Floor(box.Min.Y);
        var maxX = Floor(box.Max.X);
        var maxY = Floor(box.Max.Y);
        for (var y = minY; y <= maxY; y++)
        for (var x = minX; x <= maxX; x++)
            visitor(Pack(x, y));
    }

    private int Floor(float value) => (int)MathF.Floor(value / _cellSize);

    private static long Pack(int x, int y) => ((long)x << 32) ^ (uint)y;
}

public readonly struct ContactManifold
{
    public ContactManifold(int a, int b, Vector2 normal, float penetration)
    {
        A = a;
        B = b;
        Normal = DeterministicMath.Quantize(normal);
        Penetration = DeterministicMath.Quantize(penetration);
    }

    public int A { get; }
    public int B { get; }
    public Vector2 Normal { get; }
    public float Penetration { get; }
}

public sealed class NarrowPhase
{
    public void GenerateContacts(SpatialHash hash, List<int> candidateIds, List<ContactManifold> contacts)
    {
        contacts.Clear();
        for (var i = 0; i < candidateIds.Count; i++)
        {
            for (var j = i + 1; j < candidateIds.Count; j++)
            {
                var a = hash.Get(candidateIds[i]);
                var b = hash.Get(candidateIds[j]);
                if (!a.Intersects(b))
                    continue;

                var centerA = a.Center;
                var centerB = b.Center;
                var dx = centerB.X - centerA.X;
                var dy = centerB.Y - centerA.Y;
                var overlapX = ((a.Width + b.Width) * 0.5f) - MathF.Abs(dx);
                var overlapY = ((a.Height + b.Height) * 0.5f) - MathF.Abs(dy);
                if (overlapX < overlapY)
                {
                    var nx = dx < 0 ? -1f : 1f;
                    contacts.Add(new ContactManifold(candidateIds[i], candidateIds[j], new Vector2(nx, 0f), overlapX));
                }
                else
                {
                    var ny = dy < 0 ? -1f : 1f;
                    contacts.Add(new ContactManifold(candidateIds[i], candidateIds[j], new Vector2(0f, ny), overlapY));
                }
            }
        }
    }
}
