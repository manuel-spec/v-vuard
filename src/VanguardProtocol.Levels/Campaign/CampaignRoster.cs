using VanguardProtocol.Levels.Campaign;

namespace VanguardProtocol.Levels;

public readonly record struct CampaignStage(int Index, string Id, string Title, Func<LevelData> Build);

/// <summary>
/// 25 playable campaign stages: authored Stage 1 plus arenas 1–24 adapted for fair play.
/// </summary>
public static class CampaignRoster
{
    public const int StageCount = 25;

    private static readonly string[] Titles =
    [
        "Vale Outpost",
        "Ridge Patrol",
        "Broken Causeway",
        "Silo Approach",
        "Night Wire",
        "Ash Culvert",
        "Signal Spine",
        "Crater Steps",
        "Relay Cut",
        "Iron Hollow",
        "Fog Quay",
        "Split Trestle",
        "Gun Nest",
        "Low Orbit",
        "Shard Run",
        "Amber Duct",
        "Crossbolt",
        "Blackout Pier",
        "Coil Yard",
        "Redline",
        "Ventsweep",
        "Glass March",
        "Thunder Gate",
        "Last Spur",
        "Horizon Breach",
    ];

    private static readonly CampaignStage[] Stages = BuildStages();

    public static IReadOnlyList<CampaignStage> All => Stages;

    public static CampaignStage Get(int index1Based)
    {
        if (index1Based is < 1 or > StageCount)
            throw new ArgumentOutOfRangeException(nameof(index1Based));
        return Stages[index1Based - 1];
    }

    public static CampaignStage GetById(string id)
    {
        foreach (var stage in Stages)
        {
            if (string.Equals(stage.Id, id, StringComparison.Ordinal))
                return stage;
        }

        throw new KeyNotFoundException($"Unknown campaign stage '{id}'.");
    }

    public static bool TryGetNext(string currentId, out CampaignStage next)
    {
        for (var i = 0; i < Stages.Length; i++)
        {
            if (!string.Equals(Stages[i].Id, currentId, StringComparison.Ordinal))
                continue;
            if (i + 1 >= Stages.Length)
            {
                next = default;
                return false;
            }

            next = Stages[i + 1];
            return true;
        }

        next = default;
        return false;
    }

    public static string IdForIndex(int index1Based)
    {
        // ch1_s1..ch1_s4, ch2_s1.. → matches ProgressTracker.UnlockNext
        var zero = index1Based - 1;
        var chapter = zero / 4 + 1;
        var stage = zero % 4 + 1;
        return $"ch{chapter}_s{stage}";
    }

    private static CampaignStage[] BuildStages()
    {
        var stages = new CampaignStage[StageCount];
        for (var i = 0; i < StageCount; i++)
        {
            var index = i + 1;
            var id = IdForIndex(index);
            var title = Titles[i];
            if (index == 1)
            {
                stages[i] = new CampaignStage(index, id, title, () =>
                {
                    var level = Stage01ValeOutpost.Build();
                    // Keep authored layout; align campaign id with roster.
                    return new LevelData
                    {
                        Name = id,
                        Width = level.Width,
                        Height = level.Height,
                        TileSize = level.TileSize,
                        Tiles = level.Tiles,
                        Spawns = level.Spawns,
                        Triggers = level.Triggers,
                        Parallax = level.Parallax,
                    };
                });
            }
            else
            {
                var arenaNumber = index - 1; // stages 2..25 → arenas 1..24
                stages[i] = new CampaignStage(index, id, title, () =>
                    PlayableLevelAdapter.Adapt(ArenaCatalog.Build(arenaNumber), id, title, index));
            }
        }

        return stages;
    }
}
