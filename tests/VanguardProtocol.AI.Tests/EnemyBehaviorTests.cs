using VanguardProtocol.AI;
using VanguardProtocol.AI.BehaviorTree;
using VanguardProtocol.AI.EnemyBehaviors;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using Xunit;

namespace VanguardProtocol.AI.Tests;

public class EnemyBehaviorTests
{
    [Fact]
    public void BossCatalog_Advances_Phases()
    {
        var boss = BossCatalog.CreateAegisColossus();
        boss.Update(0.7f, 0.1f);
        Assert.Equal("intro", boss.Current.Id);
        boss.Update(0.5f, 0.1f);
        Assert.Equal("armor_break", boss.Current.Id);
    }

    [Fact]
    public void WalkerBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.WalkerBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void TurretBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.TurretBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void FlyerBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.FlyerBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void SpawnerBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.SpawnerBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void ShieldBearerBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.ShieldBearerBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void JumperBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.JumperBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void DiveBomberBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.DiveBomberBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void ShieldDroneBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.ShieldDroneBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void MortarBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.MortarBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }

    [Fact]
    public void ChargerBehavior_Builds_Tree()
    {
        var board = new Blackboard();
        board.Set("originX", 100f);
        var node = global::VanguardProtocol.AI.EnemyBehaviors.ChargerBehavior.Build(board);
        var world = new World();
        var e = world.CreateEntity();
        world.Add(e, new Transform(new System.Numerics.Vector2(100, 10)));
        world.Add(e, new Velocity());
        var status = node.Tick(world, e, 0.016f);
        Assert.True(status is BehaviorStatus.Running or BehaviorStatus.Success or BehaviorStatus.Failure);
    }
}

