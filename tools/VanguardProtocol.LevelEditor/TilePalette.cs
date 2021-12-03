using VanguardProtocol.Physics;

namespace VanguardProtocol.LevelEditor;

public sealed class TilePalette
{
    private readonly List<(string Name, TileFlags Flags)> _entries =
    [
        ("Empty", TileFlags.None),
        ("Solid", TileFlags.Solid),
        ("OneWay", TileFlags.OneWay),
        ("SlopeR", TileFlags.SlopeUpRight),
        ("SlopeL", TileFlags.SlopeUpLeft),
        ("Hazard", TileFlags.Hazard | TileFlags.Solid),
    ];

    public IReadOnlyList<(string Name, TileFlags Flags)> Entries => _entries;
    public int SelectedIndex { get; set; }
    public TileFlags Selected => _entries[Math.Clamp(SelectedIndex, 0, _entries.Count - 1)].Flags;
}
