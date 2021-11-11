using System.Net;

namespace VanguardProtocol.Netcode.Transport.Nat;

public enum NatProbeState : byte { Idle, Probing, Succeeded, Failed }

/// <summary>Basic UDP hole-punch helper: exchange reflexive candidates and probe both ways.</summary>
public sealed class PunchThrough
{
    private readonly List<IPEndPoint> _localCandidates = new();
    private readonly List<IPEndPoint> _remoteCandidates = new();
    private int _probeIndex;
    private int _attempts;
    public NatProbeState State { get; private set; }
    public IPEndPoint? EstablishedPeer { get; private set; }
    public int MaxAttempts { get; set; } = 40;

    public void AddLocalCandidate(IPEndPoint ep)
    {
        if (!_localCandidates.Exists(e => e.Equals(ep))) _localCandidates.Add(ep);
    }
    public void AddRemoteCandidate(IPEndPoint ep)
    {
        if (!_remoteCandidates.Exists(e => e.Equals(ep))) _remoteCandidates.Add(ep);
    }
    public void Begin()
    {
        State = NatProbeState.Probing;
        _probeIndex = 0; _attempts = 0; EstablishedPeer = null;
    }
    public bool TryNextProbe(out IPEndPoint target)
    {
        target = null!;
        if (State != NatProbeState.Probing) return false;
        if (_remoteCandidates.Count == 0) { State = NatProbeState.Failed; return false; }
        if (_attempts >= MaxAttempts) { State = NatProbeState.Failed; return false; }
        target = _remoteCandidates[_probeIndex % _remoteCandidates.Count];
        _probeIndex++; _attempts++;
        return true;
    }
    public void OnProbeAck(IPEndPoint peer)
    {
        EstablishedPeer = peer;
        State = NatProbeState.Succeeded;
    }
    public IReadOnlyList<IPEndPoint> LocalCandidates => _localCandidates;
    public IReadOnlyList<IPEndPoint> RemoteCandidates => _remoteCandidates;
}
