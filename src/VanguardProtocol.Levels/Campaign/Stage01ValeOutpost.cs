using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels.Campaign;

/// <summary>
/// Stage 1 — Vale Outpost. Designed to be completable: continuous floor,
/// short jumps, avoidable walkers (1 HP), clear glowing exit on the right.
/// </summary>
public static class Stage01ValeOutpost
{
    public const string Id = "ch1_s1";

    public static LevelData Build()
    {
        const int w = 72;
        const int h = 18;
        const int tile = 16;
        var tiles = new TileFlags[w * h];

        // Continuous main floor with two short, clearly jumpable pits (2 tiles = 32px).
        for (var x = 1; x < w - 1; x++)
        {
            if (x is >= 22 and <= 23)
                continue; // pit 1
            if (x is >= 48 and <= 49)
                continue; // pit 2
            tiles[(h - 2) * w + x] = TileFlags.Solid;
        }

        // Low optional platforms (one-way — jump up freely).
        for (var x = 10; x <= 14; x++)
            tiles[12 * w + x] = TileFlags.OneWay;
        for (var x = 32; x <= 36; x++)
            tiles[11 * w + x] = TileFlags.OneWay;
        for (var x = 56; x <= 60; x++)
            tiles[12 * w + x] = TileFlags.OneWay;

        // Soft side bounds (open sky feel, keep player in).
        for (var y = h - 6; y < h; y++)
        {
            tiles[y * w + 0] = TileFlags.Solid;
            tiles[y * w + (w - 1)] = TileFlags.Solid;
        }

        var floorY = (h - 2) * tile;
        var spawnY = floorY - 22;

        return new LevelData
        {
            Name = Id,
            Width = w,
            Height = h,
            TileSize = tile,
            Tiles = tiles,
            Spawns =
            [
                new EntitySpawn { Type = "Player", X = 48, Y = spawnY },
                new EntitySpawn { Type = "walker", X = 300, Y = spawnY, Properties = new Dictionary<string, string> { ["hp"] = "1", ["left"] = "260", ["right"] = "360" } },
                new EntitySpawn { Type = "walker", X = 620, Y = spawnY, Properties = new Dictionary<string, string> { ["hp"] = "1", ["left"] = "580", ["right"] = "680" } },
                new EntitySpawn { Type = "walker", X = 900, Y = spawnY, Properties = new Dictionary<string, string> { ["hp"] = "1", ["left"] = "860", ["right"] = "960" } },
                new EntitySpawn { Type = "pickup_weapon", X = 180, Y = spawnY + 4, Properties = new Dictionary<string, string> { ["weapon"] = "spread_cannon" } },
                new EntitySpawn { Type = "pickup_health", X = 720, Y = spawnY + 4, Properties = new Dictionary<string, string> { ["amount"] = "1" } },
            ],
            Triggers =
            [
                new TriggerZone { Id = "cp_start", Kind = TriggerKind.Checkpoint, X = 40, Y = spawnY - 8, Width = 40, Height = 40 },
                new TriggerZone { Id = "cp_mid", Kind = TriggerKind.Checkpoint, X = 640, Y = spawnY - 8, Width = 40, Height = 40 },
                // Floor-level exit — no raised solid blocks (those clip the 22px player).
                new TriggerZone { Id = "exit", Kind = TriggerKind.LevelExit, X = (w - 8) * tile, Y = spawnY - 16, Width = 72, Height = 48 },
            ],
            Parallax =
            [
                new ParallaxLayer { Name = "sky", ScrollFactorX = 0.05f, ColorRgba = 0xFF141C28 },
                new ParallaxLayer { Name = "ridge", ScrollFactorX = 0.25f, ColorRgba = 0xFF1E2A38 },
                new ParallaxLayer { Name = "haze", ScrollFactorX = 0.45f, ColorRgba = 0xFF263446 },
            ],
        };
    }
}
