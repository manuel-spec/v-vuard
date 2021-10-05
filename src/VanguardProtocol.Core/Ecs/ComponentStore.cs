namespace VanguardProtocol.Core.Ecs;

internal interface IComponentStore
{
    Type ComponentType { get; }
    bool Has(Entity entity);
    bool Remove(Entity entity);
    void Clear();
    int Count { get; }
}

/// <summary>
/// Sparse-set component storage: O(1) add/remove/lookup, dense iteration for cache-friendly systems.
/// </summary>
public sealed class ComponentStore<T> : IComponentStore where T : struct, IComponent
{
    private readonly Dictionary<uint, int> _sparse = new();
    private readonly List<Entity> _denseEntities = new();
    private readonly List<T> _denseComponents = new();

    public Type ComponentType => typeof(T);
    public int Count => _denseComponents.Count;

    public bool Has(Entity entity) =>
        _sparse.TryGetValue(entity.Index, out var dense) &&
        dense < _denseEntities.Count &&
        _denseEntities[dense] == entity;

    public ref T Get(Entity entity)
    {
        if (!TryGetIndex(entity, out var dense))
            throw new InvalidOperationException($"Entity {entity} does not have {typeof(T).Name}.");
        return ref GetRef(dense);
    }

    public bool TryGet(Entity entity, out T component)
    {
        if (!TryGetIndex(entity, out var dense))
        {
            component = default;
            return false;
        }

        component = _denseComponents[dense];
        return true;
    }

    public void Set(Entity entity, in T component)
    {
        if (TryGetIndex(entity, out var dense))
        {
            _denseComponents[dense] = component;
            return;
        }

        dense = _denseComponents.Count;
        _sparse[entity.Index] = dense;
        _denseEntities.Add(entity);
        _denseComponents.Add(component);
    }

    public bool Remove(Entity entity)
    {
        if (!TryGetIndex(entity, out var dense))
            return false;

        var last = _denseComponents.Count - 1;
        if (dense != last)
        {
            var movedEntity = _denseEntities[last];
            _denseEntities[dense] = movedEntity;
            _denseComponents[dense] = _denseComponents[last];
            _sparse[movedEntity.Index] = dense;
        }

        _denseEntities.RemoveAt(last);
        _denseComponents.RemoveAt(last);
        _sparse.Remove(entity.Index);
        return true;
    }

    public void Clear()
    {
        _sparse.Clear();
        _denseEntities.Clear();
        _denseComponents.Clear();
    }

    public Span<T> AsSpan() => System.Runtime.InteropServices.CollectionsMarshal.AsSpan(_denseComponents);
    public Span<Entity> EntitiesSpan() => System.Runtime.InteropServices.CollectionsMarshal.AsSpan(_denseEntities);

    public Enumerator GetEnumerator() => new(this);

    private bool TryGetIndex(Entity entity, out int dense)
    {
        if (_sparse.TryGetValue(entity.Index, out dense) &&
            dense < _denseEntities.Count &&
            _denseEntities[dense] == entity)
        {
            return true;
        }

        dense = -1;
        return false;
    }

    private ref T GetRef(int dense) =>
        ref System.Runtime.InteropServices.CollectionsMarshal.AsSpan(_denseComponents)[dense];

    public struct Enumerator
    {
        private readonly ComponentStore<T> _store;
        private int _index;

        internal Enumerator(ComponentStore<T> store)
        {
            _store = store;
            _index = -1;
        }

        public (Entity Entity, T Component) Current =>
            (_store._denseEntities[_index], _store._denseComponents[_index]);

        public bool MoveNext()
        {
            _index++;
            return _index < _store._denseComponents.Count;
        }
    }
}
