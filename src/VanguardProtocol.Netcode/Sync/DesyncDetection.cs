using System.Buffers.Binary;
using System.Security.Cryptography;
using System.Text;

namespace VanguardProtocol.Netcode.Sync;

/// <summary>Periodic state checksum exchange to detect silent simulation divergence.</summary>
public sealed class DesyncDetection
{
    private readonly Dictionary<ulong, uint> _local = new();
    private readonly Dictionary<ulong, uint> _remote = new();
    public ulong? FirstDesyncFrame { get; private set; }
    public bool HasDesynced => FirstDesyncFrame.HasValue;

    public uint HashState(ulong frame, ReadOnlySpan<byte> stateBytes)
    {
        // FNV-1a 32-bit — fast, deterministic, non-crypto.
        uint hash = 2166136261u;
        hash ^= (uint)frame;
        hash *= 16777619u;
        for (int i = 0; i < stateBytes.Length; i++)
        {
            hash ^= stateBytes[i];
            hash *= 16777619u;
        }
        _local[frame] = hash;
        Check(frame);
        return hash;
    }

    public void ReceiveRemote(ulong frame, uint hash)
    {
        _remote[frame] = hash;
        Check(frame);
    }

    public void PruneBefore(ulong frame)
    {
        foreach (var k in _local.Keys.ToArray()) if (k < frame) _local.Remove(k);
        foreach (var k in _remote.Keys.ToArray()) if (k < frame) _remote.Remove(k);
    }

    private void Check(ulong frame)
    {
        if (FirstDesyncFrame.HasValue) return;
        if (_local.TryGetValue(frame, out var a) && _remote.TryGetValue(frame, out var b) && a != b)
            FirstDesyncFrame = frame;
    }
}

public static class StateChecksumWriter
{
    public static void WriteUInt32(BinaryWriter w, uint v) => w.Write(v);
    public static void WriteInt32(BinaryWriter w, int v) => w.Write(v);
    public static void WriteFloatBits(BinaryWriter w, float v) => w.Write(BitConverter.SingleToInt32Bits(v));
    public static byte[] ToArray(Action<BinaryWriter> write)
    {
        using var ms = new MemoryStream();
        using (var bw = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
            write(bw);
        return ms.ToArray();
    }
}
