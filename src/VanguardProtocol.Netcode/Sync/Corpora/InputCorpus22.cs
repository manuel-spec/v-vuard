namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus22
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 22, 22),
        new ReplayFrame(1, 25, 27),
        new ReplayFrame(2, 28, 32),
        new ReplayFrame(3, 31, 37),
        new ReplayFrame(4, 34, 42),
        new ReplayFrame(5, 37, 47),
        new ReplayFrame(6, 40, 52),
        new ReplayFrame(7, 43, 57),
        new ReplayFrame(8, 46, 62),
        new ReplayFrame(9, 49, 67),
        new ReplayFrame(10, 52, 72),
        new ReplayFrame(11, 55, 77),
        new ReplayFrame(12, 58, 82),
        new ReplayFrame(13, 61, 87),
        new ReplayFrame(14, 64, 92),
        new ReplayFrame(15, 67, 97),
        new ReplayFrame(16, 70, 102),
        new ReplayFrame(17, 73, 107),
        new ReplayFrame(18, 76, 112),
        new ReplayFrame(19, 79, 117),
        new ReplayFrame(20, 82, 122),
        new ReplayFrame(21, 85, 127),
        new ReplayFrame(22, 88, 132),
        new ReplayFrame(23, 91, 137),
        new ReplayFrame(24, 94, 142),
        new ReplayFrame(25, 97, 147),
        new ReplayFrame(26, 100, 152),
        new ReplayFrame(27, 103, 157),
        new ReplayFrame(28, 106, 162),
        new ReplayFrame(29, 109, 167),
        new ReplayFrame(30, 112, 172),
        new ReplayFrame(31, 115, 177),
        new ReplayFrame(32, 118, 182),
        new ReplayFrame(33, 121, 187),
        new ReplayFrame(34, 124, 192),
        new ReplayFrame(35, 127, 197),
        new ReplayFrame(36, 130, 202),
        new ReplayFrame(37, 133, 207),
        new ReplayFrame(38, 136, 212),
        new ReplayFrame(39, 139, 217),
        new ReplayFrame(40, 142, 222),
        new ReplayFrame(41, 145, 227),
        new ReplayFrame(42, 148, 232),
        new ReplayFrame(43, 151, 237),
        new ReplayFrame(44, 154, 242),
        new ReplayFrame(45, 157, 247),
        new ReplayFrame(46, 160, 252),
        new ReplayFrame(47, 163, 257),
        new ReplayFrame(48, 166, 262),
        new ReplayFrame(49, 169, 267),
        new ReplayFrame(50, 172, 272),
        new ReplayFrame(51, 175, 277),
        new ReplayFrame(52, 178, 282),
        new ReplayFrame(53, 181, 287),
        new ReplayFrame(54, 184, 292),
        new ReplayFrame(55, 187, 297),
        new ReplayFrame(56, 190, 302),
        new ReplayFrame(57, 193, 307),
        new ReplayFrame(58, 196, 312),
        new ReplayFrame(59, 199, 317),
        new ReplayFrame(60, 202, 322),
        new ReplayFrame(61, 205, 327),
        new ReplayFrame(62, 208, 332),
        new ReplayFrame(63, 211, 337),
        new ReplayFrame(64, 214, 342),
        new ReplayFrame(65, 217, 347),
        new ReplayFrame(66, 220, 352),
        new ReplayFrame(67, 223, 357),
        new ReplayFrame(68, 226, 362),
        new ReplayFrame(69, 229, 367),
        new ReplayFrame(70, 232, 372),
        new ReplayFrame(71, 235, 377),
        new ReplayFrame(72, 238, 382),
        new ReplayFrame(73, 241, 387),
        new ReplayFrame(74, 244, 392),
        new ReplayFrame(75, 247, 397),
        new ReplayFrame(76, 250, 402),
        new ReplayFrame(77, 253, 407),
        new ReplayFrame(78, 256, 412),
        new ReplayFrame(79, 259, 417)
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
