namespace VanguardProtocol.Core.Profiling;

/// <summary>
/// Lightweight per-system timing counters for local diagnostics.
/// Not used for simulation decisions (wall clock would break determinism).
/// </summary>
public sealed class FrameProfiler
{
    private readonly Dictionary<string, Sample> _samples = new(StringComparer.Ordinal);
    private string? _active;
    private long _activeStart;

    public void Begin(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        if (_active is not null)
            End();
        _active = name;
        _activeStart = System.Diagnostics.Stopwatch.GetTimestamp();
    }

    public void End()
    {
        if (_active is null)
            return;

        var elapsed = System.Diagnostics.Stopwatch.GetTimestamp() - _activeStart;
        if (!_samples.TryGetValue(_active, out var sample))
            sample = new Sample(_active);

        sample.Calls++;
        sample.Ticks += elapsed;
        if (elapsed > sample.MaxTicks)
            sample.MaxTicks = elapsed;
        _samples[_active] = sample;
        _active = null;
    }

    public void IncrementCounter(string name, int amount = 1)
    {
        if (!_samples.TryGetValue(name, out var sample))
            sample = new Sample(name);
        sample.Counter += amount;
        _samples[name] = sample;
    }

    public IReadOnlyList<ProfilerSnapshot> SnapshotAndReset()
    {
        if (_active is not null)
            End();

        var freq = (double)System.Diagnostics.Stopwatch.Frequency;
        var list = new List<ProfilerSnapshot>(_samples.Count);
        foreach (var sample in _samples.Values)
        {
            list.Add(new ProfilerSnapshot(
                sample.Name,
                sample.Calls,
                sample.Ticks / freq * 1000.0,
                sample.MaxTicks / freq * 1000.0,
                sample.Counter));
        }

        list.Sort(static (a, b) => b.TotalMilliseconds.CompareTo(a.TotalMilliseconds));
        _samples.Clear();
        return list;
    }

    private struct Sample
    {
        public Sample(string name)
        {
            Name = name;
            Calls = 0;
            Ticks = 0;
            MaxTicks = 0;
            Counter = 0;
        }

        public string Name;
        public int Calls;
        public long Ticks;
        public long MaxTicks;
        public int Counter;
    }
}

public readonly record struct ProfilerSnapshot(
    string Name,
    int Calls,
    double TotalMilliseconds,
    double MaxMilliseconds,
    int Counter);
