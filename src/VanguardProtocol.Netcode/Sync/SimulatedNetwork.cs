using VanguardProtocol.Core;

namespace VanguardProtocol.Netcode.Sync;

/// <summary>In-memory duplex link with configurable latency/loss for lockstep tests.</summary>
public sealed class SimulatedNetworkLink
{
    private readonly Queue<ScheduledPacket> _aToB = new();
    private readonly Queue<ScheduledPacket> _bToA = new();
    private double _clock;
    private readonly DeterministicDropper _dropper;

    public SimulatedNetworkLink(int latencyMs = 50, float loss01 = 0f, ulong seed = 1)
    {
        LatencyMs = latencyMs;
        Loss01 = loss01;
        _dropper = new DeterministicDropper(seed, loss01);
    }

    public int LatencyMs { get; }
    public float Loss01 { get; }
    public int Sent { get; private set; }
    public int Delivered { get; private set; }
    public int Dropped { get; private set; }

    public void SendAtoB(byte[] payload) => Enqueue(_aToB, payload);
    public void SendBtoA(byte[] payload) => Enqueue(_bToA, payload);
    public void Tick(double dtSeconds) => _clock += dtSeconds;
    public List<byte[]> ReceiveForB() => Drain(_aToB);
    public List<byte[]> ReceiveForA() => Drain(_bToA);

    private void Enqueue(Queue<ScheduledPacket> q, byte[] payload)
    {
        Sent++;
        if (_dropper.ShouldDrop())
        {
            Dropped++;
            return;
        }

        q.Enqueue(new ScheduledPacket(_clock + LatencyMs / 1000.0, payload));
    }

    private List<byte[]> Drain(Queue<ScheduledPacket> q)
    {
        var list = new List<byte[]>();
        while (q.Count > 0 && q.Peek().DeliverAt <= _clock)
        {
            list.Add(q.Dequeue().Payload);
            Delivered++;
        }

        return list;
    }

    private readonly record struct ScheduledPacket(double DeliverAt, byte[] Payload);
}

public sealed class DeterministicDropper
{
    private ulong _state;
    private readonly float _loss01;

    public DeterministicDropper(ulong seed, float loss01)
    {
        _state = seed == 0 ? 1UL : seed;
        _loss01 = Math.Clamp(loss01, 0f, 1f);
    }

    public bool ShouldDrop()
    {
        if (_loss01 <= 0f)
            return false;
        _state ^= _state >> 12;
        _state ^= _state << 25;
        _state ^= _state >> 27;
        var u = (_state * 0x2545F4914F6CDD1DUL >> 40) / (float)(1 << 24);
        return u < _loss01;
    }
}

public static class NetScenario00
{
    public static SimulatedNetworkLink Create() => new(20, 0.00f, 1000UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 0) % 15 == 0) ? InputButtons.Jump : (((f + 0) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario01
{
    public static SimulatedNetworkLink Create() => new(25, 0.02f, 1001UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 1) % 15 == 0) ? InputButtons.Jump : (((f + 1) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario02
{
    public static SimulatedNetworkLink Create() => new(30, 0.04f, 1002UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 2) % 15 == 0) ? InputButtons.Jump : (((f + 2) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario03
{
    public static SimulatedNetworkLink Create() => new(35, 0.06f, 1003UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 3) % 15 == 0) ? InputButtons.Jump : (((f + 3) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario04
{
    public static SimulatedNetworkLink Create() => new(40, 0.08f, 1004UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 4) % 15 == 0) ? InputButtons.Jump : (((f + 4) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario05
{
    public static SimulatedNetworkLink Create() => new(45, 0.00f, 1005UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 5) % 15 == 0) ? InputButtons.Jump : (((f + 5) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario06
{
    public static SimulatedNetworkLink Create() => new(50, 0.02f, 1006UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 6) % 15 == 0) ? InputButtons.Jump : (((f + 6) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario07
{
    public static SimulatedNetworkLink Create() => new(55, 0.04f, 1007UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 7) % 15 == 0) ? InputButtons.Jump : (((f + 7) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario08
{
    public static SimulatedNetworkLink Create() => new(60, 0.06f, 1008UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 8) % 15 == 0) ? InputButtons.Jump : (((f + 8) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario09
{
    public static SimulatedNetworkLink Create() => new(65, 0.08f, 1009UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 9) % 15 == 0) ? InputButtons.Jump : (((f + 9) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario10
{
    public static SimulatedNetworkLink Create() => new(70, 0.00f, 1010UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 10) % 15 == 0) ? InputButtons.Jump : (((f + 10) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario11
{
    public static SimulatedNetworkLink Create() => new(75, 0.02f, 1011UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 11) % 15 == 0) ? InputButtons.Jump : (((f + 11) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario12
{
    public static SimulatedNetworkLink Create() => new(80, 0.04f, 1012UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 12) % 15 == 0) ? InputButtons.Jump : (((f + 12) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario13
{
    public static SimulatedNetworkLink Create() => new(85, 0.06f, 1013UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 13) % 15 == 0) ? InputButtons.Jump : (((f + 13) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario14
{
    public static SimulatedNetworkLink Create() => new(90, 0.08f, 1014UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 14) % 15 == 0) ? InputButtons.Jump : (((f + 14) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario15
{
    public static SimulatedNetworkLink Create() => new(95, 0.00f, 1015UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 15) % 15 == 0) ? InputButtons.Jump : (((f + 15) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario16
{
    public static SimulatedNetworkLink Create() => new(100, 0.02f, 1016UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 16) % 15 == 0) ? InputButtons.Jump : (((f + 16) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario17
{
    public static SimulatedNetworkLink Create() => new(105, 0.04f, 1017UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 17) % 15 == 0) ? InputButtons.Jump : (((f + 17) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario18
{
    public static SimulatedNetworkLink Create() => new(110, 0.06f, 1018UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 18) % 15 == 0) ? InputButtons.Jump : (((f + 18) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario19
{
    public static SimulatedNetworkLink Create() => new(115, 0.08f, 1019UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 19) % 15 == 0) ? InputButtons.Jump : (((f + 19) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario20
{
    public static SimulatedNetworkLink Create() => new(120, 0.00f, 1020UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 20) % 15 == 0) ? InputButtons.Jump : (((f + 20) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario21
{
    public static SimulatedNetworkLink Create() => new(125, 0.02f, 1021UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 21) % 15 == 0) ? InputButtons.Jump : (((f + 21) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario22
{
    public static SimulatedNetworkLink Create() => new(130, 0.04f, 1022UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 22) % 15 == 0) ? InputButtons.Jump : (((f + 22) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}

public static class NetScenario23
{
    public static SimulatedNetworkLink Create() => new(135, 0.06f, 1023UL);

    public static InputFrame[] BuildInputStream(int frames)
    {
        var arr = new InputFrame[frames];
        var prev = InputButtons.None;
        for (var f = 0; f < frames; f++)
        {
            var cur = ((f + 23) % 15 == 0) ? InputButtons.Jump : (((f + 23) % 3 == 0) ? InputButtons.Right : InputButtons.None);
            if ((f % 7) == 0) cur |= InputButtons.Shoot;
            arr[f] = InputFrame.FromEdges(prev, cur);
            prev = cur;
        }
        return arr;
    }
}
