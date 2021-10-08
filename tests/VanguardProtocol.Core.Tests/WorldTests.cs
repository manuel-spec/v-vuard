using VanguardProtocol.Core;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Core.Ecs.Events;

namespace VanguardProtocol.Core.Tests;

public class WorldTests
{
    private struct Health : IComponent
    {
        public int Value;
    }

    [Fact]
    public void Create_Add_Get_Destroy_Works()
    {
        var world = new World();
        var a = world.CreateEntity();
        var b = world.CreateEntity();

        Assert.True(world.IsAlive(a));
        Assert.True(world.IsAlive(b));
        Assert.Equal(2, world.EntityCount);

        world.Add(a, new Health { Value = 3 });
        Assert.True(world.Has<Health>(a));
        Assert.Equal(3, world.Get<Health>(a).Value);

        Assert.True(world.DestroyEntity(a));
        Assert.False(world.IsAlive(a));
        Assert.False(world.Has<Health>(a));
        Assert.Equal(1, world.EntityCount);

        var c = world.CreateEntity();
        Assert.Equal(a.Index, c.Index);
        Assert.NotEqual(a.Generation, c.Generation);
        Assert.False(world.Has<Health>(c));
    }

    [Fact]
    public void ComponentStore_DenseIteration_IsStable()
    {
        var world = new World();
        for (var i = 0; i < 10; i++)
        {
            var e = world.CreateEntity();
            world.Add(e, new Health { Value = i });
        }

        var sum = 0;
        foreach (var (_, health) in world.GetStore<Health>())
            sum += health.Value;

        Assert.Equal(45, sum);
    }
}

public class GameLoopTests
{
    [Fact]
    public void Tick_AdvancesFixedSteps()
    {
        var loop = new GameLoop(1f / 60f, maxStepsPerFrame: 8);
        var steps = 0;
        var ran = loop.Tick(1f / 30f, () => steps++);
        Assert.Equal(2, ran);
        Assert.Equal(2, steps);
        Assert.Equal(2ul, loop.SimulationTick);
    }

    [Fact]
    public void Tick_CapsSpiral()
    {
        var loop = new GameLoop(1f / 60f, maxStepsPerFrame: 3);
        var steps = loop.Tick(1f, () => { });
        Assert.Equal(3, steps);
    }
}

public class SystemSchedulerTests
{
    private sealed class OrderedSystem(int order, List<int> log) : SystemBase
    {
        public override int Order => order;
        public override void Update(World world, float fixedDeltaSeconds) => log.Add(order);
    }

    [Fact]
    public void Tick_RunsInAscendingOrder()
    {
        var log = new List<int>();
        var scheduler = new SystemScheduler();
        scheduler.Add(new OrderedSystem(300, log));
        scheduler.Add(new OrderedSystem(100, log));
        scheduler.Add(new OrderedSystem(200, log));

        scheduler.Tick(new World(), 1f / 60f);
        Assert.Equal([100, 200, 300], log);
    }
}

public class EventBusTests
{
    private readonly struct Ping(int value) : IEvent
    {
        public int Value { get; } = value;
    }

    [Fact]
    public void Publish_InvokesSubscribers()
    {
        var bus = new EventBus();
        var seen = 0;
        bus.Subscribe<Ping>(p => seen += p.Value);
        bus.Publish(new Ping(4));
        Assert.Equal(4, seen);
    }
}

public class InputBufferTests
{
    [Fact]
    public void ConsumedPress_LooksBackAndClears()
    {
        var buffer = new InputBuffer(4);
        buffer.Push(InputButtons.None);
        buffer.Push(InputButtons.Jump);
        buffer.Push(InputButtons.None);

        Assert.True(buffer.ConsumedPress(InputButtons.Jump, 3));
        Assert.False(buffer.ConsumedPress(InputButtons.Jump, 3));
    }
}
