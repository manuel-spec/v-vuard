using System.Numerics;
using VanguardProtocol.Combat.Weapons;
using VanguardProtocol.Core.Components;
using VanguardProtocol.Core.Ecs;
using VanguardProtocol.Physics;

namespace VanguardProtocol.Combat.Pickups;

public sealed class PickupSystem : SystemBase
{
    public override int Order => SystemOrders.Combat + 20;
    public int Collected { get; private set; }

    public override void Update(World world, float fixedDeltaSeconds)
    {
        var pickups = world.GetStore<PickupComponent>();
        var weapons = world.GetStore<WeaponComponent>();
        var transforms = world.GetStore<Transform>();

        var weaponEntities = weapons.EntitiesSpan().ToArray();
        var pickupEntities = pickups.EntitiesSpan().ToArray();
        var pickupComps = pickups.AsSpan().ToArray();

        foreach (var player in weaponEntities)
        {
            if (!transforms.TryGet(player, out var pt))
                continue;
            var playerBox = Aabb.FromCenter(pt.Position, new Vector2(14f, 22f));
            for (var i = 0; i < pickupEntities.Length; i++)
            {
                var pickupEntity = pickupEntities[i];
                if (!world.IsAlive(pickupEntity))
                    continue;
                if (!transforms.TryGet(pickupEntity, out var pk))
                    continue;
                var box = Aabb.FromCenter(pk.Position, new Vector2(12f, 12f));
                if (!playerBox.Intersects(box))
                    continue;

                Apply(world, player, pickupComps[i]);
                world.DestroyEntity(pickupEntity);
                Collected++;
            }
        }
    }

    private static void Apply(World world, Entity player, PickupComponent pickup)
    {
        switch (pickup.Kind)
        {
            case PickupKind.Health:
                if (world.Has<HealthComponent>(player))
                {
                    ref var h = ref world.Get<HealthComponent>(player);
                    h.Current = Math.Min(h.Max, h.Current + Math.Max(1, pickup.Amount));
                }
                break;
            case PickupKind.Weapon:
                if (pickup.WeaponId is not null && world.Has<WeaponComponent>(player))
                {
                    ref var weapon = ref world.Get<WeaponComponent>(player);
                    weapon.Definition = WeaponCatalog.GetOrPulse(pickup.WeaponId);
                    weapon.Cooldown = 0f;
                }
                break;
        }
    }
}
