using VanguardProtocol.Netcode.Sync;
using Xunit;

namespace VanguardProtocol.Netcode.Tests;

public class DesyncCorpusTests
{

    [Fact]
    public void Corpus_000()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 0, 0, 0, 0, 0 };
        var h = d.HashState(1, bytes);
        d.ReceiveRemote(1, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(1, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_001()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 3, 5, 7, 11, 13 };
        var h = d.HashState(2, bytes);
        d.ReceiveRemote(2, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(2, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_002()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 6, 10, 14, 22, 26 };
        var h = d.HashState(3, bytes);
        d.ReceiveRemote(3, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(3, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_003()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 9, 15, 21, 33, 39 };
        var h = d.HashState(4, bytes);
        d.ReceiveRemote(4, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(4, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_004()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 12, 20, 28, 44, 52 };
        var h = d.HashState(5, bytes);
        d.ReceiveRemote(5, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(5, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_005()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 15, 25, 35, 55, 65 };
        var h = d.HashState(6, bytes);
        d.ReceiveRemote(6, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(6, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_006()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 18, 30, 42, 66, 78 };
        var h = d.HashState(7, bytes);
        d.ReceiveRemote(7, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(7, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_007()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 21, 35, 49, 77, 91 };
        var h = d.HashState(8, bytes);
        d.ReceiveRemote(8, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(8, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_008()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 24, 40, 56, 88, 104 };
        var h = d.HashState(9, bytes);
        d.ReceiveRemote(9, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(9, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_009()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 27, 45, 63, 99, 117 };
        var h = d.HashState(10, bytes);
        d.ReceiveRemote(10, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(10, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_010()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 30, 50, 70, 110, 130 };
        var h = d.HashState(11, bytes);
        d.ReceiveRemote(11, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(11, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_011()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 33, 55, 77, 121, 143 };
        var h = d.HashState(12, bytes);
        d.ReceiveRemote(12, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(12, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_012()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 36, 60, 84, 132, 156 };
        var h = d.HashState(13, bytes);
        d.ReceiveRemote(13, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(13, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_013()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 39, 65, 91, 143, 169 };
        var h = d.HashState(14, bytes);
        d.ReceiveRemote(14, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(14, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_014()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 42, 70, 98, 154, 182 };
        var h = d.HashState(15, bytes);
        d.ReceiveRemote(15, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(15, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_015()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 45, 75, 105, 165, 195 };
        var h = d.HashState(16, bytes);
        d.ReceiveRemote(16, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(16, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_016()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 48, 80, 112, 176, 208 };
        var h = d.HashState(17, bytes);
        d.ReceiveRemote(17, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(17, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_017()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 51, 85, 119, 187, 221 };
        var h = d.HashState(18, bytes);
        d.ReceiveRemote(18, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(18, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_018()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 54, 90, 126, 198, 234 };
        var h = d.HashState(19, bytes);
        d.ReceiveRemote(19, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(19, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_019()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 57, 95, 133, 209, 247 };
        var h = d.HashState(20, bytes);
        d.ReceiveRemote(20, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(20, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_020()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 60, 100, 140, 220, 4 };
        var h = d.HashState(21, bytes);
        d.ReceiveRemote(21, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(21, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_021()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 63, 105, 147, 231, 17 };
        var h = d.HashState(22, bytes);
        d.ReceiveRemote(22, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(22, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_022()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 66, 110, 154, 242, 30 };
        var h = d.HashState(23, bytes);
        d.ReceiveRemote(23, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(23, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_023()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 69, 115, 161, 253, 43 };
        var h = d.HashState(24, bytes);
        d.ReceiveRemote(24, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(24, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_024()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 72, 120, 168, 8, 56 };
        var h = d.HashState(25, bytes);
        d.ReceiveRemote(25, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(25, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_025()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 75, 125, 175, 19, 69 };
        var h = d.HashState(26, bytes);
        d.ReceiveRemote(26, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(26, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_026()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 78, 130, 182, 30, 82 };
        var h = d.HashState(27, bytes);
        d.ReceiveRemote(27, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(27, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_027()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 81, 135, 189, 41, 95 };
        var h = d.HashState(28, bytes);
        d.ReceiveRemote(28, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(28, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_028()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 84, 140, 196, 52, 108 };
        var h = d.HashState(29, bytes);
        d.ReceiveRemote(29, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(29, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_029()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 87, 145, 203, 63, 121 };
        var h = d.HashState(30, bytes);
        d.ReceiveRemote(30, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(30, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_030()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 90, 150, 210, 74, 134 };
        var h = d.HashState(31, bytes);
        d.ReceiveRemote(31, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(31, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_031()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 93, 155, 217, 85, 147 };
        var h = d.HashState(32, bytes);
        d.ReceiveRemote(32, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(32, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_032()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 96, 160, 224, 96, 160 };
        var h = d.HashState(33, bytes);
        d.ReceiveRemote(33, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(33, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_033()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 99, 165, 231, 107, 173 };
        var h = d.HashState(34, bytes);
        d.ReceiveRemote(34, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(34, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_034()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 102, 170, 238, 118, 186 };
        var h = d.HashState(35, bytes);
        d.ReceiveRemote(35, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(35, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_035()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 105, 175, 245, 129, 199 };
        var h = d.HashState(36, bytes);
        d.ReceiveRemote(36, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(36, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_036()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 108, 180, 252, 140, 212 };
        var h = d.HashState(37, bytes);
        d.ReceiveRemote(37, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(37, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_037()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 111, 185, 3, 151, 225 };
        var h = d.HashState(38, bytes);
        d.ReceiveRemote(38, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(38, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_038()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 114, 190, 10, 162, 238 };
        var h = d.HashState(39, bytes);
        d.ReceiveRemote(39, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(39, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_039()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 117, 195, 17, 173, 251 };
        var h = d.HashState(40, bytes);
        d.ReceiveRemote(40, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(40, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_040()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 120, 200, 24, 184, 8 };
        var h = d.HashState(41, bytes);
        d.ReceiveRemote(41, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(41, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_041()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 123, 205, 31, 195, 21 };
        var h = d.HashState(42, bytes);
        d.ReceiveRemote(42, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(42, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_042()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 126, 210, 38, 206, 34 };
        var h = d.HashState(43, bytes);
        d.ReceiveRemote(43, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(43, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_043()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 129, 215, 45, 217, 47 };
        var h = d.HashState(44, bytes);
        d.ReceiveRemote(44, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(44, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_044()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 132, 220, 52, 228, 60 };
        var h = d.HashState(45, bytes);
        d.ReceiveRemote(45, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(45, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_045()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 135, 225, 59, 239, 73 };
        var h = d.HashState(46, bytes);
        d.ReceiveRemote(46, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(46, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_046()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 138, 230, 66, 250, 86 };
        var h = d.HashState(47, bytes);
        d.ReceiveRemote(47, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(47, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_047()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 141, 235, 73, 5, 99 };
        var h = d.HashState(48, bytes);
        d.ReceiveRemote(48, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(48, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_048()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 144, 240, 80, 16, 112 };
        var h = d.HashState(49, bytes);
        d.ReceiveRemote(49, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(49, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_049()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 147, 245, 87, 27, 125 };
        var h = d.HashState(50, bytes);
        d.ReceiveRemote(50, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(50, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_050()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 150, 250, 94, 38, 138 };
        var h = d.HashState(51, bytes);
        d.ReceiveRemote(51, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(51, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_051()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 153, 255, 101, 49, 151 };
        var h = d.HashState(52, bytes);
        d.ReceiveRemote(52, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(52, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_052()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 156, 4, 108, 60, 164 };
        var h = d.HashState(53, bytes);
        d.ReceiveRemote(53, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(53, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_053()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 159, 9, 115, 71, 177 };
        var h = d.HashState(54, bytes);
        d.ReceiveRemote(54, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(54, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_054()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 162, 14, 122, 82, 190 };
        var h = d.HashState(55, bytes);
        d.ReceiveRemote(55, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(55, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_055()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 165, 19, 129, 93, 203 };
        var h = d.HashState(56, bytes);
        d.ReceiveRemote(56, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(56, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_056()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 168, 24, 136, 104, 216 };
        var h = d.HashState(57, bytes);
        d.ReceiveRemote(57, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(57, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_057()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 171, 29, 143, 115, 229 };
        var h = d.HashState(58, bytes);
        d.ReceiveRemote(58, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(58, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_058()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 174, 34, 150, 126, 242 };
        var h = d.HashState(59, bytes);
        d.ReceiveRemote(59, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(59, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_059()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 177, 39, 157, 137, 255 };
        var h = d.HashState(60, bytes);
        d.ReceiveRemote(60, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(60, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_060()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 180, 44, 164, 148, 12 };
        var h = d.HashState(61, bytes);
        d.ReceiveRemote(61, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(61, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_061()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 183, 49, 171, 159, 25 };
        var h = d.HashState(62, bytes);
        d.ReceiveRemote(62, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(62, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_062()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 186, 54, 178, 170, 38 };
        var h = d.HashState(63, bytes);
        d.ReceiveRemote(63, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(63, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_063()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 189, 59, 185, 181, 51 };
        var h = d.HashState(64, bytes);
        d.ReceiveRemote(64, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(64, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_064()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 192, 64, 192, 192, 64 };
        var h = d.HashState(65, bytes);
        d.ReceiveRemote(65, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(65, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_065()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 195, 69, 199, 203, 77 };
        var h = d.HashState(66, bytes);
        d.ReceiveRemote(66, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(66, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_066()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 198, 74, 206, 214, 90 };
        var h = d.HashState(67, bytes);
        d.ReceiveRemote(67, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(67, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_067()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 201, 79, 213, 225, 103 };
        var h = d.HashState(68, bytes);
        d.ReceiveRemote(68, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(68, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_068()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 204, 84, 220, 236, 116 };
        var h = d.HashState(69, bytes);
        d.ReceiveRemote(69, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(69, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_069()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 207, 89, 227, 247, 129 };
        var h = d.HashState(70, bytes);
        d.ReceiveRemote(70, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(70, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_070()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 210, 94, 234, 2, 142 };
        var h = d.HashState(71, bytes);
        d.ReceiveRemote(71, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(71, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_071()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 213, 99, 241, 13, 155 };
        var h = d.HashState(72, bytes);
        d.ReceiveRemote(72, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(72, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_072()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 216, 104, 248, 24, 168 };
        var h = d.HashState(73, bytes);
        d.ReceiveRemote(73, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(73, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_073()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 219, 109, 255, 35, 181 };
        var h = d.HashState(74, bytes);
        d.ReceiveRemote(74, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(74, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_074()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 222, 114, 6, 46, 194 };
        var h = d.HashState(75, bytes);
        d.ReceiveRemote(75, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(75, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_075()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 225, 119, 13, 57, 207 };
        var h = d.HashState(76, bytes);
        d.ReceiveRemote(76, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(76, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_076()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 228, 124, 20, 68, 220 };
        var h = d.HashState(77, bytes);
        d.ReceiveRemote(77, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(77, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_077()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 231, 129, 27, 79, 233 };
        var h = d.HashState(78, bytes);
        d.ReceiveRemote(78, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(78, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_078()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 234, 134, 34, 90, 246 };
        var h = d.HashState(79, bytes);
        d.ReceiveRemote(79, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(79, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_079()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 237, 139, 41, 101, 3 };
        var h = d.HashState(80, bytes);
        d.ReceiveRemote(80, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(80, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_080()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 240, 144, 48, 112, 16 };
        var h = d.HashState(81, bytes);
        d.ReceiveRemote(81, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(81, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_081()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 243, 149, 55, 123, 29 };
        var h = d.HashState(82, bytes);
        d.ReceiveRemote(82, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(82, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_082()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 246, 154, 62, 134, 42 };
        var h = d.HashState(83, bytes);
        d.ReceiveRemote(83, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(83, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_083()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 249, 159, 69, 145, 55 };
        var h = d.HashState(84, bytes);
        d.ReceiveRemote(84, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(84, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_084()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 252, 164, 76, 156, 68 };
        var h = d.HashState(85, bytes);
        d.ReceiveRemote(85, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(85, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_085()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 255, 169, 83, 167, 81 };
        var h = d.HashState(86, bytes);
        d.ReceiveRemote(86, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(86, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_086()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 2, 174, 90, 178, 94 };
        var h = d.HashState(87, bytes);
        d.ReceiveRemote(87, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(87, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_087()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 5, 179, 97, 189, 107 };
        var h = d.HashState(88, bytes);
        d.ReceiveRemote(88, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(88, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_088()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 8, 184, 104, 200, 120 };
        var h = d.HashState(89, bytes);
        d.ReceiveRemote(89, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(89, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_089()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 11, 189, 111, 211, 133 };
        var h = d.HashState(90, bytes);
        d.ReceiveRemote(90, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(90, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_090()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 14, 194, 118, 222, 146 };
        var h = d.HashState(91, bytes);
        d.ReceiveRemote(91, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(91, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_091()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 17, 199, 125, 233, 159 };
        var h = d.HashState(92, bytes);
        d.ReceiveRemote(92, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(92, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_092()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 20, 204, 132, 244, 172 };
        var h = d.HashState(93, bytes);
        d.ReceiveRemote(93, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(93, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_093()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 23, 209, 139, 255, 185 };
        var h = d.HashState(94, bytes);
        d.ReceiveRemote(94, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(94, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_094()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 26, 214, 146, 10, 198 };
        var h = d.HashState(95, bytes);
        d.ReceiveRemote(95, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(95, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_095()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 29, 219, 153, 21, 211 };
        var h = d.HashState(96, bytes);
        d.ReceiveRemote(96, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(96, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_096()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 32, 224, 160, 32, 224 };
        var h = d.HashState(97, bytes);
        d.ReceiveRemote(97, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(97, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_097()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 35, 229, 167, 43, 237 };
        var h = d.HashState(98, bytes);
        d.ReceiveRemote(98, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(98, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_098()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 38, 234, 174, 54, 250 };
        var h = d.HashState(99, bytes);
        d.ReceiveRemote(99, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(99, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_099()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 41, 239, 181, 65, 7 };
        var h = d.HashState(100, bytes);
        d.ReceiveRemote(100, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(100, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_100()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 44, 244, 188, 76, 20 };
        var h = d.HashState(101, bytes);
        d.ReceiveRemote(101, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(101, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_101()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 47, 249, 195, 87, 33 };
        var h = d.HashState(102, bytes);
        d.ReceiveRemote(102, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(102, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_102()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 50, 254, 202, 98, 46 };
        var h = d.HashState(103, bytes);
        d.ReceiveRemote(103, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(103, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_103()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 53, 3, 209, 109, 59 };
        var h = d.HashState(104, bytes);
        d.ReceiveRemote(104, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(104, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_104()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 56, 8, 216, 120, 72 };
        var h = d.HashState(105, bytes);
        d.ReceiveRemote(105, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(105, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_105()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 59, 13, 223, 131, 85 };
        var h = d.HashState(106, bytes);
        d.ReceiveRemote(106, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(106, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_106()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 62, 18, 230, 142, 98 };
        var h = d.HashState(107, bytes);
        d.ReceiveRemote(107, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(107, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_107()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 65, 23, 237, 153, 111 };
        var h = d.HashState(108, bytes);
        d.ReceiveRemote(108, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(108, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_108()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 68, 28, 244, 164, 124 };
        var h = d.HashState(109, bytes);
        d.ReceiveRemote(109, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(109, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_109()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 71, 33, 251, 175, 137 };
        var h = d.HashState(110, bytes);
        d.ReceiveRemote(110, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(110, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_110()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 74, 38, 2, 186, 150 };
        var h = d.HashState(111, bytes);
        d.ReceiveRemote(111, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(111, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_111()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 77, 43, 9, 197, 163 };
        var h = d.HashState(112, bytes);
        d.ReceiveRemote(112, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(112, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_112()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 80, 48, 16, 208, 176 };
        var h = d.HashState(113, bytes);
        d.ReceiveRemote(113, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(113, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_113()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 83, 53, 23, 219, 189 };
        var h = d.HashState(114, bytes);
        d.ReceiveRemote(114, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(114, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_114()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 86, 58, 30, 230, 202 };
        var h = d.HashState(115, bytes);
        d.ReceiveRemote(115, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(115, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_115()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 89, 63, 37, 241, 215 };
        var h = d.HashState(116, bytes);
        d.ReceiveRemote(116, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(116, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_116()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 92, 68, 44, 252, 228 };
        var h = d.HashState(117, bytes);
        d.ReceiveRemote(117, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(117, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_117()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 95, 73, 51, 7, 241 };
        var h = d.HashState(118, bytes);
        d.ReceiveRemote(118, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(118, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_118()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 98, 78, 58, 18, 254 };
        var h = d.HashState(119, bytes);
        d.ReceiveRemote(119, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(119, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_119()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 101, 83, 65, 29, 11 };
        var h = d.HashState(120, bytes);
        d.ReceiveRemote(120, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(120, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_120()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 104, 88, 72, 40, 24 };
        var h = d.HashState(121, bytes);
        d.ReceiveRemote(121, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(121, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_121()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 107, 93, 79, 51, 37 };
        var h = d.HashState(122, bytes);
        d.ReceiveRemote(122, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(122, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_122()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 110, 98, 86, 62, 50 };
        var h = d.HashState(123, bytes);
        d.ReceiveRemote(123, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(123, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_123()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 113, 103, 93, 73, 63 };
        var h = d.HashState(124, bytes);
        d.ReceiveRemote(124, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(124, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_124()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 116, 108, 100, 84, 76 };
        var h = d.HashState(125, bytes);
        d.ReceiveRemote(125, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(125, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_125()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 119, 113, 107, 95, 89 };
        var h = d.HashState(126, bytes);
        d.ReceiveRemote(126, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(126, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_126()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 122, 118, 114, 106, 102 };
        var h = d.HashState(127, bytes);
        d.ReceiveRemote(127, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(127, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_127()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 125, 123, 121, 117, 115 };
        var h = d.HashState(128, bytes);
        d.ReceiveRemote(128, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(128, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_128()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 128, 128, 128, 128, 128 };
        var h = d.HashState(129, bytes);
        d.ReceiveRemote(129, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(129, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_129()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 131, 133, 135, 139, 141 };
        var h = d.HashState(130, bytes);
        d.ReceiveRemote(130, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(130, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_130()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 134, 138, 142, 150, 154 };
        var h = d.HashState(131, bytes);
        d.ReceiveRemote(131, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(131, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_131()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 137, 143, 149, 161, 167 };
        var h = d.HashState(132, bytes);
        d.ReceiveRemote(132, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(132, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_132()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 140, 148, 156, 172, 180 };
        var h = d.HashState(133, bytes);
        d.ReceiveRemote(133, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(133, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_133()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 143, 153, 163, 183, 193 };
        var h = d.HashState(134, bytes);
        d.ReceiveRemote(134, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(134, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_134()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 146, 158, 170, 194, 206 };
        var h = d.HashState(135, bytes);
        d.ReceiveRemote(135, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(135, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_135()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 149, 163, 177, 205, 219 };
        var h = d.HashState(136, bytes);
        d.ReceiveRemote(136, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(136, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_136()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 152, 168, 184, 216, 232 };
        var h = d.HashState(137, bytes);
        d.ReceiveRemote(137, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(137, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_137()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 155, 173, 191, 227, 245 };
        var h = d.HashState(138, bytes);
        d.ReceiveRemote(138, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(138, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_138()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 158, 178, 198, 238, 2 };
        var h = d.HashState(139, bytes);
        d.ReceiveRemote(139, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(139, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_139()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 161, 183, 205, 249, 15 };
        var h = d.HashState(140, bytes);
        d.ReceiveRemote(140, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(140, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_140()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 164, 188, 212, 4, 28 };
        var h = d.HashState(141, bytes);
        d.ReceiveRemote(141, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(141, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_141()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 167, 193, 219, 15, 41 };
        var h = d.HashState(142, bytes);
        d.ReceiveRemote(142, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(142, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_142()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 170, 198, 226, 26, 54 };
        var h = d.HashState(143, bytes);
        d.ReceiveRemote(143, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(143, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_143()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 173, 203, 233, 37, 67 };
        var h = d.HashState(144, bytes);
        d.ReceiveRemote(144, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(144, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_144()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 176, 208, 240, 48, 80 };
        var h = d.HashState(145, bytes);
        d.ReceiveRemote(145, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(145, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_145()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 179, 213, 247, 59, 93 };
        var h = d.HashState(146, bytes);
        d.ReceiveRemote(146, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(146, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_146()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 182, 218, 254, 70, 106 };
        var h = d.HashState(147, bytes);
        d.ReceiveRemote(147, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(147, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_147()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 185, 223, 5, 81, 119 };
        var h = d.HashState(148, bytes);
        d.ReceiveRemote(148, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(148, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_148()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 188, 228, 12, 92, 132 };
        var h = d.HashState(149, bytes);
        d.ReceiveRemote(149, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(149, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_149()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 191, 233, 19, 103, 145 };
        var h = d.HashState(150, bytes);
        d.ReceiveRemote(150, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(150, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_150()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 194, 238, 26, 114, 158 };
        var h = d.HashState(151, bytes);
        d.ReceiveRemote(151, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(151, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_151()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 197, 243, 33, 125, 171 };
        var h = d.HashState(152, bytes);
        d.ReceiveRemote(152, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(152, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_152()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 200, 248, 40, 136, 184 };
        var h = d.HashState(153, bytes);
        d.ReceiveRemote(153, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(153, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_153()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 203, 253, 47, 147, 197 };
        var h = d.HashState(154, bytes);
        d.ReceiveRemote(154, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(154, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_154()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 206, 2, 54, 158, 210 };
        var h = d.HashState(155, bytes);
        d.ReceiveRemote(155, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(155, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_155()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 209, 7, 61, 169, 223 };
        var h = d.HashState(156, bytes);
        d.ReceiveRemote(156, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(156, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_156()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 212, 12, 68, 180, 236 };
        var h = d.HashState(157, bytes);
        d.ReceiveRemote(157, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(157, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_157()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 215, 17, 75, 191, 249 };
        var h = d.HashState(158, bytes);
        d.ReceiveRemote(158, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(158, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_158()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 218, 22, 82, 202, 6 };
        var h = d.HashState(159, bytes);
        d.ReceiveRemote(159, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(159, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_159()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 221, 27, 89, 213, 19 };
        var h = d.HashState(160, bytes);
        d.ReceiveRemote(160, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(160, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_160()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 224, 32, 96, 224, 32 };
        var h = d.HashState(161, bytes);
        d.ReceiveRemote(161, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(161, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_161()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 227, 37, 103, 235, 45 };
        var h = d.HashState(162, bytes);
        d.ReceiveRemote(162, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(162, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_162()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 230, 42, 110, 246, 58 };
        var h = d.HashState(163, bytes);
        d.ReceiveRemote(163, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(163, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_163()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 233, 47, 117, 1, 71 };
        var h = d.HashState(164, bytes);
        d.ReceiveRemote(164, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(164, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_164()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 236, 52, 124, 12, 84 };
        var h = d.HashState(165, bytes);
        d.ReceiveRemote(165, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(165, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_165()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 239, 57, 131, 23, 97 };
        var h = d.HashState(166, bytes);
        d.ReceiveRemote(166, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(166, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_166()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 242, 62, 138, 34, 110 };
        var h = d.HashState(167, bytes);
        d.ReceiveRemote(167, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(167, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_167()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 245, 67, 145, 45, 123 };
        var h = d.HashState(168, bytes);
        d.ReceiveRemote(168, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(168, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_168()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 248, 72, 152, 56, 136 };
        var h = d.HashState(169, bytes);
        d.ReceiveRemote(169, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(169, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_169()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 251, 77, 159, 67, 149 };
        var h = d.HashState(170, bytes);
        d.ReceiveRemote(170, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(170, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_170()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 254, 82, 166, 78, 162 };
        var h = d.HashState(171, bytes);
        d.ReceiveRemote(171, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(171, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_171()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 1, 87, 173, 89, 175 };
        var h = d.HashState(172, bytes);
        d.ReceiveRemote(172, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(172, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_172()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 4, 92, 180, 100, 188 };
        var h = d.HashState(173, bytes);
        d.ReceiveRemote(173, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(173, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_173()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 7, 97, 187, 111, 201 };
        var h = d.HashState(174, bytes);
        d.ReceiveRemote(174, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(174, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_174()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 10, 102, 194, 122, 214 };
        var h = d.HashState(175, bytes);
        d.ReceiveRemote(175, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(175, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_175()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 13, 107, 201, 133, 227 };
        var h = d.HashState(176, bytes);
        d.ReceiveRemote(176, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(176, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_176()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 16, 112, 208, 144, 240 };
        var h = d.HashState(177, bytes);
        d.ReceiveRemote(177, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(177, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_177()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 19, 117, 215, 155, 253 };
        var h = d.HashState(178, bytes);
        d.ReceiveRemote(178, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(178, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_178()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 22, 122, 222, 166, 10 };
        var h = d.HashState(179, bytes);
        d.ReceiveRemote(179, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(179, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_179()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 25, 127, 229, 177, 23 };
        var h = d.HashState(180, bytes);
        d.ReceiveRemote(180, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(180, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_180()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 28, 132, 236, 188, 36 };
        var h = d.HashState(181, bytes);
        d.ReceiveRemote(181, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(181, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_181()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 31, 137, 243, 199, 49 };
        var h = d.HashState(182, bytes);
        d.ReceiveRemote(182, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(182, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_182()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 34, 142, 250, 210, 62 };
        var h = d.HashState(183, bytes);
        d.ReceiveRemote(183, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(183, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_183()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 37, 147, 1, 221, 75 };
        var h = d.HashState(184, bytes);
        d.ReceiveRemote(184, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(184, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_184()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 40, 152, 8, 232, 88 };
        var h = d.HashState(185, bytes);
        d.ReceiveRemote(185, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(185, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_185()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 43, 157, 15, 243, 101 };
        var h = d.HashState(186, bytes);
        d.ReceiveRemote(186, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(186, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_186()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 46, 162, 22, 254, 114 };
        var h = d.HashState(187, bytes);
        d.ReceiveRemote(187, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(187, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_187()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 49, 167, 29, 9, 127 };
        var h = d.HashState(188, bytes);
        d.ReceiveRemote(188, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(188, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_188()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 52, 172, 36, 20, 140 };
        var h = d.HashState(189, bytes);
        d.ReceiveRemote(189, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(189, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_189()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 55, 177, 43, 31, 153 };
        var h = d.HashState(190, bytes);
        d.ReceiveRemote(190, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(190, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_190()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 58, 182, 50, 42, 166 };
        var h = d.HashState(191, bytes);
        d.ReceiveRemote(191, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(191, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_191()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 61, 187, 57, 53, 179 };
        var h = d.HashState(192, bytes);
        d.ReceiveRemote(192, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(192, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_192()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 64, 192, 64, 64, 192 };
        var h = d.HashState(193, bytes);
        d.ReceiveRemote(193, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(193, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_193()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 67, 197, 71, 75, 205 };
        var h = d.HashState(194, bytes);
        d.ReceiveRemote(194, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(194, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_194()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 70, 202, 78, 86, 218 };
        var h = d.HashState(195, bytes);
        d.ReceiveRemote(195, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(195, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_195()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 73, 207, 85, 97, 231 };
        var h = d.HashState(196, bytes);
        d.ReceiveRemote(196, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(196, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_196()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 76, 212, 92, 108, 244 };
        var h = d.HashState(197, bytes);
        d.ReceiveRemote(197, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(197, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_197()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 79, 217, 99, 119, 1 };
        var h = d.HashState(198, bytes);
        d.ReceiveRemote(198, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(198, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_198()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 82, 222, 106, 130, 14 };
        var h = d.HashState(199, bytes);
        d.ReceiveRemote(199, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(199, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }

    [Fact]
    public void Corpus_199()
    {
        var d = new DesyncDetection();
        var bytes = new byte[] { 85, 227, 113, 141, 27 };
        var h = d.HashState(200, bytes);
        d.ReceiveRemote(200, h);
        Assert.False(d.HasDesynced);
        d.ReceiveRemote(200, h ^ 0xA5A5A5A5u);
        Assert.True(d.HasDesynced);
    }
}

