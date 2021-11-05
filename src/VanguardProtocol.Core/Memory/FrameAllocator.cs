namespace VanguardProtocol.Core.Memory;

/// <summary>
/// Bump allocator reset each simulation frame. Avoids per-frame heap churn for
/// temporary collision candidate lists and scratch buffers.
/// </summary>
public sealed class FrameAllocator
{
    private byte[] _buffer;
    private int _offset;
    private int _peak;

    public FrameAllocator(int capacityBytes = 64 * 1024)
    {
        if (capacityBytes < 1024)
            throw new ArgumentOutOfRangeException(nameof(capacityBytes));
        _buffer = new byte[capacityBytes];
    }

    public int Capacity => _buffer.Length;
    public int BytesUsed => _offset;
    public int PeakBytesUsed => _peak;

    public void Reset()
    {
        if (_offset > _peak)
            _peak = _offset;
        _offset = 0;
    }

    public Span<T> AllocSpan<T>(int count) where T : unmanaged
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count));
        var size = count * System.Runtime.CompilerServices.Unsafe.SizeOf<T>();
        var aligned = Align(_offset, System.Runtime.CompilerServices.Unsafe.SizeOf<T>());
        EnsureCapacity(aligned + size);
        _offset = aligned + size;
        return System.Runtime.InteropServices.MemoryMarshal.Cast<byte, T>(_buffer.AsSpan(aligned, size));
    }

    public T[] AllocArrayCopy<T>(ReadOnlySpan<T> source) where T : unmanaged
    {
        var span = AllocSpan<T>(source.Length);
        source.CopyTo(span);
        return span.ToArray();
    }

    private void EnsureCapacity(int needed)
    {
        if (needed <= _buffer.Length)
            return;

        var newSize = _buffer.Length;
        while (newSize < needed)
            newSize *= 2;
        var grown = new byte[newSize];
        Buffer.BlockCopy(_buffer, 0, grown, 0, _offset);
        _buffer = grown;
    }

    private static int Align(int value, int alignment)
    {
        var mask = alignment - 1;
        return (value + mask) & ~mask;
    }
}
