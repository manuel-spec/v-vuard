using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Animation;

public sealed class AnimationSystem : SystemBase
{
    public override int Order => SystemOrders.Animation;

    public FrameEventHandler? FrameEvent { get; set; }

    public override void Update(World world, float fixedDeltaSeconds)
    {
        var store = world.GetStore<AnimationComponent>();
        foreach (var (entity, component) in store)
        {
            if (component.StateMachine is null)
                continue;

            var events = component.StateMachine.Update(fixedDeltaSeconds);
            for (var i = 0; i < events.Count; i++)
                FrameEvent?.Invoke(entity, events[i]);

            store.Set(entity, component);
        }
    }
}
