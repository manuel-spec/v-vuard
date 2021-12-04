using System.Buffers.Binary;

namespace VanguardProtocol.Netcode.Transport.Messages;

public readonly struct PingMessage
{
    public PingMessage(ulong frame, uint token, ushort payload)
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

    public static bool TryRead(ReadOnlySpan<byte> src, out PingMessage message)
    {
        message = default;
        if (src.Length < Size)
            return false;
        message = new PingMessage(
            BinaryPrimitives.ReadUInt64LittleEndian(src),
            BinaryPrimitives.ReadUInt32LittleEndian(src[8..]),
            BinaryPrimitives.ReadUInt16LittleEndian(src[12..]));
        return true;
    }

    public static PingMessage[] CreateBatch(int count, ulong startFrame, uint tokenSeed)
    {
        var arr = new PingMessage[count];
        for (var i = 0; i < count; i++)
            arr[i] = new PingMessage(startFrame + (ulong)i, tokenSeed + (uint)i, (ushort)(i * 17));
        return arr;
    }

    public static int WriteBatch(Span<byte> dest, ReadOnlySpan<PingMessage> batch)
    {
        var offset = 0;
        BinaryPrimitives.WriteUInt16LittleEndian(dest, (ushort)batch.Length);
        offset += 2;
        for (var i = 0; i < batch.Length; i++)
            offset += batch[i].Write(dest[offset..]);
        return offset;
    }
}
