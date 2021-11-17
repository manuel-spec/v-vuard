using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Combat.Damage;

public struct Invulnerability : IComponent
{
    public float RemainingSeconds;
}

public struct Hurtbox : IComponent
{
    public float Width;
    public float Height;
    public float OffsetX;
    public float OffsetY;
    public float DamageMultiplier;
}

public struct WeakPoint : IComponent
{
    public float Multiplier;
    public bool Exposed;
}

public sealed class DamageSystem : SystemBase
{
    private readonly List<DamageEvent> _applied = new();

    public override int Order => SystemOrders.Combat + 10;
    public int AppliedHits { get; private set; }
    public IReadOnlyList<DamageEvent> AppliedThisTick => _applied;

    public override void Update(World world, float fixedDeltaSeconds)
    {
        _applied.Clear();
        var store = world.GetStore<Invulnerability>();
        var entities = store.EntitiesSpan();
        var comps = store.AsSpan();
        for (var i = comps.Length - 1; i >= 0; i--)
        {
            var entity = entities[i];
            var next = comps[i];
            next.RemainingSeconds -= fixedDeltaSeconds;
            if (next.RemainingSeconds <= 0f)
                store.Remove(entity);
            else
                store.Set(entity, next);
        }
    }

    public bool TryApply(World world, Entity target, Entity source, int amount, float invulnSeconds = 0.4f)
    {
        if (!world.IsAlive(target) || !world.Has<HealthComponent>(target))
            return false;
        if (world.Has<Invulnerability>(target))
            return false;

        ref var health = ref world.Get<HealthComponent>(target);
        var mult = 1f;
        if (world.TryGet<WeakPoint>(target, out var wp) && wp.Exposed)
            mult *= wp.Multiplier;
        if (world.TryGet<Hurtbox>(target, out var hb) && hb.DamageMultiplier > 0f)
            mult *= hb.DamageMultiplier;

        var dealt = Math.Max(1, (int)MathF.Round(amount * mult));
        health.Current = Math.Max(0, health.Current - dealt);
        world.Add(target, new Invulnerability { RemainingSeconds = invulnSeconds });
        _applied.Add(new DamageEvent(target, source, dealt));
        AppliedHits++;
        return true;
    }
}
