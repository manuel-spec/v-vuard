namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus07
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 7, 7),
        new ReplayFrame(1, 10, 12),
        new ReplayFrame(2, 13, 17),
        new ReplayFrame(3, 16, 22),
        new ReplayFrame(4, 19, 27),
        new ReplayFrame(5, 22, 32),
        new ReplayFrame(6, 25, 37),
        new ReplayFrame(7, 28, 42),
        new ReplayFrame(8, 31, 47),
        new ReplayFrame(9, 34, 52),
        new ReplayFrame(10, 37, 57),
        new ReplayFrame(11, 40, 62),
        new ReplayFrame(12, 43, 67),
        new ReplayFrame(13, 46, 72),
        new ReplayFrame(14, 49, 77),
        new ReplayFrame(15, 52, 82),
        new ReplayFrame(16, 55, 87),
        new ReplayFrame(17, 58, 92),
        new ReplayFrame(18, 61, 97),
        new ReplayFrame(19, 64, 102),
        new ReplayFrame(20, 67, 107),
        new ReplayFrame(21, 70, 112),
        new ReplayFrame(22, 73, 117),
        new ReplayFrame(23, 76, 122),
        new ReplayFrame(24, 79, 127),
        new ReplayFrame(25, 82, 132),
        new ReplayFrame(26, 85, 137),
        new ReplayFrame(27, 88, 142),
        new ReplayFrame(28, 91, 147),
        new ReplayFrame(29, 94, 152),
        new ReplayFrame(30, 97, 157),
        new ReplayFrame(31, 100, 162),
        new ReplayFrame(32, 103, 167),
        new ReplayFrame(33, 106, 172),
        new ReplayFrame(34, 109, 177),
        new ReplayFrame(35, 112, 182),
        new ReplayFrame(36, 115, 187),
        new ReplayFrame(37, 118, 192),
        new ReplayFrame(38, 121, 197),
        new ReplayFrame(39, 124, 202),
        new ReplayFrame(40, 127, 207),
        new ReplayFrame(41, 130, 212),
        new ReplayFrame(42, 133, 217),
        new ReplayFrame(43, 136, 222),
        new ReplayFrame(44, 139, 227),
        new ReplayFrame(45, 142, 232),
        new ReplayFrame(46, 145, 237),
        new ReplayFrame(47, 148, 242),
        new ReplayFrame(48, 151, 247),
        new ReplayFrame(49, 154, 252),
        new ReplayFrame(50, 157, 257),
        new ReplayFrame(51, 160, 262),
        new ReplayFrame(52, 163, 267),
        new ReplayFrame(53, 166, 272),
        new ReplayFrame(54, 169, 277),
        new ReplayFrame(55, 172, 282),
        new ReplayFrame(56, 175, 287),
        new ReplayFrame(57, 178, 292),
        new ReplayFrame(58, 181, 297),
        new ReplayFrame(59, 184, 302),
        new ReplayFrame(60, 187, 307),
        new ReplayFrame(61, 190, 312),
        new ReplayFrame(62, 193, 317),
        new ReplayFrame(63, 196, 322),
        new ReplayFrame(64, 199, 327),
        new ReplayFrame(65, 202, 332),
        new ReplayFrame(66, 205, 337),
        new ReplayFrame(67, 208, 342),
        new ReplayFrame(68, 211, 347),
        new ReplayFrame(69, 214, 352),
        new ReplayFrame(70, 217, 357),
        new ReplayFrame(71, 220, 362),
        new ReplayFrame(72, 223, 367),
        new ReplayFrame(73, 226, 372),
        new ReplayFrame(74, 229, 377),
        new ReplayFrame(75, 232, 382),
        new ReplayFrame(76, 235, 387),
        new ReplayFrame(77, 238, 392),
        new ReplayFrame(78, 241, 397),
        new ReplayFrame(79, 244, 402)
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
