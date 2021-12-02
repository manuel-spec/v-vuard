using System.Text.Json;

namespace VanguardProtocol.SaveSystem;

public sealed class SaveData
{
    public int Version { get; set; } = 1;
    public string PlayerName { get; set; } = "Pilot";
    public HashSet<string> UnlockedLevels { get; set; } = new(StringComparer.Ordinal) { "ch1_s1" };
    public Dictionary<string, int> HighScores { get; set; } = new(StringComparer.Ordinal);
    public int LivesDefault { get; set; } = 3;
    public float MusicVolume { get; set; } = 0.8f;
    public float SfxVolume { get; set; } = 1f;
}

public sealed class ProgressTracker
{
    private readonly SaveData _data;
    public ProgressTracker(SaveData data) => _data = data;
    public bool IsUnlocked(string levelId) => _data.UnlockedLevels.Contains(levelId);
    public void Unlock(string levelId) => _data.UnlockedLevels.Add(levelId);

    public void UnlockNext(string currentId)
    {
        if (!currentId.StartsWith("ch"))
            return;
        var parts = currentId.Split('_');
        if (parts.Length != 2)
            return;
        if (!int.TryParse(parts[0].AsSpan(2), out var ch))
            return;
        if (!int.TryParse(parts[1].AsSpan(1), out var st))
            return;
        if (st < 4)
            Unlock($"ch{ch}_s{st + 1}");
        else
            Unlock($"ch{ch + 1}_s1");
    }
}

public sealed class HighScoreTable
{
    private readonly SaveData _data;
    public HighScoreTable(SaveData data) => _data = data;
    public int Get(string levelId) => _data.HighScores.TryGetValue(levelId, out var s) ? s : 0;

    public bool TrySubmit(string levelId, int score)
    {
        var current = Get(levelId);
        if (score <= current)
            return false;
        _data.HighScores[levelId] = score;
        return true;
    }

    public IEnumerable<KeyValuePair<string, int>> Top(int n) =>
        _data.HighScores.OrderByDescending(kv => kv.Value).Take(n);
}

public sealed class SaveSerializer
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };
    public string Serialize(SaveData data) => JsonSerializer.Serialize(data, Options);
    public SaveData Deserialize(string json) => JsonSerializer.Deserialize<SaveData>(json, Options) ?? new SaveData();
    public void SaveToFile(string path, SaveData data) => File.WriteAllText(path, Serialize(data));
    public SaveData LoadFromFile(string path) => File.Exists(path) ? Deserialize(File.ReadAllText(path)) : new SaveData();
}
