using VanguardProtocol.Levels;
using VanguardProtocol.Physics;

namespace VanguardProtocol.LevelEditor;

public sealed class LevelCanvas
{
    private readonly Tilemap _map;
    private readonly List<(string EntityId, int X, int Y)> _entities = new();
    private readonly Stack<EditorCommand> _undo = new();
    private readonly Stack<EditorCommand> _redo = new();

    public LevelCanvas(int width, int height, int tileSize = 16) =>
        _map = Tilemap.CreateEmpty(width, height, tileSize);

    public Tilemap Map => _map;
    public IReadOnlyList<(string EntityId, int X, int Y)> Entities => _entities;

    public void Paint(int x, int y, TileFlags flags)
    {
        if (x < 0 || y < 0 || x >= _map.Width || y >= _map.Height)
            return;
        var idx = y * _map.Width + x;
        var prev = _map.Tiles[idx];
        if (prev == flags)
            return;
        _map.Tiles[idx] = flags;
        _undo.Push(new EditorCommand(x, y, prev, flags, null, false));
        _redo.Clear();
    }

    public void PlaceEntity(string id, int x, int y)
    {
        _entities.Add((id, x, y));
        _undo.Push(new EditorCommand(x, y, TileFlags.None, TileFlags.None, id, true));
        _redo.Clear();
    }

    public bool Undo()
    {
        if (_undo.Count == 0)
            return false;
        var c = _undo.Pop();
        if (c.IsEntity)
            _entities.RemoveAll(e => e.EntityId == c.EntityId && e.X == c.X && e.Y == c.Y);
        else
            _map.Tiles[c.Y * _map.Width + c.X] = c.Before;
        _redo.Push(c);
        return true;
    }

    public bool Redo()
    {
        if (_redo.Count == 0)
            return false;
        var c = _redo.Pop();
        if (c.IsEntity)
            _entities.Add((c.EntityId!, c.X, c.Y));
        else
            _map.Tiles[c.Y * _map.Width + c.X] = c.After;
        _undo.Push(c);
        return true;
    }

    private readonly record struct EditorCommand(int X, int Y, TileFlags Before, TileFlags After, string? EntityId, bool IsEntity);
}
