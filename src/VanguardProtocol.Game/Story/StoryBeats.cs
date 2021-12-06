namespace VanguardProtocol.Game.Story;

public sealed record StoryBeat(string Id, string Speaker, string Line, string? NextId);

public static class StoryBeats
{
    public static IReadOnlyList<StoryBeat> Intro =>
    [
        new("i1", "Commander Ryse", "Orbit relay is dark. You're dropping into Sector Vale.", "i2"),
        new("i2", "Pilot", "Copy. Weapons hot.", "i3"),
        new("i3", "Commander Ryse", "Find the pulse towers before the sky closes.", null),
    ];

    public static IReadOnlyList<StoryBeat> Midgame =>
    [
        new("m1", "Ops", "Aegis signature climbing. Boss door unlocked.", "m2"),
        new("m2", "Pilot", "On my way.", null),
    ];

    public static StoryBeat? Next(IReadOnlyList<StoryBeat> set, string? id)
    {
        if (id is null)
            return set.FirstOrDefault();
        var cur = set.FirstOrDefault(b => b.Id == id);
        if (cur?.NextId is null)
            return null;
        return set.FirstOrDefault(b => b.Id == cur.NextId);
    }
}
