using VanguardProtocol.AI.BehaviorTree;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Physics;

namespace VanguardProtocol.AI;

public struct AiControlled : IComponent
{
    public BehaviorNode? Root;
}

public static class WalkerBehavior
{
    public static BehaviorNode Create(float speed = 60f, float leftBound = 40f, float rightBound = 400f)
    {
        var direction = 1f;
        return new ActionNode((world, entity, _) =>
        {
            if (!world.TryGet<Transform>(entity, out var transform) ||
                !world.TryGet<Velocity>(entity, out var velocity))
                return BehaviorStatus.Failure;

            if (transform.Position.X <= leftBound)
                direction = 1f;
            else if (transform.Position.X >= rightBound)
                direction = -1f;

            velocity.Value.X = DeterministicMath.Quantize(direction * speed);
            world.GetStore<Velocity>().Set(entity, velocity);
            return BehaviorStatus.Running;
        });
    }
}

public static class TurretBehavior
{
    public static BehaviorNode Create(Func<World, Entity, bool> canSeePlayer, Action<World, Entity> fire)
    {
        return new Selector(
            new Sequence(
                new ConditionNode(canSeePlayer),
                new ActionNode((world, entity, _) =>
                {
                    fire(world, entity);
                    return BehaviorStatus.Success;
                })),
            new ActionNode((_, _, _) => BehaviorStatus.Success));
    }
}

public sealed class AiSystem : SystemBase
{
    public override int Order => SystemOrders.Ai;

    public override void Update(World world, float fixedDeltaSeconds)
    {
        var store = world.GetStore<AiControlled>();
        foreach (var (entity, ai) in store)
        {
            ai.Root?.Tick(world, entity, fixedDeltaSeconds);
            store.Set(entity, ai);
        }
    }
}

public struct BossComponent : IComponent
{
    public int Phase;
    public float PhaseElapsed;
    public int CurrentHealth;
    public int MaxHealth;
}

/// <summary>Advances boss phases from HP thresholds stored on <see cref="BossComponent"/>.</summary>
public sealed class BossPhaseSystem : SystemBase
{
    public override int Order => SystemOrders.Ai + 10;

    public override void Update(World world, float fixedDeltaSeconds)
    {
        var bosses = world.GetStore<BossComponent>();
        foreach (var (entity, boss) in bosses)
        {
            var copy = boss;
            var hpRatio = copy.MaxHealth <= 0 ? 0f : copy.CurrentHealth / (float)copy.MaxHealth;
            var phase = hpRatio switch
            {
                > 0.66f => 0,
                > 0.33f => 1,
                _ => 2,
            };

            if (phase != copy.Phase)
            {
                copy.Phase = phase;
                copy.PhaseElapsed = 0f;
            }
            else
            {
                copy.PhaseElapsed += fixedDeltaSeconds;
            }

            bosses.Set(entity, copy);
        }
    }
}
