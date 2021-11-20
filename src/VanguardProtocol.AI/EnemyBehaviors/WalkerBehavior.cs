using System.Numerics;
using VanguardProtocol.AI.BehaviorTree;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Physics;

namespace VanguardProtocol.AI.EnemyBehaviors;

public static class WalkerBehavior
{
    public static BehaviorNode Build(Blackboard board)
    {
        return new Selector(
            new Sequence(
                new ConditionNode((w, e) => board.GetOr("aggro", false)),
                new Cooldown(new ActionNode((w, e, dt) => Attack(w, e, dt, board)), 0.70f)
            ),
            new ActionNode((w, e, dt) => Patrol(w, e, dt, board))
        );
    }

    private static BehaviorStatus Patrol(World world, Entity entity, float dt, Blackboard board)
    {
        if (!world.Has<Transform>(entity) || !world.Has<Velocity>(entity))
            return BehaviorStatus.Failure;

        ref var t = ref world.Get<Transform>(entity);
        ref var v = ref world.Get<Velocity>(entity);
        var dir = board.GetOr("patrolDir", 1);
        v.Value = DeterministicMath.Quantize(new Vector2(dir * 58f, v.Value.Y));
        var origin = board.GetOr("originX", t.Position.X);
        if (MathF.Abs(t.Position.X - origin) > board.GetOr("patrolRange", 80f))
            board.Set("patrolDir", -dir);
        return BehaviorStatus.Running;
    }

    private static BehaviorStatus Attack(World world, Entity entity, float dt, Blackboard board)
    {
        board.Set("wantsShoot", true);
        board.Set("lastAttack", board.GetOr("lastAttack", 0f) + dt);
        return BehaviorStatus.Success;
    }
}
