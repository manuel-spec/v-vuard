using VanguardProtocol.Core;

namespace VanguardProtocol.Netcode.Sync;

/// <summary>Deterministic lockstep: both peers advance only when both inputs for frame N are known.</summary>
public sealed class LockstepSimulation
{
    private readonly Dictionary<ulong, FrameInputs> _frames = new();
    private readonly int _playerCount;
    public LockstepSimulation(int playerCount = 2)
    {
        if (playerCount < 1 || playerCount > 4) throw new ArgumentOutOfRangeException(nameof(playerCount));
        _playerCount = playerCount;
        ConfirmedFrame = 0;
    }
    public ulong ConfirmedFrame { get; private set; }
    public ulong LatestQueuedFrame { get; private set; }
    public void Submit(ulong frame, int playerIndex, InputFrame input)
    {
        if (playerIndex < 0 || playerIndex >= _playerCount) throw new ArgumentOutOfRangeException(nameof(playerIndex));
        if (!_frames.TryGetValue(frame, out var slot))
        {
            slot = new FrameInputs(_playerCount);
            _frames[frame] = slot;
        }
        slot.Set(playerIndex, input);
        if (frame > LatestQueuedFrame) LatestQueuedFrame = frame;
        AdvanceConfirmed();
    }
    public bool TryGetConfirmed(ulong frame, out FrameInputs inputs)
    {
        inputs = default!;
        if (frame > ConfirmedFrame) return false;
        return _frames.TryGetValue(frame, out inputs!);
    }
    public void PruneBefore(ulong frame)
    {
        foreach (var key in _frames.Keys.ToArray())
            if (key < frame) _frames.Remove(key);
    }
    private void AdvanceConfirmed()
    {
        while (_frames.TryGetValue(ConfirmedFrame + 1, out var slot) && slot.IsComplete)
            ConfirmedFrame++;
    }
}

public sealed class FrameInputs
{
    private readonly InputFrame?[] _inputs;
    private readonly bool[] _present;
    public FrameInputs(int playerCount){ _inputs=new InputFrame?[playerCount]; _present=new bool[playerCount]; }
    public int PlayerCount => _inputs.Length;
    public bool IsComplete { get { for(int i=0;i<_present.Length;i++) if(!_present[i]) return false; return true; } }
    public void Set(int player, InputFrame input){ _inputs[player]=input; _present[player]=true; }
    public InputFrame Get(int player)
    {
        if (!_present[player])
            throw new InvalidOperationException();
        return _inputs[player]!.Value;
    }

    public bool TryGet(int player, out InputFrame input)
    {
        if (!_present[player] || _inputs[player] is not { } value)
        {
            input = default;
            return false;
        }

        input = value;
        return true;
    }
}
