using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.AI.BehaviorTree;

public enum BehaviorStatus : byte
{
    Success = 0,
    Failure = 1,
    Running = 2,
}

public abstract class BehaviorNode
{
    public abstract BehaviorStatus Tick(World world, Entity entity, float dt);
}

public sealed class Sequence : BehaviorNode
{
    private readonly BehaviorNode[] _children;
    private int _index;

    public Sequence(params BehaviorNode[] children) => _children = children;

    public override BehaviorStatus Tick(World world, Entity entity, float dt)
    {
        while (_index < _children.Length)
        {
            var status = _children[_index].Tick(world, entity, dt);
            if (status == BehaviorStatus.Running)
                return BehaviorStatus.Running;
            if (status == BehaviorStatus.Failure)
            {
                _index = 0;
                return BehaviorStatus.Failure;
            }

            _index++;
        }

        _index = 0;
        return BehaviorStatus.Success;
    }
}

public sealed class Selector : BehaviorNode
{
    private readonly BehaviorNode[] _children;
    private int _index;

    public Selector(params BehaviorNode[] children) => _children = children;

    public override BehaviorStatus Tick(World world, Entity entity, float dt)
    {
        while (_index < _children.Length)
        {
            var status = _children[_index].Tick(world, entity, dt);
            if (status == BehaviorStatus.Running)
                return BehaviorStatus.Running;
            if (status == BehaviorStatus.Success)
            {
                _index = 0;
                return BehaviorStatus.Success;
            }

            _index++;
        }

        _index = 0;
        return BehaviorStatus.Failure;
    }
}

public sealed class ConditionNode : BehaviorNode
{
    private readonly Func<World, Entity, bool> _predicate;

    public ConditionNode(Func<World, Entity, bool> predicate) => _predicate = predicate;

    public override BehaviorStatus Tick(World world, Entity entity, float dt) =>
        _predicate(world, entity) ? BehaviorStatus.Success : BehaviorStatus.Failure;
}

public sealed class ActionNode : BehaviorNode
{
    private readonly Func<World, Entity, float, BehaviorStatus> _action;

    public ActionNode(Func<World, Entity, float, BehaviorStatus> action) => _action = action;

    public override BehaviorStatus Tick(World world, Entity entity, float dt) =>
        _action(world, entity, dt);
}
