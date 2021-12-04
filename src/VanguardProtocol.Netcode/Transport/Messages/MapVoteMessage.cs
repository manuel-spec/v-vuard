using System.Buffers.Binary;

namespace VanguardProtocol.Netcode.Transport.Messages;

public readonly struct MapVoteMessage
{
    public MapVoteMessage(ulong frame, uint token, ushort payload)
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

    public static bool TryRead(ReadOnlySpan<byte> src, out MapVoteMessage message)
    {
        message = default;
        if (src.Length < Size)
            return false;
        message = new MapVoteMessage(
            BinaryPrimitives.ReadUInt64LittleEndian(src),
            BinaryPrimitives.ReadUInt32LittleEndian(src[8..]),
            BinaryPrimitives.ReadUInt16LittleEndian(src[12..]));
        return true;
    }

    public static MapVoteMessage[] CreateBatch(int count, ulong startFrame, uint tokenSeed)
    {
        var arr = new MapVoteMessage[count];
        for (var i = 0; i < count; i++)
            arr[i] = new MapVoteMessage(startFrame + (ulong)i, tokenSeed + (uint)i, (ushort)(i * 17));
        return arr;
    }

    public static int WriteBatch(Span<byte> dest, ReadOnlySpan<MapVoteMessage> batch)
    {
        var offset = 0;
        BinaryPrimitives.WriteUInt16LittleEndian(dest, (ushort)batch.Length);
        offset += 2;
        for (var i = 0; i < batch.Length; i++)
            offset += batch[i].Write(dest[offset..]);
        return offset;
    }
}
