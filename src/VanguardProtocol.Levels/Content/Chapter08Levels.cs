using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels.Content;

public static class Chapter08Levels
{

    public static LevelData Stage1()
    {
        const int w = 165;
        const int h = 24;
        var tiles = new TileFlags[w * h];
        for (var x = 0; x < w; x++)
        {
            tiles[(h - 1) * w + x] = TileFlags.Solid;
            if (x % 8 == 0 && h > 2)
                tiles[(h - 2) * w + x] = TileFlags.Solid;
            if (x % 19 == 0 && h > 5)
                tiles[(h - 5) * w + x] = TileFlags.OneWay;
            if (x % 14 == 0)
                tiles[(h - 1) * w + Math.Min(w - 1, x + 1)] = TileFlags.Hazard | TileFlags.Solid;
        }

        for (var i = 0; i < 6; i++)
        {
            var px = 8 + i * 14;
            if (px >= w - 2) break;
            tiles[(h - 3) * w + px] = TileFlags.SlopeUpRight;
        }

        return new LevelData
        {
            Name = "ch8_s1",
            Width = w,
            Height = h,
            TileSize = 16,
            Tiles = tiles,
            Spawns =
            [
                new EntitySpawn { Type = "player", X = 32, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "walker", X = 120, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "turret", X = 220, Y = (h - 6) * 16 },
            ],
            Triggers =
            [
                new TriggerZone { Id = "exit", Kind = TriggerKind.LevelExit, X = (w - 3) * 16, Y = (h - 5) * 16, Width = 32, Height = 48 },
                new TriggerZone { Id = "cp1", Kind = TriggerKind.Checkpoint, X = w * 8, Y = (h - 5) * 16, Width = 24, Height = 48 },
            ],
            Parallax =
            [
                new ParallaxLayer { Name = "far", ScrollFactorX = 0.2f, ScrollFactorY = 0.05f },
                new ParallaxLayer { Name = "near", ScrollFactorX = 0.55f, ScrollFactorY = 0.15f },
            ],
        };
    }
    public static LevelData Stage2()
    {
        const int w = 170;
        const int h = 28;
        var tiles = new TileFlags[w * h];
        for (var x = 0; x < w; x++)
        {
            tiles[(h - 1) * w + x] = TileFlags.Solid;
            if (x % 9 == 0 && h > 2)
                tiles[(h - 2) * w + x] = TileFlags.Solid;
            if (x % 19 == 0 && h > 5)
                tiles[(h - 5) * w + x] = TileFlags.OneWay;
            if (x % 15 == 0)
                tiles[(h - 1) * w + Math.Min(w - 1, x + 1)] = TileFlags.Hazard | TileFlags.Solid;
        }

        for (var i = 0; i < 7; i++)
        {
            var px = 8 + i * 14;
            if (px >= w - 2) break;
            tiles[(h - 3) * w + px] = TileFlags.SlopeUpRight;
        }

        return new LevelData
        {
            Name = "ch8_s2",
            Width = w,
            Height = h,
            TileSize = 16,
            Tiles = tiles,
            Spawns =
            [
                new EntitySpawn { Type = "player", X = 32, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "walker", X = 120, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "turret", X = 220, Y = (h - 6) * 16 },
            ],
            Triggers =
            [
                new TriggerZone { Id = "exit", Kind = TriggerKind.LevelExit, X = (w - 3) * 16, Y = (h - 5) * 16, Width = 32, Height = 48 },
                new TriggerZone { Id = "cp1", Kind = TriggerKind.Checkpoint, X = w * 8, Y = (h - 5) * 16, Width = 24, Height = 48 },
            ],
            Parallax =
            [
                new ParallaxLayer { Name = "far", ScrollFactorX = 0.2f, ScrollFactorY = 0.05f },
                new ParallaxLayer { Name = "near", ScrollFactorX = 0.55f, ScrollFactorY = 0.15f },
            ],
        };
    }
    public static LevelData Stage3()
    {
        const int w = 175;
        const int h = 20;
        var tiles = new TileFlags[w * h];
        for (var x = 0; x < w; x++)
        {
            tiles[(h - 1) * w + x] = TileFlags.Solid;
            if (x % 10 == 0 && h > 2)
                tiles[(h - 2) * w + x] = TileFlags.Solid;
            if (x % 19 == 0 && h > 5)
                tiles[(h - 5) * w + x] = TileFlags.OneWay;
            if (x % 16 == 0)
                tiles[(h - 1) * w + Math.Min(w - 1, x + 1)] = TileFlags.Hazard | TileFlags.Solid;
        }

        for (var i = 0; i < 8; i++)
        {
            var px = 8 + i * 14;
            if (px >= w - 2) break;
            tiles[(h - 3) * w + px] = TileFlags.SlopeUpRight;
        }

        return new LevelData
        {
            Name = "ch8_s3",
            Width = w,
            Height = h,
            TileSize = 16,
            Tiles = tiles,
            Spawns =
            [
                new EntitySpawn { Type = "player", X = 32, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "walker", X = 120, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "turret", X = 220, Y = (h - 6) * 16 },
            ],
            Triggers =
            [
                new TriggerZone { Id = "exit", Kind = TriggerKind.LevelExit, X = (w - 3) * 16, Y = (h - 5) * 16, Width = 32, Height = 48 },
                new TriggerZone { Id = "cp1", Kind = TriggerKind.Checkpoint, X = w * 8, Y = (h - 5) * 16, Width = 24, Height = 48 },
            ],
            Parallax =
            [
                new ParallaxLayer { Name = "far", ScrollFactorX = 0.2f, ScrollFactorY = 0.05f },
                new ParallaxLayer { Name = "near", ScrollFactorX = 0.55f, ScrollFactorY = 0.15f },
            ],
        };
    }
    public static LevelData Stage4()
    {
        const int w = 180;
        const int h = 24;
        var tiles = new TileFlags[w * h];
        for (var x = 0; x < w; x++)
        {
            tiles[(h - 1) * w + x] = TileFlags.Solid;
            if (x % 11 == 0 && h > 2)
                tiles[(h - 2) * w + x] = TileFlags.Solid;
            if (x % 19 == 0 && h > 5)
                tiles[(h - 5) * w + x] = TileFlags.OneWay;
            if (x % 17 == 0)
                tiles[(h - 1) * w + Math.Min(w - 1, x + 1)] = TileFlags.Hazard | TileFlags.Solid;
        }

        for (var i = 0; i < 9; i++)
        {
            var px = 8 + i * 14;
            if (px >= w - 2) break;
            tiles[(h - 3) * w + px] = TileFlags.SlopeUpRight;
        }

        return new LevelData
        {
            Name = "ch8_s4",
            Width = w,
            Height = h,
            TileSize = 16,
            Tiles = tiles,
            Spawns =
            [
                new EntitySpawn { Type = "player", X = 32, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "walker", X = 120, Y = (h - 4) * 16 },
                new EntitySpawn { Type = "turret", X = 220, Y = (h - 6) * 16 },
            ],
            Triggers =
            [
                new TriggerZone { Id = "exit", Kind = TriggerKind.LevelExit, X = (w - 3) * 16, Y = (h - 5) * 16, Width = 32, Height = 48 },
                new TriggerZone { Id = "cp1", Kind = TriggerKind.Checkpoint, X = w * 8, Y = (h - 5) * 16, Width = 24, Height = 48 },
            ],
            Parallax =
            [
                new ParallaxLayer { Name = "far", ScrollFactorX = 0.2f, ScrollFactorY = 0.05f },
                new ParallaxLayer { Name = "near", ScrollFactorX = 0.55f, ScrollFactorY = 0.15f },
            ],
        };
    }
}
