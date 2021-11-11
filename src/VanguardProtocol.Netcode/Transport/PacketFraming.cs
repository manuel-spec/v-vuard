using System.Buffers.Binary;

namespace VanguardProtocol.Netcode.Transport;

/// <summary>Sequence numbers, ack bitfields, and CRC32 integrity for UDP datagrams.</summary>
public static class PacketFraming
{
    public const uint Magic = 0x56505254; // VPRT

    public static int WriteHeader(Span<byte> dest, PacketType type, ushort seq, ushort ack, uint ackBits, ReadOnlySpan<byte> body)
    {
        if (dest.Length < ProtocolVersion.HeaderBytes + body.Length + 4)
            throw new ArgumentException("Destination too small.");
        BinaryPrimitives.WriteUInt32LittleEndian(dest, Magic);
        dest[4] = (byte)type;
        dest[5] = 0; // flags
        BinaryPrimitives.WriteUInt16LittleEndian(dest[6..], ProtocolVersion.Current);
        BinaryPrimitives.WriteUInt16LittleEndian(dest[8..], seq);
        BinaryPrimitives.WriteUInt16LittleEndian(dest[10..], ack);
        // extend: write ackBits after header body prefix
        var offset = ProtocolVersion.HeaderBytes;
        BinaryPrimitives.WriteUInt32LittleEndian(dest[offset..], ackBits);
        offset += 4;
        body.CopyTo(dest[offset..]);
        offset += body.Length;
        var crc = Crc32.Compute(dest[..offset]);
        BinaryPrimitives.WriteUInt32LittleEndian(dest[offset..], crc);
        return offset + 4;
    }

    public static bool TryRead(ReadOnlySpan<byte> packet, out PacketHeader header, out ReadOnlySpan<byte> body)
    {
        header = default; body = default;
        if (packet.Length < ProtocolVersion.HeaderBytes + 8) return false;
        var magic = BinaryPrimitives.ReadUInt32LittleEndian(packet);
        if (magic != Magic) return false;
        var crcOffset = packet.Length - 4;
        var expected = BinaryPrimitives.ReadUInt32LittleEndian(packet[crcOffset..]);
        var actual = Crc32.Compute(packet[..crcOffset]);
        if (expected != actual) return false;
        header = new PacketHeader(
            (PacketType)packet[4],
            BinaryPrimitives.ReadUInt16LittleEndian(packet[6..]),
            BinaryPrimitives.ReadUInt16LittleEndian(packet[8..]),
            BinaryPrimitives.ReadUInt16LittleEndian(packet[10..]),
            BinaryPrimitives.ReadUInt32LittleEndian(packet[12..]));
        body = packet.Slice(16, crcOffset - 16);
        return header.Version == ProtocolVersion.Current;
    }
}

public readonly record struct PacketHeader(PacketType Type, ushort Version, ushort Sequence, ushort Ack, uint AckBits);

public static class Crc32
{
    private static readonly uint[] Table = CreateTable();
    private static uint[] CreateTable()
    {
        var table = new uint[256];
        for (uint i = 0; i < 256; i++)
        {
            uint crc = i;
            for (int j = 0; j < 8; j++)
                crc = (crc & 1) != 0 ? (crc >> 1) ^ 0xEDB88320u : crc >> 1;
            table[i] = crc;
        }
        return table;
    }
    public static uint Compute(ReadOnlySpan<byte> data)
    {
        uint crc = 0xFFFFFFFFu;
        for (int i = 0; i < data.Length; i++)
            crc = Table[(crc ^ data[i]) & 0xFF] ^ (crc >> 8);
        return crc ^ 0xFFFFFFFFu;
    }
}

public sealed class ReliabilityWindow
{
    private readonly Dictionary<ushort, long> _inflight = new();
    private ushort _localSeq;
    private ushort _remoteAck;
    private uint _ackBits;
    public ushort LocalSequence => _localSeq;
    public ushort RemoteAck => _remoteAck;
    public uint AckBits => _ackBits;
    public ushort NextSequence(){ unchecked { return _localSeq++; } }
    public void TrackSend(ushort seq, long tick){ _inflight[seq]=tick; }
    public void OnRemotePacket(ushort seq, ushort ack, uint ackBits)
    {
        UpdateAckBits(seq);
        _remoteAck = ack; _ackBits = ackBits;
        foreach (var key in _inflight.Keys.ToArray())
        {
            if (IsAcked(key, ack, ackBits)) _inflight.Remove(key);
        }
    }
    private void UpdateAckBits(ushort seq)
    {
        // maintain remote receipt map relative to highest seen
        if (SequenceGreater(seq, _remoteAck))
        {
            var shift = (ushort)(seq - _remoteAck);
            if (shift >= 32) _ackBits = 1u;
            else { _ackBits = (_ackBits << shift) | 1u; }
            _remoteAck = seq;
        }
        else
        {
            var diff = (ushort)(_remoteAck - seq);
            if (diff > 0 && diff <= 32) _ackBits |= 1u << (diff - 1);
        }
    }
    public static bool SequenceGreater(ushort a, ushort b){ return (ushort)(a - b) < 0x8000 && a != b; }
    public static bool IsAcked(ushort seq, ushort ack, uint ackBits)
    {
        if (seq == ack) return true;
        var diff = (ushort)(ack - seq);
        if (diff == 0 || diff > 32) return false;
        return ((ackBits >> (diff - 1)) & 1u) == 1u;
    }
}
