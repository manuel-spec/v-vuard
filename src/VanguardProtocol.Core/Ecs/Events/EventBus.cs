namespace VanguardProtocol.Core.Ecs.Events;

public interface IEvent;

/// <summary>Immediate, non-allocating-friendly event bus for engine-level notifications.</summary>
public sealed class EventBus
{
    private readonly Dictionary<Type, List<object>> _handlers = new();
    private readonly Queue<object> _queued = new();

    public void Subscribe<T>(Action<T> handler) where T : IEvent
    {
        ArgumentNullException.ThrowIfNull(handler);
        var type = typeof(T);
        if (!_handlers.TryGetValue(type, out var list))
        {
            list = new List<object>();
            _handlers[type] = list;
        }

        list.Add(handler);
    }

    public void Unsubscribe<T>(Action<T> handler) where T : IEvent
    {
        if (_handlers.TryGetValue(typeof(T), out var list))
            list.Remove(handler);
    }

    public void Publish<T>(T evt) where T : IEvent
    {
        if (!_handlers.TryGetValue(typeof(T), out var list))
            return;

        for (var i = 0; i < list.Count; i++)
            ((Action<T>)list[i]).Invoke(evt);
    }

    public void Queue<T>(T evt) where T : IEvent => _queued.Enqueue(evt!);

    public void DispatchQueued()
    {
        while (_queued.Count > 0)
        {
            var evt = _queued.Dequeue();
            var type = evt.GetType();
            if (!_handlers.TryGetValue(type, out var list))
                continue;

            for (var i = 0; i < list.Count; i++)
            {
                var handler = list[i];
                handler.GetType().GetMethod("Invoke")!.Invoke(handler, [evt]);
            }
        }
    }

    public void Clear()
    {
        _handlers.Clear();
        _queued.Clear();
    }
}

public readonly struct FrameBeginEvent(ulong tick) : IEvent
{
    public ulong Tick { get; } = tick;
}

public readonly struct CollisionEvent(Entity a, Entity b) : IEvent
{
    public Entity A { get; } = a;
    public Entity B { get; } = b;
}
