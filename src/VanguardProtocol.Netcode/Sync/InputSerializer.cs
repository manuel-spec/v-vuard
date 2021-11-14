using System.Buffers.Binary;
using VanguardProtocol.Core;

namespace VanguardProtocol.Netcode.Sync;

public static class InputSerializer
{
    public static int WriteFrame(Span<byte> dest, ulong frame, int playerIndex, InputFrame input)
    {
        BinaryPrimitives.WriteUInt64LittleEndian(dest, frame);
        dest[8] = (byte)playerIndex;
        BinaryPrimitives.WriteUInt16LittleEndian(dest[9..], (ushort)input.Buttons);
        BinaryPrimitives.WriteUInt16LittleEndian(dest[11..], (ushort)input.Pressed);
        BinaryPrimitives.WriteUInt16LittleEndian(dest[13..], (ushort)input.Released);
        return 15;
    }

    public static bool TryReadFrame(ReadOnlySpan<byte> src, out ulong frame, out int playerIndex, out InputFrame input)
    {
        frame = 0;
        playerIndex = 0;
        input = default;
        if (src.Length < 15)
            return false;
        frame = BinaryPrimitives.ReadUInt64LittleEndian(src);
        playerIndex = src[8];
        input = new InputFrame
        {
            Buttons = (InputButtons)BinaryPrimitives.ReadUInt16LittleEndian(src[9..]),
            Pressed = (InputButtons)BinaryPrimitives.ReadUInt16LittleEndian(src[11..]),
            Released = (InputButtons)BinaryPrimitives.ReadUInt16LittleEndian(src[13..]),
        };
        return true;
    }
}

public sealed class JitterBuffer
{
    private readonly SortedDictionary<ulong, InputFrame> _buffer = new();
    public int Count => _buffer.Count;
    public void Push(ulong frame, InputFrame input) => _buffer[frame] = input;
    public bool TryPop(ulong frame, out InputFrame input) => _buffer.Remove(frame, out input!);

    public void PruneBefore(ulong frame)
    {
        foreach (var key in _buffer.Keys.ToArray())
        {
            if (key < frame)
                _buffer.Remove(key);
        }
    }
}
