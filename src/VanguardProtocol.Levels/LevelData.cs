using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels;

public sealed class Tilemap
{
    public Tilemap(int width, int height, int tileSize, TileFlags[] tiles)
    {
        Width = width;
        Height = height;
        TileSize = tileSize;
        Tiles = tiles;
    }

    public int Width { get; }
    public int Height { get; }
    public int TileSize { get; }
    public TileFlags[] Tiles { get; }

    public CollisionTilemap ToCollisionMap() => new(Width, Height, TileSize, Tiles);

    public static Tilemap CreateEmpty(int width, int height, int tileSize = 16)
    {
        return new Tilemap(width, height, tileSize, new TileFlags[width * height]);
    }
}

public sealed class ParallaxLayer
{
    public required string Name { get; init; }
    public float ScrollFactorX { get; init; } = 1f;
    public float ScrollFactorY { get; init; } = 1f;
    public uint ColorRgba { get; init; } = 0xFF224466;
}

public enum TriggerKind : byte
{
    Checkpoint = 0,
    CameraLock = 1,
    BossGate = 2,
    LevelExit = 3,
}

public sealed class TriggerZone
{
    public required string Id { get; init; }
    public TriggerKind Kind { get; init; }
    public float X { get; init; }
    public float Y { get; init; }
    public float Width { get; init; }
    public float Height { get; init; }
}

public sealed class EntitySpawn
{
    public required string Type { get; init; }
    public float X { get; init; }
    public float Y { get; init; }
    public Dictionary<string, string>? Properties { get; init; }
}

public sealed class LevelData
{
    public required string Name { get; init; }
    public int Width { get; init; }
    public int Height { get; init; }
    public int TileSize { get; init; } = 16;
    public TileFlags[] Tiles { get; init; } = [];
    public List<EntitySpawn> Spawns { get; init; } = [];
    public List<TriggerZone> Triggers { get; init; } = [];
    public List<ParallaxLayer> Parallax { get; init; } = [];

    public Tilemap ToTilemap() => new(Width, Height, TileSize, Tiles);

    public static LevelData CreateDemo()
    {
        const int w = 40;
        const int h = 18;
        const int tile = 16;
        var tiles = new TileFlags[w * h];

        // Floor
        for (var x = 0; x < w; x++)
            tiles[(h - 2) * w + x] = TileFlags.Solid;

        // Platforms
        for (var x = 6; x <= 12; x++)
            tiles[12 * w + x] = TileFlags.OneWay;
        for (var x = 18; x <= 24; x++)
            tiles[9 * w + x] = TileFlags.Solid;

        // Small slope run onto a block
        tiles[(h - 3) * w + 3] = TileFlags.SlopeUpRight;
        tiles[(h - 3) * w + 4] = TileFlags.Solid;

        // Walls
        for (var y = 0; y < h; y++)
        {
            tiles[y * w] = TileFlags.Solid;
            tiles[y * w + (w - 1)] = TileFlags.Solid;
        }

        return new LevelData
        {
            Name = "demo_outpost",
            Width = w,
            Height = h,
            TileSize = tile,
            Tiles = tiles,
            Spawns =
            [
                new EntitySpawn { Type = "Player", X = 48, Y = 180 },
            ],
            Triggers =
            [
                new TriggerZone
                {
                    Id = "start",
                    Kind = TriggerKind.Checkpoint,
                    X = 40,
                    Y = 160,
                    Width = 32,
                    Height = 48,
                },
            ],
            Parallax =
            [
                new ParallaxLayer { Name = "sky", ScrollFactorX = 0.1f, ColorRgba = 0xFF1A2030 },
                new ParallaxLayer { Name = "hills", ScrollFactorX = 0.4f, ColorRgba = 0xFF2A3848 },
            ],
        };
    }
}

public static class LevelLoader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() },
    };

    public static string ToJson(LevelData level) => JsonSerializer.Serialize(level, JsonOptions);

    public static LevelData FromJson(string json) =>
        JsonSerializer.Deserialize<LevelData>(json, JsonOptions)
        ?? throw new InvalidOperationException("Level JSON deserialized to null.");

    public static CollisionTilemap LoadCollision(LevelData level) => level.ToTilemap().ToCollisionMap();
}
