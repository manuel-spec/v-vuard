using System.Collections.Concurrent;
using System.Net;

namespace VanguardProtocol.Netcode.RelayService;

/// <summary>In-process matchmaking queue + packet relay map (not authoritative simulation).</summary>
public sealed class MatchmakingQueue
{
    private readonly ConcurrentQueue<WaitingClient> _queue = new();
    private readonly ConcurrentDictionary<Guid, MatchBinding> _matches = new();
    public int WaitingCount => _queue.Count;
    public int ActiveMatchCount => _matches.Count;

    public void Enqueue(Guid clientId, IPEndPoint endpoint) => _queue.Enqueue(new WaitingClient(clientId, endpoint));

    public bool TryPair(out MatchBinding match)
    {
        match = null!;
        if (!_queue.TryDequeue(out var a)) return false;
        if (!_queue.TryDequeue(out var b)) { _queue.Enqueue(a); return false; }
        match = new MatchBinding(Guid.NewGuid(), a, b);
        _matches[match.MatchId] = match;
        return true;
    }

    public bool TryGet(Guid matchId, out MatchBinding match) => _matches.TryGetValue(matchId, out match!);
    public bool Remove(Guid matchId) => _matches.TryRemove(matchId, out _);
}

public readonly record struct WaitingClient(Guid ClientId, IPEndPoint Endpoint);
public sealed class MatchBinding
{
    public MatchBinding(Guid matchId, WaitingClient a, WaitingClient b){ MatchId=matchId; A=a; B=b; }
    public Guid MatchId { get; }
    public WaitingClient A { get; }
    public WaitingClient B { get; }
    public IPEndPoint PeerOf(Guid clientId)
    {
        if (clientId == A.ClientId) return B.Endpoint;
        if (clientId == B.ClientId) return A.Endpoint;
        throw new InvalidOperationException("Client not in match.");
    }
}

public sealed class RelayForwarder
{
    private readonly MatchmakingQueue _queue;
    private long _forwarded;
    public RelayForwarder(MatchmakingQueue queue) => _queue = queue;
    public long ForwardedPackets => _forwarded;
    public bool TryForward(Guid matchId, Guid fromClient, ReadOnlySpan<byte> payload, out IPEndPoint destination)
    {
        destination = null!;
        if (!_queue.TryGet(matchId, out var match)) return false;
        destination = match.PeerOf(fromClient);
        _forwarded++;
        return true;
    }
}
