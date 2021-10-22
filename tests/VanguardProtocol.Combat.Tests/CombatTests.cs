using System.Numerics;
using VanguardProtocol.Combat;
using VanguardProtocol.Core;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Combat.Tests;

public class WeaponSystemTests
{
    [Fact]
    public void Firing_SpawnsProjectilePattern()
    {
        var world = new World();
        var player = world.CreateEntity();
        world.Add(player, new Transform(new Vector2(10, 10)));
        world.Add(player, new PlayerControlled(0));
        world.Add(player, new WeaponComponent
        {
            Definition = WeaponDefinition.SpreadCannon,
            Cooldown = 0f,
            Facing = 1,
        });

        var weapons = new WeaponSystem();
        weapons.SetInput(new InputFrame
        {
            Buttons = InputButtons.Shoot,
            Pressed = InputButtons.Shoot,
        });
        weapons.Update(world, 1f / 60f);

        Assert.Equal(3, world.GetStore<ProjectileComponent>().Count);
    }
}

public class DamageSystemTests
{
    [Fact]
    public void Damage_ReducesHealthAndDestroysNonPlayers()
    {
        var world = new World();
        var enemy = world.CreateEntity();
        world.Add(enemy, new HealthComponent(2));

        var damage = new DamageSystem();
        damage.Enqueue(new DamageEvent(enemy, Entity.None, 1));
        damage.Update(world, 1f / 60f);
        Assert.Equal(1, world.Get<HealthComponent>(enemy).Current);

        damage.Enqueue(new DamageEvent(enemy, Entity.None, 1));
        damage.Update(world, 1f / 60f);
        Assert.False(world.IsAlive(enemy));
    }
}
