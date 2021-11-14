using System.Net;

namespace VanguardProtocol.Netcode.Session;

public enum ConnectionState : byte
{
    Disconnected = 0,
    Connecting = 1,
    Connected = 2,
    Reconnecting = 3,
}

public sealed class ConnectionManager
{
    public ConnectionState State { get; private set; }
    public IPEndPoint? Peer { get; private set; }
    public Guid SessionId { get; private set; }
    public float TimeoutSeconds { get; set; } = 8f;
    private float _lastRecv;
    private float _clock;

    public void BeginConnect(IPEndPoint peer, Guid sessionId)
    {
        Peer = peer; SessionId = sessionId; State = ConnectionState.Connecting; _lastRecv = _clock;
    }
    public void MarkConnected(){ State = ConnectionState.Connected; _lastRecv = _clock; }
    public void OnPacketReceived(){ _lastRecv = _clock; if (State == ConnectionState.Reconnecting) State = ConnectionState.Connected; }
    public void Tick(float dt)
    {
        _clock += dt;
        if (State is ConnectionState.Connected or ConnectionState.Connecting or ConnectionState.Reconnecting)
        {
            if (_clock - _lastRecv > TimeoutSeconds)
            {
                if (State == ConnectionState.Connected) State = ConnectionState.Reconnecting;
                else if (State == ConnectionState.Reconnecting && _clock - _lastRecv > TimeoutSeconds * 2f)
                    Disconnect();
            }
        }
    }
    public void Disconnect(){ State = ConnectionState.Disconnected; Peer = null; }
}

public sealed class MatchmakingClient
{
    public enum QueueState : byte { Idle, Queued, Matched, Failed }
    public QueueState State { get; private set; }
    public Guid? MatchId { get; private set; }
    public IPEndPoint? AssignedPeer { get; private set; }
    public IPEndPoint? RelayEndpoint { get; private set; }
    public void Enqueue(){ State = QueueState.Queued; MatchId=null; AssignedPeer=null; }
    public void Cancel(){ State = QueueState.Idle; }
    public void OnMatched(Guid matchId, IPEndPoint peer, IPEndPoint? relay)
    {
        MatchId = matchId; AssignedPeer = peer; RelayEndpoint = relay; State = QueueState.Matched;
    }
    public void Fail(){ State = QueueState.Failed; }
}
