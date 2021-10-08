namespace VanguardProtocol.Core;

[Flags]
public enum InputButtons : ushort
{
    None = 0,
    Left = 1 << 0,
    Right = 1 << 1,
    Up = 1 << 2,
    Down = 1 << 3,
    Jump = 1 << 4,
    Shoot = 1 << 5,
    Pause = 1 << 6,
}

/// <summary>Per-player input snapshot for a simulation frame (also used later by lockstep netcode).</summary>
public struct InputFrame
{
    public InputButtons Buttons;
    public InputButtons Pressed;
    public InputButtons Released;

    public readonly bool IsDown(InputButtons button) => (Buttons & button) != 0;
    public readonly bool WasPressed(InputButtons button) => (Pressed & button) != 0;
    public readonly bool WasReleased(InputButtons button) => (Released & button) != 0;

    public static InputFrame FromEdges(InputButtons previous, InputButtons current) => new()
    {
        Buttons = current,
        Pressed = current & ~previous,
        Released = previous & ~current,
    };
}

/// <summary>Short ring buffer so slightly-early jump/shoot still registers (genre feel).</summary>
public sealed class InputBuffer
{
    private readonly InputButtons[] _history;
    private int _write;

    public InputBuffer(int frames = 6)
    {
        if (frames < 1)
            throw new ArgumentOutOfRangeException(nameof(frames));
        _history = new InputButtons[frames];
    }

    public int Capacity => _history.Length;

    public void Push(InputButtons buttons)
    {
        _history[_write] = buttons;
        _write = (_write + 1) % _history.Length;
    }

    public bool ConsumedPress(InputButtons button, int lookbackFrames)
    {
        lookbackFrames = Math.Clamp(lookbackFrames, 1, _history.Length);
        for (var i = 0; i < lookbackFrames; i++)
        {
            var idx = (_write - 1 - i + _history.Length * 2) % _history.Length;
            if ((_history[idx] & button) != 0)
            {
                // Clear so the same buffered press is not reused.
                _history[idx] &= ~button;
                return true;
            }
        }

        return false;
    }

    public void Clear() => Array.Clear(_history);
}
