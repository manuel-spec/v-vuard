namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus37
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 37, 37),
        new ReplayFrame(1, 40, 42),
        new ReplayFrame(2, 43, 47),
        new ReplayFrame(3, 46, 52),
        new ReplayFrame(4, 49, 57),
        new ReplayFrame(5, 52, 62),
        new ReplayFrame(6, 55, 67),
        new ReplayFrame(7, 58, 72),
        new ReplayFrame(8, 61, 77),
        new ReplayFrame(9, 64, 82),
        new ReplayFrame(10, 67, 87),
        new ReplayFrame(11, 70, 92),
        new ReplayFrame(12, 73, 97),
        new ReplayFrame(13, 76, 102),
        new ReplayFrame(14, 79, 107),
        new ReplayFrame(15, 82, 112),
        new ReplayFrame(16, 85, 117),
        new ReplayFrame(17, 88, 122),
        new ReplayFrame(18, 91, 127),
        new ReplayFrame(19, 94, 132),
        new ReplayFrame(20, 97, 137),
        new ReplayFrame(21, 100, 142),
        new ReplayFrame(22, 103, 147),
        new ReplayFrame(23, 106, 152),
        new ReplayFrame(24, 109, 157),
        new ReplayFrame(25, 112, 162),
        new ReplayFrame(26, 115, 167),
        new ReplayFrame(27, 118, 172),
        new ReplayFrame(28, 121, 177),
        new ReplayFrame(29, 124, 182),
        new ReplayFrame(30, 127, 187),
        new ReplayFrame(31, 130, 192),
        new ReplayFrame(32, 133, 197),
        new ReplayFrame(33, 136, 202),
        new ReplayFrame(34, 139, 207),
        new ReplayFrame(35, 142, 212),
        new ReplayFrame(36, 145, 217),
        new ReplayFrame(37, 148, 222),
        new ReplayFrame(38, 151, 227),
        new ReplayFrame(39, 154, 232),
        new ReplayFrame(40, 157, 237),
        new ReplayFrame(41, 160, 242),
        new ReplayFrame(42, 163, 247),
        new ReplayFrame(43, 166, 252),
        new ReplayFrame(44, 169, 257),
        new ReplayFrame(45, 172, 262),
        new ReplayFrame(46, 175, 267),
        new ReplayFrame(47, 178, 272),
        new ReplayFrame(48, 181, 277),
        new ReplayFrame(49, 184, 282),
        new ReplayFrame(50, 187, 287),
        new ReplayFrame(51, 190, 292),
        new ReplayFrame(52, 193, 297),
        new ReplayFrame(53, 196, 302),
        new ReplayFrame(54, 199, 307),
        new ReplayFrame(55, 202, 312),
        new ReplayFrame(56, 205, 317),
        new ReplayFrame(57, 208, 322),
        new ReplayFrame(58, 211, 327),
        new ReplayFrame(59, 214, 332),
        new ReplayFrame(60, 217, 337),
        new ReplayFrame(61, 220, 342),
        new ReplayFrame(62, 223, 347),
        new ReplayFrame(63, 226, 352),
        new ReplayFrame(64, 229, 357),
        new ReplayFrame(65, 232, 362),
        new ReplayFrame(66, 235, 367),
        new ReplayFrame(67, 238, 372),
        new ReplayFrame(68, 241, 377),
        new ReplayFrame(69, 244, 382),
        new ReplayFrame(70, 247, 387),
        new ReplayFrame(71, 250, 392),
        new ReplayFrame(72, 253, 397),
        new ReplayFrame(73, 256, 402),
        new ReplayFrame(74, 259, 407),
        new ReplayFrame(75, 262, 412),
        new ReplayFrame(76, 265, 417),
        new ReplayFrame(77, 268, 422),
        new ReplayFrame(78, 271, 427),
        new ReplayFrame(79, 274, 432)
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
