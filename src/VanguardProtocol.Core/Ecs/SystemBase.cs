namespace VanguardProtocol.Core.Ecs;

public abstract class SystemBase
{
    /// <summary>Lower values run earlier. Deterministic lockstep relies on a fixed order.</summary>
    public abstract int Order { get; }

    public abstract void Update(World world, float fixedDeltaSeconds);
}

/// <summary>Executes registered systems in ascending <see cref="SystemBase.Order"/> every simulation tick.</summary>
public sealed class SystemScheduler
{
    private readonly List<SystemBase> _systems = new();
    private bool _sorted;

    public IReadOnlyList<SystemBase> Systems => _systems;

    public void Add(SystemBase system)
    {
        ArgumentNullException.ThrowIfNull(system);
        _systems.Add(system);
        _sorted = false;
    }

    public bool Remove(SystemBase system) => _systems.Remove(system);

    public void Clear()
    {
        _systems.Clear();
        _sorted = true;
    }

    public void Tick(World world, float fixedDeltaSeconds)
    {
        EnsureSorted();
        world.AdvanceTick();
        for (var i = 0; i < _systems.Count; i++)
            _systems[i].Update(world, fixedDeltaSeconds);
    }

    private void EnsureSorted()
    {
        if (_sorted)
            return;

        _systems.Sort(static (a, b) => a.Order.CompareTo(b.Order));
        _sorted = true;
    }
}

/// <summary>Canonical simulation pipeline order (architecture §3).</summary>
public static class SystemOrders
{
    public const int Input = 100;
    public const int Ai = 200;
    public const int Physics = 300;
    public const int Combat = 400;
    public const int Animation = 500;
    public const int Camera = 600;
    public const int NetcodeSync = 700;
    public const int Render = 800;
}
