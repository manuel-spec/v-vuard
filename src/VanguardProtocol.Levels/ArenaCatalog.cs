using VanguardProtocol.Levels.Content.Arenas;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels;

/// <summary>
/// Resolves raw arena builders by index so campaign code can load them without
/// hard-coding every type name at call sites.
/// </summary>
public static class ArenaCatalog
{
    public const int Count = 400;

    public static LevelData Build(int arenaNumber)
    {
        if (arenaNumber is < 1 or > Count)
            throw new ArgumentOutOfRangeException(nameof(arenaNumber), arenaNumber, $"Arena must be 1..{Count}.");

        return arenaNumber switch
        {
            1 => Arena01.Build(),
            2 => Arena02.Build(),
            3 => Arena03.Build(),
            4 => Arena04.Build(),
            5 => Arena05.Build(),
            6 => Arena06.Build(),
            7 => Arena07.Build(),
            8 => Arena08.Build(),
            9 => Arena09.Build(),
            10 => Arena10.Build(),
            11 => Arena11.Build(),
            12 => Arena12.Build(),
            13 => Arena13.Build(),
            14 => Arena14.Build(),
            15 => Arena15.Build(),
            16 => Arena16.Build(),
            17 => Arena17.Build(),
            18 => Arena18.Build(),
            19 => Arena19.Build(),
            20 => Arena20.Build(),
            21 => Arena21.Build(),
            22 => Arena22.Build(),
            23 => Arena23.Build(),
            24 => Arena24.Build(),
            25 => Arena25.Build(),
            26 => Arena26.Build(),
            27 => Arena27.Build(),
            28 => Arena28.Build(),
            29 => Arena29.Build(),
            30 => Arena30.Build(),
            _ => BuildByReflection(arenaNumber),
        };
    }

    private static LevelData BuildByReflection(int arenaNumber)
    {
        var typeName = $"VanguardProtocol.Levels.Content.Arenas.Arena{arenaNumber}";
        var type = Type.GetType(typeName + ", VanguardProtocol.Levels")
                   ?? AppDomain.CurrentDomain.GetAssemblies()
                       .Select(a => a.GetType(typeName))
                       .FirstOrDefault(t => t is not null);
        if (type is null)
            throw new InvalidOperationException($"Missing arena type Arena{arenaNumber}.");

        var method = type.GetMethod("Build", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        if (method is null)
            throw new InvalidOperationException($"Arena{arenaNumber} has no Build().");

        return (LevelData)method.Invoke(null, null)!;
    }
}
