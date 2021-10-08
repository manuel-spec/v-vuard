namespace VanguardProtocol.Core;

/// <summary>
/// Fixed-timestep accumulator. Variable render delta feeds the accumulator; simulation
/// advances in constant steps — required for deterministic lockstep netcode.
/// </summary>
public sealed class GameLoop
{
    public const float DefaultFixedDeltaSeconds = 1f / 60f;
    public const int DefaultMaxStepsPerFrame = 5;

    private float _accumulator;

    public GameLoop(float fixedDeltaSeconds = DefaultFixedDeltaSeconds, int maxStepsPerFrame = DefaultMaxStepsPerFrame)
    {
        if (fixedDeltaSeconds <= 0f)
            throw new ArgumentOutOfRangeException(nameof(fixedDeltaSeconds));
        if (maxStepsPerFrame < 1)
            throw new ArgumentOutOfRangeException(nameof(maxStepsPerFrame));

        FixedDeltaSeconds = fixedDeltaSeconds;
        MaxStepsPerFrame = maxStepsPerFrame;
    }

    public float FixedDeltaSeconds { get; }
    public int MaxStepsPerFrame { get; }
    public ulong SimulationTick { get; private set; }
    public float Alpha { get; private set; }

    public int Tick(float frameDeltaSeconds, Action fixedUpdate)
    {
        ArgumentNullException.ThrowIfNull(fixedUpdate);

        // Clamp huge stalls (alt-tab) so we do not spiral.
        if (frameDeltaSeconds > 0.25f)
            frameDeltaSeconds = 0.25f;

        _accumulator += frameDeltaSeconds;
        var steps = 0;

        while (_accumulator >= FixedDeltaSeconds && steps < MaxStepsPerFrame)
        {
            fixedUpdate();
            _accumulator -= FixedDeltaSeconds;
            SimulationTick++;
            steps++;
        }

        if (steps == MaxStepsPerFrame)
            _accumulator = 0f;

        Alpha = _accumulator / FixedDeltaSeconds;
        return steps;
    }

    public void Reset()
    {
        _accumulator = 0f;
        SimulationTick = 0;
        Alpha = 0f;
    }
}
