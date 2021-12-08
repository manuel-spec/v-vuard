using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels.Content.Arenas;

public static class Arena13
{
    public const string Id = "arena_13";
    private static readonly string[] Rows =
    [
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        ".............................................................",
        "O.........O.........O.........O.........O.........O.........O",
        "R.............R.............R.............R.............R....",
        "S.....S.....S.....S.....S.....S.....S.....S.....S.....S.....S",
        "SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS"
    ];

    public static LevelData Build()
    {
        var h = Rows.Length;
        var w = Rows[0].Length;
        var tiles = new TileFlags[w * h];
        for (var y = 0; y < h; y++)
        for (var x = 0; x < w; x++)
        {
            tiles[y * w + x] = Rows[y][x] switch
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
            Width = w,
            Height = h,
            TileSize = 16,
            Tiles = tiles,
            Spawns =
            [
                new EntitySpawn { Type = "player", X = 32, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "walker", X = 160, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "flyer", X = 240, Y = (h - 8) * 16 },
            ],
            Triggers =
            [
                new TriggerZone { Id = "exit", Kind = TriggerKind.LevelExit, X = (w - 3) * 16f, Y = (h - 5) * 16f, Width = 32, Height = 48 },
            ],
        };
    }
}
