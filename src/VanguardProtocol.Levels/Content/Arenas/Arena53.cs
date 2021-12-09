using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels.Content.Arenas;

public static class Arena53
{
    public const string Id = "arena_53";
    private static readonly string[] Rows =
    [
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "...............................................................",
        "O........O........O........O........O........O........O........",
        "R..............R..............R..............R..............R..",
        "S......S......S......S......S......S......S......S......S......",
        "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"
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
            Triggers = [ new TriggerZone { Id = "exit", Kind = TriggerKind.LevelExit, X = (width - 3) * 16f, Y = (h - 5) * 16f, Width = 32, Height = 48 } ],
        };
    }
}
