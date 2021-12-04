using System.Buffers.Binary;

namespace VanguardProtocol.Netcode.Transport.Messages;

public readonly struct NatProbeMessage
{
    public NatProbeMessage(ulong frame, uint token, ushort payload)
    {
        Frame = frame;
        Token = token;
        Payload = payload;
    }

    public ulong Frame { get; }
    public uint Token { get; }
    public ushort Payload { get; }

    public const int Size = 14;

    public int Write(Span<byte> dest)
    {
        if (dest.Length < Size)
            throw new ArgumentException("buffer too small");
        BinaryPrimitives.WriteUInt64LittleEndian(dest, Frame);
        BinaryPrimitives.WriteUInt32LittleEndian(dest[8..], Token);
        BinaryPrimitives.WriteUInt16LittleEndian(dest[12..], Payload);
        return Size;
    }

    public static bool TryRead(ReadOnlySpan<byte> src, out NatProbeMessage message)
    {
        message = default;
        if (src.Length < Size)
            return false;
        message = new NatProbeMessage(
            BinaryPrimitives.ReadUInt64LittleEndian(src),
            BinaryPrimitives.ReadUInt32LittleEndian(src[8..]),
            BinaryPrimitives.ReadUInt16LittleEndian(src[12..]));
        return true;
    }

    public static NatProbeMessage[] CreateBatch(int count, ulong startFrame, uint tokenSeed)
    {
        var arr = new NatProbeMessage[count];
        for (var i = 0; i < count; i++)
            arr[i] = new NatProbeMessage(startFrame + (ulong)i, tokenSeed + (uint)i, (ushort)(i * 17));
        return arr;
    }

    public static int WriteBatch(Span<byte> dest, ReadOnlySpan<NatProbeMessage> batch)
    {
        var offset = 0;
        BinaryPrimitives.WriteUInt16LittleEndian(dest, (ushort)batch.Length);
        offset += 2;
        for (var i = 0; i < batch.Length; i++)
            offset += batch[i].Write(dest[offset..]);
        return offset;
    }
}
