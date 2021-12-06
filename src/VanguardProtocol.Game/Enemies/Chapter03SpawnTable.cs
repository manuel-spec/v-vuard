namespace VanguardProtocol.Game.Enemies;

public static class Chapter03SpawnTable
{
    public sealed record Spawn(string Archetype, int X, int Y, int Hp);

    public static Spawn[] ForStage(int stage)
    {
        var list = new List<Spawn>();
        var archetypes = new[] { "walker", "turret", "flyer", "spawner", "jumper" };
        var count = 7 + stage * 2;
        for (var i = 0; i < count; i++)
            list.Add(new Spawn(archetypes[i % archetypes.Length], 20 + i * 12, 10 + (i % 3) * 2, 2 + (i % 4)));
        return list.ToArray();
    }
}
