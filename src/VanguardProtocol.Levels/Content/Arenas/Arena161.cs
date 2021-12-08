using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels.Content.Arenas;

public static class Arena161
{
    public const string Id = "arena_161";
    private static readonly string[] Rows =
    [
        ".....................................",
        ".....................................",
        ".....................................",
        ".....................................",
        ".....................................",
        ".....................................",
        ".....................................",
        ".....................................",
        ".....................................",
        ".....................................",
        "O.......O.......O.......O.......O....",
        "L.........L.........L.........L......",
        "S.......S.......S.......S.......S....",
        "S.......S.......S.......S.......S....",
        "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"
    ];

    public static LevelData Build()
    {
        var h = Rows.Length;
        var width = Rows[0].Length;
        var tiles = new TileFlags[width * h];
        for (var y = 0; y < h; y++)
        for (var x = 0; x < width; x++)
        {
            tiles[y * width + x] = Rows[y][x] switch
            {
                'S' => TileFlags.Solid,
                'O' => TileFlags.OneWay,
                'R' => TileFlags.SlopeUpRight,
                'L' => TileFlags.SlopeUpLeft,
                'H' => TileFlags.Hazard | TileFlags.Solid,
                _ => TileFlags.None,
            };
        }
        return new LevelData
        {
            Name = Id,
            Width = width,
            Height = h,
            TileSize = 16,
            Tiles = tiles,
            Spawns = [ new EntitySpawn { Type = "player", X = 32, Y = (h - 4) * 16 } ],
        };
    }
}
