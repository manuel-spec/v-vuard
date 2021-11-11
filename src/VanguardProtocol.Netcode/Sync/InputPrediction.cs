using VanguardProtocol.Core;

namespace VanguardProtocol.Netcode.Sync;

/// <summary>Predict remote input by repeating last confirmed frame until real input arrives.</summary>
public sealed class InputPrediction
{
    private readonly InputFrame[] _lastConfirmed;
    private readonly bool[] _hasConfirmed;
    public InputPrediction(int playerCount)
    {
        _lastConfirmed = new InputFrame[playerCount];
        _hasConfirmed = new bool[playerCount];
    }
    public void Confirm(int playerIndex, InputFrame input)
    {
        _lastConfirmed[playerIndex] = input;
        _hasConfirmed[playerIndex] = true;
    }
    public InputFrame Predict(int playerIndex)
    {
        if (_hasConfirmed[playerIndex]) return _lastConfirmed[playerIndex];
        return default;
    }
    public bool HasConfirmed(int playerIndex) => _hasConfirmed[playerIndex];
}
