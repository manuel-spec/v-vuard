using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.AI.BehaviorTree;

public sealed class Blackboard
{
    private readonly Dictionary<string, object> _values = new(StringComparer.Ordinal);

    public void Set<T>(string key, T value) where T : notnull => _values[key] = value;

    public bool TryGet<T>(string key, out T value)
    {
        if (_values.TryGetValue(key, out var obj) && obj is T typed)
        {
            value = typed;
            return true;
        }

        value = default!;
        return false;
    }

    public T GetOr<T>(string key, T fallback) => TryGet<T>(key, out var v) ? v : fallback;
    public bool Remove(string key) => _values.Remove(key);
    public void Clear() => _values.Clear();
}

public sealed class Inverter : BehaviorNode
{
    private readonly BehaviorNode _child;
    public Inverter(BehaviorNode child) => _child = child;

    public override BehaviorStatus Tick(World world, Entity entity, float dt)
    {
        var s = _child.Tick(world, entity, dt);
        return s switch
        {
            BehaviorStatus.Success => BehaviorStatus.Failure,
            BehaviorStatus.Failure => BehaviorStatus.Success,
            _ => s,
        };
    }
}

public sealed class Succeeder : BehaviorNode
{
    private readonly BehaviorNode _child;
    public Succeeder(BehaviorNode child) => _child = child;

    public override BehaviorStatus Tick(World world, Entity entity, float dt)
    {
        var s = _child.Tick(world, entity, dt);
        return s == BehaviorStatus.Running ? BehaviorStatus.Running : BehaviorStatus.Success;
    }
}

public sealed class Repeater : BehaviorNode
{
    private readonly BehaviorNode _child;
    private readonly int _times;
    private int _done;

    public Repeater(BehaviorNode child, int times)
    {
        _child = child;
        _times = Math.Max(1, times);
    }

    public override BehaviorStatus Tick(World world, Entity entity, float dt)
    {
        while (_done < _times)
        {
            var s = _child.Tick(world, entity, dt);
            if (s == BehaviorStatus.Running)
                return BehaviorStatus.Running;
            if (s == BehaviorStatus.Failure)
            {
                _done = 0;
                return BehaviorStatus.Failure;
            }

            _done++;
        }

        _done = 0;
        return BehaviorStatus.Success;
    }
}

public sealed class Cooldown : BehaviorNode
{
    private readonly BehaviorNode _child;
    private readonly float _seconds;
    private float _remaining;

    public Cooldown(BehaviorNode child, float seconds)
    {
        _child = child;
        _seconds = seconds;
    }

    public override BehaviorStatus Tick(World world, Entity entity, float dt)
    {
        if (_remaining > 0f)
        {
            _remaining -= dt;
            return BehaviorStatus.Failure;
        }

        var s = _child.Tick(world, entity, dt);
        if (s == BehaviorStatus.Success)
            _remaining = _seconds;
        return s;
    }
}

public sealed class Parallel : BehaviorNode
{
    private readonly BehaviorNode[] _children;
    private readonly int _successThreshold;

    public Parallel(int successThreshold, params BehaviorNode[] children)
    {
        _children = children;
        _successThreshold = Math.Clamp(successThreshold, 1, Math.Max(1, children.Length));
    }

    public override BehaviorStatus Tick(World world, Entity entity, float dt)
    {
        var success = 0;
        var running = false;
        foreach (var c in _children)
        {
            var s = c.Tick(world, entity, dt);
            if (s == BehaviorStatus.Success)
                success++;
            else if (s == BehaviorStatus.Running)
                running = true;
        }

        if (success >= _successThreshold)
            return BehaviorStatus.Success;
        return running ? BehaviorStatus.Running : BehaviorStatus.Failure;
    }
}
