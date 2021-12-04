using VanguardProtocol.Netcode.Sync;
using Xunit;

namespace VanguardProtocol.Netcode.Tests;

public class NetworkScenarioTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    [InlineData(13)]
    [InlineData(14)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(17)]
    [InlineData(18)]
    [InlineData(19)]
    [InlineData(20)]
    [InlineData(21)]
    [InlineData(22)]
    [InlineData(23)]
    public void Scenario_Delivers_Or_Drops_Deterministically(int index)
    {
        var link = Create(index);
        var inputs = Build(index, 64);
        var buf = new byte[15];
        for (var f = 0; f < inputs.Length; f++)
        {
            InputSerializer.WriteFrame(buf, (ulong)(f + 1), 0, inputs[f]);
            link.SendAtoB((byte[])buf.Clone());
        }

        // Flush beyond configured latency so in-flight packets settle.
        for (var i = 0; i < 20; i++)
            link.Tick(0.05);
        _ = link.ReceiveForB();

        Assert.True(link.Sent >= 64);
        Assert.Equal(link.Sent, link.Delivered + link.Dropped);
    }

    private static SimulatedNetworkLink Create(int i) => i switch
    {
        0 => NetScenario00.Create(),
        1 => NetScenario01.Create(),
        2 => NetScenario02.Create(),
        3 => NetScenario03.Create(),
        4 => NetScenario04.Create(),
        5 => NetScenario05.Create(),
        6 => NetScenario06.Create(),
        7 => NetScenario07.Create(),
        8 => NetScenario08.Create(),
        9 => NetScenario09.Create(),
        10 => NetScenario10.Create(),
        11 => NetScenario11.Create(),
        12 => NetScenario12.Create(),
        13 => NetScenario13.Create(),
        14 => NetScenario14.Create(),
        15 => NetScenario15.Create(),
        16 => NetScenario16.Create(),
        17 => NetScenario17.Create(),
        18 => NetScenario18.Create(),
        19 => NetScenario19.Create(),
        20 => NetScenario20.Create(),
        21 => NetScenario21.Create(),
        22 => NetScenario22.Create(),
        _ => NetScenario23.Create(),
    };

    private static Core.InputFrame[] Build(int i, int frames) => i switch
    {
        0 => NetScenario00.BuildInputStream(frames),
        1 => NetScenario01.BuildInputStream(frames),
        2 => NetScenario02.BuildInputStream(frames),
        3 => NetScenario03.BuildInputStream(frames),
        4 => NetScenario04.BuildInputStream(frames),
        5 => NetScenario05.BuildInputStream(frames),
        6 => NetScenario06.BuildInputStream(frames),
        7 => NetScenario07.BuildInputStream(frames),
        8 => NetScenario08.BuildInputStream(frames),
        9 => NetScenario09.BuildInputStream(frames),
        10 => NetScenario10.BuildInputStream(frames),
        11 => NetScenario11.BuildInputStream(frames),
        12 => NetScenario12.BuildInputStream(frames),
        13 => NetScenario13.BuildInputStream(frames),
        14 => NetScenario14.BuildInputStream(frames),
        15 => NetScenario15.BuildInputStream(frames),
        16 => NetScenario16.BuildInputStream(frames),
        17 => NetScenario17.BuildInputStream(frames),
        18 => NetScenario18.BuildInputStream(frames),
        19 => NetScenario19.BuildInputStream(frames),
        20 => NetScenario20.BuildInputStream(frames),
        21 => NetScenario21.BuildInputStream(frames),
        22 => NetScenario22.BuildInputStream(frames),
        _ => NetScenario23.BuildInputStream(frames),
    };
}
