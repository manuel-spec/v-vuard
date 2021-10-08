using VanguardProtocol.Core.Ecs;

namespace VanguardProtocol.Core;

public interface IScene
{
    string Name { get; }
    void Enter();
    void Exit();
    void Update(World world, float fixedDeltaSeconds);
    void Draw(float alpha);
}

/// <summary>Menu / gameplay / pause stack. Top scene receives update and draw.</summary>
public sealed class SceneStack
{
    private readonly List<IScene> _stack = new();

    public IScene? Current => _stack.Count > 0 ? _stack[^1] : null;
    public int Count => _stack.Count;

    public void Push(IScene scene)
    {
        ArgumentNullException.ThrowIfNull(scene);
        Current?.Exit();
        _stack.Add(scene);
        scene.Enter();
    }

    public IScene? Pop()
    {
        if (_stack.Count == 0)
            return null;

        var top = _stack[^1];
        top.Exit();
        _stack.RemoveAt(_stack.Count - 1);
        Current?.Enter();
        return top;
    }

    public void Replace(IScene scene)
    {
        ArgumentNullException.ThrowIfNull(scene);
        if (_stack.Count > 0)
        {
            Current!.Exit();
            _stack.RemoveAt(_stack.Count - 1);
        }

        _stack.Add(scene);
        scene.Enter();
    }

    public void Clear()
    {
        while (_stack.Count > 0)
            Pop();
    }

    public void Update(World world, float fixedDeltaSeconds) => Current?.Update(world, fixedDeltaSeconds);

    public void Draw(float alpha) => Current?.Draw(alpha);
}
