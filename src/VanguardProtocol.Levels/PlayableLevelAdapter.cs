using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels;

/// <summary>
/// Turns raw arena tile art into a fair run-and-gun stage: continuous floor with
/// jumpable pits, no body-clipping slope clutter, floor-level exit, and spawns
/// the Game host understands.
/// </summary>
public static class PlayableLevelAdapter
{
    public const float PlayerHeight = 22f;

    public static LevelData Adapt(LevelData source, string campaignId, string displayHint, int stageIndex)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (source.Width < 16 || source.Height < 8)
            throw new ArgumentException("Arena too small to adapt.", nameof(source));

        var w = source.Width;
        var h = source.Height;
        var tile = source.TileSize <= 0 ? 16 : source.TileSize;
        var tiles = (TileFlags[])source.Tiles.Clone();
        var floorRow = h - 2;

        // Keep elevated one-ways; strip body-clipping solids/slopes above the floor.
        for (var y = 0; y < floorRow; y++)
        for (var x = 0; x < w; x++)
        {
            var i = y * w + x;
            var flags = tiles[i];
            if ((flags & TileFlags.OneWay) != 0)
                continue;
            if ((flags & (TileFlags.Solid | TileFlags.SlopeUpLeft | TileFlags.SlopeUpRight | TileFlags.Hazard)) != 0)
                tiles[i] = TileFlags.None;
        }

        // Rebuild a fair ground row with short pits that scale gently with stage index.
        var pitEvery = Math.Max(14, 22 - stageIndex / 3);
        var pitWidth = stageIndex < 10 ? 2 : 3;
        for (var x = 0; x < w; x++)
        {
            tiles[floorRow * w + x] = TileFlags.None;
            if (x == 0 || x == w - 1)
            {
                tiles[floorRow * w + x] = TileFlags.Solid;
                continue;
            }

            var inPitZone = x > 8 && x < w - 10 && ((x / pitEvery) % 2 == 1);
            var pitLocal = x % pitEvery;
            var inPit = inPitZone && pitLocal >= pitEvery - pitWidth && pitLocal < pitEvery;
            if (!inPit)
                tiles[floorRow * w + x] = TileFlags.Solid;
        }

        // Side walls near the floor so the player cannot walk out of the world.
        for (var y = Math.Max(0, floorRow - 4); y < h; y++)
        {
            tiles[y * w + 0] = TileFlags.Solid;
            tiles[y * w + (w - 1)] = TileFlags.Solid;
        }

        var floorY = floorRow * tile;
        var spawnY = floorY - PlayerHeight;
        var walkerCount = Math.Clamp(1 + stageIndex / 4, 1, 5);
        var spawns = new List<EntitySpawn>
        {
            new() { Type = "Player", X = 48f, Y = spawnY },
        };

        for (var i = 0; i < walkerCount; i++)
        {
            var t = (i + 1f) / (walkerCount + 1f);
            var x = 120f + t * ((w - 12) * tile - 120f);
            spawns.Add(new EntitySpawn
            {
                Type = "walker",
                X = x,
                Y = spawnY,
                Properties = new Dictionary<string, string>
                {
                    ["hp"] = stageIndex >= 18 ? "2" : "1",
                    ["left"] = (x - 48f).ToString("0"),
                    ["right"] = (x + 48f).ToString("0"),
                },
            });
        }

        // Preserve flyer intent as floating threats (no gravity).
        foreach (var spawn in source.Spawns)
        {
            if (!spawn.Type.Equals("flyer", StringComparison.OrdinalIgnoreCase))
                continue;
            spawns.Add(new EntitySpawn
            {
                Type = "flyer",
                X = Math.Clamp(spawn.X, 80f, (w - 4) * tile),
                Y = Math.Min(spawn.Y, spawnY - 40f),
                Properties = new Dictionary<string, string>
                {
                    ["hp"] = "1",
                    ["left"] = Math.Max(64f, spawn.X - 60f).ToString("0"),
                    ["right"] = Math.Min((w - 3) * tile, spawn.X + 60f).ToString("0"),
                },
            });
        }

        if (stageIndex % 3 == 0)
        {
            spawns.Add(new EntitySpawn
            {
                Type = "pickup_weapon",
                X = 160f,
                Y = spawnY + 4f,
                Properties = new Dictionary<string, string> { ["weapon"] = "spread_cannon" },
            });
        }

        if (stageIndex % 4 == 0)
        {
            spawns.Add(new EntitySpawn
            {
                Type = "pickup_health",
                X = (w * 0.55f) * tile,
                Y = spawnY + 4f,
                Properties = new Dictionary<string, string> { ["amount"] = "1" },
            });
        }

        var exitX = (w - 6) * tile;
        var triggers = new List<TriggerZone>
        {
            new() { Id = "cp_start", Kind = TriggerKind.Checkpoint, X = 40f, Y = spawnY - 8f, Width = 40f, Height = 40f },
            new() { Id = "cp_mid", Kind = TriggerKind.Checkpoint, X = w * tile * 0.5f, Y = spawnY - 8f, Width = 40f, Height = 40f },
            new() { Id = "exit", Kind = TriggerKind.LevelExit, X = exitX, Y = spawnY - 16f, Width = 72f, Height = 48f },
        };

        var tint = (uint)(0xFF141C28 + (uint)((stageIndex * 0x010204) & 0x001F1F1F));
        return new LevelData
        {
            Name = campaignId,
            Width = w,
            Height = h,
            TileSize = tile,
            Tiles = tiles,
            Spawns = spawns,
            Triggers = triggers,
            Parallax =
            [
                new ParallaxLayer { Name = "sky", ScrollFactorX = 0.05f, ColorRgba = tint },
                new ParallaxLayer { Name = "ridge", ScrollFactorX = 0.22f, ColorRgba = tint + 0x000A1018 },
                new ParallaxLayer { Name = "haze", ScrollFactorX = 0.4f, ColorRgba = tint + 0x00101820 },
                new ParallaxLayer { Name = displayHint, ScrollFactorX = 0.55f, ColorRgba = 0xFF263446 },
            ],
        };
    }
}
