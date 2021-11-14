using VanguardProtocol.Core;

namespace VanguardProtocol.Netcode.Sync;

/// <summary>Rollback to last confirmed frame and resimulate forward with corrected inputs.</summary>
public sealed class Reconciliation
{
    public delegate void SaveStateHandler(ulong frame);
    public delegate void LoadStateHandler(ulong frame);
    public delegate void SimulateFrameHandler(ulong frame, FrameInputs inputs);

    private readonly LockstepSimulation _lockstep;
    private readonly int _maxRollbackFrames;
    public Reconciliation(LockstepSimulation lockstep, int maxRollbackFrames = 8)
    {
        _lockstep = lockstep;
        _maxRollbackFrames = maxRollbackFrames;
        PredictedFrame = 0;
    }
    public ulong PredictedFrame { get; private set; }
    public int MispredictionCount { get; private set; }

    public void AdvancePredicted(FrameInputs predicted, SimulateFrameHandler simulate, SaveStateHandler save)
    {
        PredictedFrame++;
        simulate(PredictedFrame, predicted);
        save(PredictedFrame);
    }

    public bool TryReconcile(ulong correctedFrame, SimulateFrameHandler simulate, LoadStateHandler load, SaveStateHandler save)
    {
        if (correctedFrame > PredictedFrame) return false;
        if (PredictedFrame - correctedFrame > (ulong)_maxRollbackFrames)
            throw new InvalidOperationException("Rollback window exceeded.");
        if (!_lockstep.TryGetConfirmed(correctedFrame, out var confirmed)) return false;
        MispredictionCount++;
        load(correctedFrame - 1);
        for (var f = correctedFrame; f <= PredictedFrame; f++)
        {
            if (!_lockstep.TryGetConfirmed(f, out var inputs))
                break;
            simulate(f, inputs);
            save(f);
        }
        return true;
    }
}
