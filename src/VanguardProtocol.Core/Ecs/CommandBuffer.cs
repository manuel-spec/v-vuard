namespace VanguardProtocol.Core.Ecs;

/// <summary>
/// Deferred structural changes so systems can safely queue creates/destroys/adds mid-iteration.
/// Playback is deterministic FIFO.
/// </summary>
public sealed class CommandBuffer
{
    private readonly List<ICommand> _commands = new(64);

    public int PendingCount => _commands.Count;

    public Entity CreateEntity(World world)
    {
        // Structural create must happen immediately to return a stable Entity handle,
        // but we still record it for replay/debug dumps.
        var entity = world.CreateEntity();
        _commands.Add(new CreatedMarker(entity));
        return entity;
    }

    public void Destroy(Entity entity) => _commands.Add(new DestroyCommand(entity));

    public void Add<T>(Entity entity, T component) where T : struct, IComponent =>
        _commands.Add(new AddCommand<T>(entity, component));

    public void Remove<T>(Entity entity) where T : struct, IComponent =>
        _commands.Add(new RemoveCommand<T>(entity));

    public void Set<T>(Entity entity, T component) where T : struct, IComponent =>
        _commands.Add(new SetCommand<T>(entity, component));

    public void Playback(World world)
    {
        for (var i = 0; i < _commands.Count; i++)
            _commands[i].Execute(world);
        _commands.Clear();
    }

    public void Clear() => _commands.Clear();

    private interface ICommand
    {
        void Execute(World world);
    }

    private sealed class CreatedMarker : ICommand
    {
        private readonly Entity _entity;
        public CreatedMarker(Entity entity) => _entity = entity;
        public void Execute(World world) { /* already created */ }
    }

    private sealed class DestroyCommand : ICommand
    {
        private readonly Entity _entity;
        public DestroyCommand(Entity entity) => _entity = entity;
        public void Execute(World world) => world.DestroyEntity(_entity);
    }

    private sealed class AddCommand<T> : ICommand where T : struct, IComponent
    {
        private readonly Entity _entity;
        private readonly T _component;
        public AddCommand(Entity entity, T component)
        {
            _entity = entity;
            _component = component;
        }

        public void Execute(World world)
        {
            if (!world.IsAlive(_entity))
                return;
            world.Add(_entity, _component);
        }
    }

    private sealed class SetCommand<T> : ICommand where T : struct, IComponent
    {
        private readonly Entity _entity;
        private readonly T _component;
        public SetCommand(Entity entity, T component)
        {
            _entity = entity;
            _component = component;
        }

        public void Execute(World world)
        {
            if (!world.IsAlive(_entity))
                return;
            world.Add(_entity, _component);
        }
    }

    private sealed class RemoveCommand<T> : ICommand where T : struct, IComponent
    {
        private readonly Entity _entity;
        public RemoveCommand(Entity entity) => _entity = entity;
        public void Execute(World world)
        {
            if (!world.IsAlive(_entity))
                return;
            world.Remove<T>(_entity);
        }
    }
}
