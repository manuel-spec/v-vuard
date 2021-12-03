namespace VanguardProtocol.LevelEditor;

public sealed class EntityPalette
{
    public sealed record Entry(string Id, string Category, int DefaultHp);
    private readonly List<Entry> _entries = new();

    public EntityPalette()
    {
        string[] cats = ["enemy", "pickup", "trigger", "decoration", "boss"];
        string[] names = ["walker", "turret", "flyer", "spawner", "health", "weapon", "checkpoint", "exit", "torch", "aegis"];
        for (var i = 0; i < names.Length; i++)
            _entries.Add(new Entry(names[i], cats[i % cats.Length], 1 + (i % 5) * 10));
    }

    public IReadOnlyList<Entry> Entries => _entries;
    public int SelectedIndex { get; set; }
    public Entry Selected => _entries[Math.Clamp(SelectedIndex, 0, _entries.Count - 1)];
}
