namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus12
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 12, 12),
        new ReplayFrame(1, 15, 17),
        new ReplayFrame(2, 18, 22),
        new ReplayFrame(3, 21, 27),
        new ReplayFrame(4, 24, 32),
        new ReplayFrame(5, 27, 37),
        new ReplayFrame(6, 30, 42),
        new ReplayFrame(7, 33, 47),
        new ReplayFrame(8, 36, 52),
        new ReplayFrame(9, 39, 57),
        new ReplayFrame(10, 42, 62),
        new ReplayFrame(11, 45, 67),
        new ReplayFrame(12, 48, 72),
        new ReplayFrame(13, 51, 77),
        new ReplayFrame(14, 54, 82),
        new ReplayFrame(15, 57, 87),
        new ReplayFrame(16, 60, 92),
        new ReplayFrame(17, 63, 97),
        new ReplayFrame(18, 66, 102),
        new ReplayFrame(19, 69, 107),
        new ReplayFrame(20, 72, 112),
        new ReplayFrame(21, 75, 117),
        new ReplayFrame(22, 78, 122),
        new ReplayFrame(23, 81, 127),
        new ReplayFrame(24, 84, 132),
        new ReplayFrame(25, 87, 137),
        new ReplayFrame(26, 90, 142),
        new ReplayFrame(27, 93, 147),
        new ReplayFrame(28, 96, 152),
        new ReplayFrame(29, 99, 157),
        new ReplayFrame(30, 102, 162),
        new ReplayFrame(31, 105, 167),
        new ReplayFrame(32, 108, 172),
        new ReplayFrame(33, 111, 177),
        new ReplayFrame(34, 114, 182),
        new ReplayFrame(35, 117, 187),
        new ReplayFrame(36, 120, 192),
        new ReplayFrame(37, 123, 197),
        new ReplayFrame(38, 126, 202),
        new ReplayFrame(39, 129, 207),
        new ReplayFrame(40, 132, 212),
        new ReplayFrame(41, 135, 217),
        new ReplayFrame(42, 138, 222),
        new ReplayFrame(43, 141, 227),
        new ReplayFrame(44, 144, 232),
        new ReplayFrame(45, 147, 237),
        new ReplayFrame(46, 150, 242),
        new ReplayFrame(47, 153, 247),
        new ReplayFrame(48, 156, 252),
        new ReplayFrame(49, 159, 257),
        new ReplayFrame(50, 162, 262),
        new ReplayFrame(51, 165, 267),
        new ReplayFrame(52, 168, 272),
        new ReplayFrame(53, 171, 277),
        new ReplayFrame(54, 174, 282),
        new ReplayFrame(55, 177, 287),
        new ReplayFrame(56, 180, 292),
        new ReplayFrame(57, 183, 297),
        new ReplayFrame(58, 186, 302),
        new ReplayFrame(59, 189, 307),
        new ReplayFrame(60, 192, 312),
        new ReplayFrame(61, 195, 317),
        new ReplayFrame(62, 198, 322),
        new ReplayFrame(63, 201, 327),
        new ReplayFrame(64, 204, 332),
        new ReplayFrame(65, 207, 337),
        new ReplayFrame(66, 210, 342),
        new ReplayFrame(67, 213, 347),
        new ReplayFrame(68, 216, 352),
        new ReplayFrame(69, 219, 357),
        new ReplayFrame(70, 222, 362),
        new ReplayFrame(71, 225, 367),
        new ReplayFrame(72, 228, 372),
        new ReplayFrame(73, 231, 377),
        new ReplayFrame(74, 234, 382),
        new ReplayFrame(75, 237, 387),
        new ReplayFrame(76, 240, 392),
        new ReplayFrame(77, 243, 397),
        new ReplayFrame(78, 246, 402),
        new ReplayFrame(79, 249, 407)
    ];

    public static uint FoldChecksum()
    {
        uint h = 2166136261u;
        foreach (var f in Frames)
        {
            h ^= (uint)f.Frame; h *= 16777619u;
            h ^= f.Buttons; h *= 16777619u;
            h ^= f.Pressed; h *= 16777619u;
        }
        return h;
    }
}
