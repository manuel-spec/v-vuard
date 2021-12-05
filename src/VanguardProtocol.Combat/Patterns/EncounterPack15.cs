namespace VanguardProtocol.Combat.Patterns;

public static class EncounterPack15
{
    public static readonly Shot[] Shots =
    [
        new Shot(0, 0f, 1, 0.10f),
        new Shot(1, 7f, 2, 0.15f),
        new Shot(2, 14f, 3, 0.20f),
        new Shot(3, 21f, 4, 0.25f),
        new Shot(4, 28f, 1, 0.30f),
        new Shot(5, 35f, 2, 0.10f),
        new Shot(6, 42f, 3, 0.15f),
        new Shot(7, 49f, 4, 0.20f),
        new Shot(8, 56f, 1, 0.25f),
        new Shot(9, 63f, 2, 0.30f),
        new Shot(10, 70f, 3, 0.10f),
        new Shot(11, 77f, 4, 0.15f),
        new Shot(12, 84f, 1, 0.20f),
        new Shot(13, 91f, 2, 0.25f),
        new Shot(14, 98f, 3, 0.30f),
        new Shot(15, 105f, 4, 0.10f),
        new Shot(16, 112f, 1, 0.15f),
        new Shot(17, 119f, 2, 0.20f),
        new Shot(18, 126f, 3, 0.25f),
        new Shot(19, 133f, 4, 0.30f),
        new Shot(20, 140f, 1, 0.10f),
        new Shot(21, 147f, 2, 0.15f),
        new Shot(22, 154f, 3, 0.20f),
        new Shot(23, 161f, 4, 0.25f),
        new Shot(24, 168f, 1, 0.30f),
        new Shot(25, 175f, 2, 0.10f),
        new Shot(26, 182f, 3, 0.15f),
        new Shot(27, 189f, 4, 0.20f),
        new Shot(28, 196f, 1, 0.25f),
        new Shot(29, 203f, 2, 0.30f),
        new Shot(30, 210f, 3, 0.10f),
        new Shot(31, 217f, 4, 0.15f),
        new Shot(32, 224f, 1, 0.20f),
        new Shot(33, 231f, 2, 0.25f),
        new Shot(34, 238f, 3, 0.30f),
        new Shot(35, 245f, 4, 0.10f),
        new Shot(36, 252f, 1, 0.15f),
        new Shot(37, 259f, 2, 0.20f),
        new Shot(38, 266f, 3, 0.25f),
        new Shot(39, 273f, 4, 0.30f)
    ];

    public static Shot[] Slice(int start, int count)
    {
        start = Math.Clamp(start, 0, Shots.Length);
        count = Math.Clamp(count, 0, Shots.Length - start);
        var arr = new Shot[count];
        Array.Copy(Shots, start, arr, 0, count);
        return arr;
    }
}
