using System.Numerics;
using VanguardProtocol.AI;
using VanguardProtocol.Combat;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Levels;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Levels.Tests;

public sealed class CampaignClearabilityTests
{
    private const float MoveSpeed = 160f;
    private const float JumpSpeed = 420f;
    private const float Dt = 1f / 60f;

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(20)]
    [InlineData(25)]
    public void Campaign_stage_scripted_run_reaches_exit(int stageIndex)
    {
        Assert.True(TryClear(stageIndex, out var reason), reason);
    }

    [Fact]
    public void Campaign_roster_has_twenty_five_playable_stages()
    {
        Assert.Equal(25, CampaignRoster.StageCount);
        Assert.Equal(25, CampaignRoster.All.Count);
        for (var i = 1; i <= 25; i++)
        {
            var stage = CampaignRoster.Get(i);
            var level = stage.Build();
            Assert.Equal(stage.Id, level.Name);
            Assert.Contains(level.Triggers, t => t.Kind == TriggerKind.LevelExit);
            Assert.Contains(level.Spawns, s => s.Type.Equals("Player", StringComparison.OrdinalIgnoreCase));
            Assert.True(TryClear(i, out var reason), $"Stage {i} ({stage.Title}): {reason}");
        }
    }

    private static bool TryClear(int stageIndex, out string reason)
    {
        var stage = CampaignRoster.Get(stageIndex);
        var level = stage.Build();
        var collision = LevelLoader.LoadCollision(level);
        var world = new World();

        var physics = new PhysicsSystem();
        physics.SetTilemap(collision);
        var projectiles = new ProjectileSystem();
        projectiles.SetTilemap(collision);
        var weapons = new WeaponSystem();
        var contact = new ContactDamageSystem();
        var damage = new DamageSystem();
        var pickups = new PickupSystem();
        var ai = new AiSystem();
        var buffer = new InputBuffer();

        var spawn = level.Spawns.First(s => s.Type.Equals("Player", StringComparison.OrdinalIgnoreCase));
        var player = CreatePlayer(world, new Vector2(spawn.X, spawn.Y));
        SpawnEntities(world, level);

        var exit = level.Triggers.First(t => t.Kind == TriggerKind.LevelExit);
        var prevButtons = InputButtons.None;
        var maxTicks = 60 * 90;

        for (var tick = 0; tick < maxTicks; tick++)
        {
            var buttons = InputButtons.Right | InputButtons.Shoot;
            if (world.TryGet<Transform>(player, out var t) &&
                world.TryGet<RigidBody>(player, out var body) &&
                body.OnGround &&
                GapAhead(collision, t.Position.X, body.Size.X))
            {
                buttons |= InputButtons.Jump;
            }

            var frame = InputFrame.FromEdges(prevButtons, buttons);
            prevButtons = buttons;
            buffer.Push(frame.Pressed);

            ApplyPlayerInput(world, player, frame, buffer);
            weapons.SetInput(frame);
            ai.Update(world, Dt);
            physics.Update(world, Dt);
            weapons.Update(world, Dt);
            projectiles.Update(world, Dt);
            contact.Update(world, Dt);
            if (contact.HitsThisTick.Count > 0)
                damage.EnqueueRange(contact.HitsThisTick);
            if (projectiles.DamageThisTick.Count > 0)
                damage.EnqueueRange(projectiles.DamageThisTick);
            damage.Update(world, Dt);
            pickups.Update(world, Dt);
            UpdateFacing(world, player);

            if (!world.TryGet<HealthComponent>(player, out var hp) || hp.Current <= 0)
            {
                reason = $"died at tick {tick}";
                return false;
            }

            if (!world.TryGet<Transform>(player, out var pos) || !world.TryGet<RigidBody>(player, out var rb))
            {
                reason = "missing transform";
                return false;
            }

            if (pos.Position.Y > level.Height * level.TileSize + 48)
            {
                reason = $"fell at x={pos.Position.X:F1}";
                return false;
            }

            var box = new Aabb(pos.Position.X, pos.Position.Y, rb.Size.X, rb.Size.Y);
            var zone = new Aabb(exit.X, exit.Y, exit.Width, exit.Height);
            if (box.Intersects(zone))
            {
                reason = "ok";
                return true;
            }
        }

        var lastX = world.TryGet<Transform>(player, out var final) ? final.Position.X : -1f;
        reason = $"timeout lastX={lastX:F1} exitX={exit.X:F1}";
        return false;
    }

    private static bool GapAhead(CollisionTilemap map, float x, float width)
    {
        var probe = x + width + 8f;
        var tx = (int)(probe / map.TileSize);
        var floorRow = map.Height - 2;
        return (map.Get(tx, floorRow) & TileFlags.Solid) == 0;
    }

    private static Entity CreatePlayer(World world, Vector2 position)
    {
        var entity = world.CreateEntity();
        var size = new Vector2(14, 22);
        world.Add(entity, new Transform(position));
        world.Add(entity, new Velocity(Vector2.Zero));
        world.Add(entity, new RigidBody(size));
        world.Add(entity, new PlayerControlled(0));
        world.Add(entity, new HealthComponent(3));
        world.Add(entity, new WeaponComponent { Definition = WeaponDefinition.PulseRifle, Facing = 1 });
        return entity;
    }

    private static void SpawnEntities(World world, LevelData level)
    {
        foreach (var spawn in level.Spawns)
        {
            var type = spawn.Type.ToLowerInvariant();
            if (type is "player")
                continue;

            if (type is "walker" or "flyer")
            {
                var hp = spawn.Properties is not null && spawn.Properties.TryGetValue("hp", out var raw) && int.TryParse(raw, out var v) ? v : 1;
                var left = ParseFloat(spawn, "left", spawn.X - 40);
                var right = ParseFloat(spawn, "right", spawn.X + 40);
                var enemy = world.CreateEntity();
                var size = type == "flyer" ? new Vector2(18, 14) : new Vector2(16, 22);
                world.Add(enemy, new Transform(new Vector2(spawn.X, spawn.Y)));
                world.Add(enemy, new Velocity(Vector2.Zero));
                world.Add(enemy, new RigidBody(size, affectedByGravity: type != "flyer"));
                world.Add(enemy, new HealthComponent(Math.Max(1, hp)));
                world.Add(enemy, new EnemyTag { TouchDamage = 1 });
                world.Add(enemy, new AiControlled
                {
                    Root = type == "flyer"
                        ? FlyerHoverBehavior.Create(55f, left, right)
                        : WalkerBehavior.Create(45f, left, right),
                });
            }
        }
    }

    private static float ParseFloat(EntitySpawn spawn, string key, float fallback) =>
        spawn.Properties is not null && spawn.Properties.TryGetValue(key, out var raw) && float.TryParse(raw, out var v) ? v : fallback;

    private static void ApplyPlayerInput(World world, Entity player, InputFrame frame, InputBuffer buffer)
    {
        if (!world.TryGet<Velocity>(player, out var velocity) || !world.TryGet<RigidBody>(player, out var body))
            return;

        var axis = 0f;
        if (frame.IsDown(InputButtons.Left))
            axis -= 1f;
        if (frame.IsDown(InputButtons.Right))
            axis += 1f;
        velocity.Value.X = DeterministicMath.Quantize(axis * MoveSpeed);

        var wantsJump = frame.WasPressed(InputButtons.Jump) ||
                        buffer.ConsumedPress(InputButtons.Jump, lookbackFrames: 6);
        if (wantsJump && body.OnGround)
        {
            velocity.Value.Y = DeterministicMath.Quantize(-JumpSpeed);
            body.OnGround = false;
            world.GetStore<RigidBody>().Set(player, body);
        }

        world.GetStore<Velocity>().Set(player, velocity);
    }

    private static void UpdateFacing(World world, Entity player)
    {
        if (!world.TryGet<WeaponComponent>(player, out var weapon) || !world.TryGet<Velocity>(player, out var velocity))
            return;
        if (velocity.Value.X > 1f)
            weapon.Facing = 1;
        else if (velocity.Value.X < -1f)
            weapon.Facing = -1;
        world.GetStore<WeaponComponent>().Set(player, weapon);
    }
}
