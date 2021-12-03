using VanguardProtocol.Levels;
using VanguardProtocol.Physics;

namespace VanguardProtocol.LevelEditor;

public sealed class LevelExporter
{
    public LevelData FromCanvas(string name, LevelCanvas canvas)
    {
        var map = canvas.Map;
        var tiles = (TileFlags[])map.Tiles.Clone();
        var spawns = canvas.Entities.Select(e => new EntitySpawn
        {
            Type = e.EntityId,
            X = e.X * map.TileSize,
            Y = e.Y * map.TileSize,
        }).ToList();

        return new LevelData
        {
            Name = name,
            Width = map.Width,
            Height = map.Height,
            TileSize = map.TileSize,
            Tiles = tiles,
            Spawns = spawns,
        };
    }
}
