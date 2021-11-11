namespace VanguardProtocol.Netcode.Transport;

public enum PacketType : byte
{
    Hello = 0,
    HelloAck = 1,
    Input = 2,
    InputAck = 3,
    Checksum = 4,
    ChecksumAck = 5,
    Ping = 6,
    Pong = 7,
    Disconnect = 8,
    RelayEnvelope = 9,
    NatProbe = 10,
    NatProbeAck = 11,
    MatchOffer = 12,
    MatchAccept = 13,
    MatchReject = 14,
    KeepAlive = 15,
}

public enum DisconnectReason : byte
{
    UserQuit = 0,
    Timeout = 1,
    Desync = 2,
    ProtocolError = 3,
    PeerLeft = 4,
}

public static class ProtocolVersion
{
    public const ushort Current = 1;
    public const int MaxPacketBytes = 1200;
    public const int HeaderBytes = 12;
}
