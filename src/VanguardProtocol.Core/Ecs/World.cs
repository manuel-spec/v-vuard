namespace VanguardProtocol.Core.Ecs;

/// <summary>
/// Owns entity lifetimes and typed component stores. Index 0 is reserved as invalid.
/// </summary>
public sealed class World
{
    private readonly List<uint> _generations = [0]; // index 0 unused
    private readonly Queue<uint> _freeIndices = new();
    private readonly Dictionary<Type, IComponentStore> _stores = new();
    private int _aliveCount;

    public int EntityCount => _aliveCount;
    public ulong Tick { get; private set; }

    public void AdvanceTick() => Tick++;

    public Entity CreateEntity()
    {
        uint index;
        if (_freeIndices.Count > 0)
        {
            index = _freeIndices.Dequeue();
        }
        else
        {
            index = (uint)_generations.Count;
            _generations.Add(1);
        }

        if (index < _generations.Count && _generations[(int)index] == 0)
            _generations[(int)index] = 1;

        _aliveCount++;
        return new Entity(index, _generations[(int)index]);
    }

    public bool IsAlive(Entity entity)
    {
        if (entity.IsNone || entity.Index >= (uint)_generations.Count)
            return false;
        return _generations[(int)entity.Index] == entity.Generation;
    }

    public bool DestroyEntity(Entity entity)
    {
        if (!IsAlive(entity))
            return false;

        foreach (var store in _stores.Values)
            store.Remove(entity);

        unchecked
        {
            _generations[(int)entity.Index]++;
        }

        _freeIndices.Enqueue(entity.Index);
        _aliveCount--;
        return true;
    }

    public ComponentStore<T> GetStore<T>() where T : struct, IComponent
    {
        var type = typeof(T);
        if (_stores.TryGetValue(type, out var existing))
            return (ComponentStore<T>)existing;

        var store = new ComponentStore<T>();
        _stores[type] = store;
        return store;
    }

    public void Add<T>(Entity entity, in T component) where T : struct, IComponent
    {
        EnsureAlive(entity);
        GetStore<T>().Set(entity, component);
    }

    public ref T Get<T>(Entity entity) where T : struct, IComponent => ref GetStore<T>().Get(entity);

    public bool TryGet<T>(Entity entity, out T component) where T : struct, IComponent =>
        GetStore<T>().TryGet(entity, out component);

    public bool Has<T>(Entity entity) where T : struct, IComponent => GetStore<T>().Has(entity);

    public bool Remove<T>(Entity entity) where T : struct, IComponent => GetStore<T>().Remove(entity);

    public void Clear()
    {
        foreach (var store in _stores.Values)
            store.Clear();

        _generations.Clear();
        _generations.Add(0);
        _freeIndices.Clear();
        _aliveCount = 0;
        Tick = 0;
    }

    private void EnsureAlive(Entity entity)
    {
        if (!IsAlive(entity))
            throw new InvalidOperationException($"Entity {entity} is not alive.");
    }
}
