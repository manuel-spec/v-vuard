namespace VanguardProtocol.Combat.Weapons;

/// <summary>Lookup table of starter and unlockable weapons (original IDs only).</summary>
public static class WeaponCatalog
{
    private static readonly Dictionary<string, WeaponDefinition> Map = Build();

    public static IReadOnlyDictionary<string, WeaponDefinition> All => Map;

    public static bool TryGet(string id, out WeaponDefinition definition) =>
        Map.TryGetValue(id, out definition!);

    public static WeaponDefinition GetOrPulse(string id) =>
        TryGet(id, out var d) ? d : WeaponDefinition.PulseRifle;

    private static Dictionary<string, WeaponDefinition> Build()
    {
        var defs = new List<WeaponDefinition>
        {
            WeaponDefinition.PulseRifle,
            WeaponDefinition.SpreadCannon,
            WeaponDefinition.NeedleGun,
        };

        string[] extra =
        [
            "arc_beam","seeker_rocket","wave_blaster","tri_flare","ion_lance","magma_burst",
            "frost_needle","thunder_coil","shadow_dart","solar_fan","grav_spike","helix_shot",
            "nova_flare","razor_disc","plasma_arc","ember_spray","quake_slug","volt_fan",
            "cryo_lance","photon_drill","aether_burst","pulse_fan","shard_burst","orbit_drill"
        ];

        for (var i = 0; i < extra.Length; i++)
        {
            defs.Add(new WeaponDefinition
            {
                Id = extra[i],
                FireIntervalSeconds = 0.10f + (i % 8) * 0.03f,
                ProjectileSpeed = 280f + i * 10f,
                Damage = 1 + (i % 4),
                ProjectileCount = 1 + (i % 5),
                SpreadDegrees = (i % 6) * 5f,
                ProjectileRadius = 2f + (i % 3),
                LifetimeSeconds = 0.9f + (i % 5) * 0.2f,
                ColorRgba = 0xFF000000u | (uint)((0x40 + i * 9) << 16) | (uint)((0x70 + i * 5) << 8) | (uint)(0x90 + i * 3),
            });
        }

        return defs.ToDictionary(d => d.Id, StringComparer.Ordinal);
    }
}

public static class WeaponFireMath
{
    public static System.Numerics.Vector2 DirectionFromFacing(int facing, float angleDegrees)
    {
        var baseAngle = facing < 0 ? 180f : 0f;
        var rad = (baseAngle + angleDegrees) * (MathF.PI / 180f);
        return Physics.DeterministicMath.Quantize(new System.Numerics.Vector2(MathF.Cos(rad), MathF.Sin(rad)));
    }

    public static IEnumerable<(float AngleDeg, float SpeedScale)> BuildSpread(int count, float spreadDegrees)
    {
        if (count <= 1)
        {
            yield return (0f, 1f);
            yield break;
        }

        var start = -spreadDegrees * 0.5f;
        var step = spreadDegrees / (count - 1);
        for (var i = 0; i < count; i++)
            yield return (start + step * i, 1f);
    }

    public static IEnumerable<(float AngleDeg, float SpeedScale)> BuildRing(int count)
    {
        for (var i = 0; i < count; i++)
            yield return (360f * i / Math.Max(1, count), 1f);
    }
}
