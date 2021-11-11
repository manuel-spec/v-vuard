using System.Net;
using System.Net.Sockets;

namespace VanguardProtocol.Netcode.Transport;

/// <summary>Thin UDP send/receive wrapper with non-blocking polls.</summary>
public sealed class UdpSocket : IDisposable
{
    private readonly Socket _socket;
    private readonly byte[] _recvBuffer = new byte[ProtocolVersion.MaxPacketBytes];
    private bool _disposed;

    public UdpSocket(int localPort = 0)
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        _socket.Blocking = false;
        _socket.Bind(new IPEndPoint(IPAddress.Any, localPort));
    }

    public EndPoint LocalEndPoint => _socket.LocalEndPoint!;
    public int Available => _socket.Available;

    public void SendTo(ReadOnlySpan<byte> payload, IPEndPoint remote)
    {
        EnsureNotDisposed();
        _socket.SendTo(payload.ToArray(), remote);
    }

    public bool TryReceive(out ArraySegment<byte> payload, out IPEndPoint remote)
    {
        EnsureNotDisposed();
        payload = default;
        remote = new IPEndPoint(IPAddress.Any, 0);
        if (_socket.Available <= 0) return false;
        EndPoint ep = new IPEndPoint(IPAddress.Any, 0);
        try
        {
            var n = _socket.ReceiveFrom(_recvBuffer, ref ep);
            if (n <= 0) return false;
            payload = new ArraySegment<byte>(_recvBuffer, 0, n);
            remote = (IPEndPoint)ep;
            return true;
        }
        catch (SocketException ex) when (ex.SocketErrorCode is SocketError.WouldBlock or SocketError.ConnectionReset)
        {
            return false;
        }
    }

    public void Dispose(){ if(_disposed) return; _disposed=true; _socket.Dispose(); }
    private void EnsureNotDisposed(){ if(_disposed) throw new ObjectDisposedException(nameof(UdpSocket)); }
}
