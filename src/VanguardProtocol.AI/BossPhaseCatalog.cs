namespace VanguardProtocol.AI;

public sealed class BossPhaseDefinition
{
    public required string Id { get; init; }
    public float HealthThreshold01 { get; init; }
    public string AttackPatternId { get; init; } = "volley";
    public float AttackInterval { get; init; } = 1.2f;
    public bool LockCamera { get; init; } = true;
}

/// <summary>HP-threshold phase controller used by authored boss encounters.</summary>
public sealed class BossPhaseController
{
    private readonly BossPhaseDefinition[] _phases;
    private int _index;
    private float _attackCooldown;

    public BossPhaseController(params BossPhaseDefinition[] phases)
    {
        _phases = phases.OrderByDescending(p => p.HealthThreshold01).ToArray();
        if (_phases.Length == 0)
            throw new ArgumentException("Need phases");
    }

    public BossPhaseDefinition Current => _phases[Math.Clamp(_index, 0, _phases.Length - 1)];
    public int PhaseIndex => _index;
    public string? LastTriggeredAttack { get; private set; }

    public void Update(float health01, float dt)
    {
        while (_index + 1 < _phases.Length && health01 <= _phases[_index + 1].HealthThreshold01)
            _index++;

        _attackCooldown -= dt;
        if (_attackCooldown <= 0f)
        {
            LastTriggeredAttack = Current.AttackPatternId;
            _attackCooldown = Current.AttackInterval;
        }
        else
        {
            LastTriggeredAttack = null;
        }
    }
}

public static class BossCatalog
{
    public static BossPhaseController CreateAegisColossus() => new(
        new BossPhaseDefinition { Id = "intro", HealthThreshold01 = 1f, AttackPatternId = "slam", AttackInterval = 1.6f },
        new BossPhaseDefinition { Id = "armor_break", HealthThreshold01 = 0.66f, AttackPatternId = "missile_fan", AttackInterval = 1.2f },
        new BossPhaseDefinition { Id = "overdrive", HealthThreshold01 = 0.33f, AttackPatternId = "laser_sweep", AttackInterval = 0.85f }
    );

    public static BossPhaseController CreateSkyHydra() => new(
        new BossPhaseDefinition { Id = "hover", HealthThreshold01 = 1f, AttackPatternId = "dive", AttackInterval = 1.4f },
        new BossPhaseDefinition { Id = "split", HealthThreshold01 = 0.5f, AttackPatternId = "ring_shot", AttackInterval = 1.0f },
        new BossPhaseDefinition { Id = "frenzy", HealthThreshold01 = 0.2f, AttackPatternId = "chaos_rain", AttackInterval = 0.7f }
    );
}

public static class BossAttackPatterns
{
    public static IReadOnlyList<float> AnglesFor(string patternId) => patternId switch
    {
        "slam" => [0f, 12f, -12f],
        "missile_fan" => [-30f, -15f, 0f, 15f, 30f],
        "laser_sweep" => [-40f, -20f, 0f, 20f, 40f],
        "dive" => [90f],
        "ring_shot" => [0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f],
        "chaos_rain" => [-60f, -30f, 0f, 30f, 60f, 90f],
        "volley" => [-10f, 0f, 10f],
        "beam_cross" => [0f, 90f, 180f, 270f],
        "ground_wave" => [0f, 8f, -8f, 16f, -16f],
        "spore_burst" => [0f, 60f, 120f, 180f, 240f, 300f],
        _ => [0f],
    };
}
