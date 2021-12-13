namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus52
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 52, 52),
        new ReplayFrame(1, 55, 57),
        new ReplayFrame(2, 58, 62),
        new ReplayFrame(3, 61, 67),
        new ReplayFrame(4, 64, 72),
        new ReplayFrame(5, 67, 77),
        new ReplayFrame(6, 70, 82),
        new ReplayFrame(7, 73, 87),
        new ReplayFrame(8, 76, 92),
        new ReplayFrame(9, 79, 97),
        new ReplayFrame(10, 82, 102),
        new ReplayFrame(11, 85, 107),
        new ReplayFrame(12, 88, 112),
        new ReplayFrame(13, 91, 117),
        new ReplayFrame(14, 94, 122),
        new ReplayFrame(15, 97, 127),
        new ReplayFrame(16, 100, 132),
        new ReplayFrame(17, 103, 137),
        new ReplayFrame(18, 106, 142),
        new ReplayFrame(19, 109, 147),
        new ReplayFrame(20, 112, 152),
        new ReplayFrame(21, 115, 157),
        new ReplayFrame(22, 118, 162),
        new ReplayFrame(23, 121, 167),
        new ReplayFrame(24, 124, 172),
        new ReplayFrame(25, 127, 177),
        new ReplayFrame(26, 130, 182),
        new ReplayFrame(27, 133, 187),
        new ReplayFrame(28, 136, 192),
        new ReplayFrame(29, 139, 197),
        new ReplayFrame(30, 142, 202),
        new ReplayFrame(31, 145, 207),
        new ReplayFrame(32, 148, 212),
        new ReplayFrame(33, 151, 217),
        new ReplayFrame(34, 154, 222),
        new ReplayFrame(35, 157, 227),
        new ReplayFrame(36, 160, 232),
        new ReplayFrame(37, 163, 237),
        new ReplayFrame(38, 166, 242),
        new ReplayFrame(39, 169, 247),
        new ReplayFrame(40, 172, 252),
        new ReplayFrame(41, 175, 257),
        new ReplayFrame(42, 178, 262),
        new ReplayFrame(43, 181, 267),
        new ReplayFrame(44, 184, 272),
        new ReplayFrame(45, 187, 277),
        new ReplayFrame(46, 190, 282),
        new ReplayFrame(47, 193, 287),
        new ReplayFrame(48, 196, 292),
        new ReplayFrame(49, 199, 297),
        new ReplayFrame(50, 202, 302),
        new ReplayFrame(51, 205, 307),
        new ReplayFrame(52, 208, 312),
        new ReplayFrame(53, 211, 317),
        new ReplayFrame(54, 214, 322),
        new ReplayFrame(55, 217, 327),
        new ReplayFrame(56, 220, 332),
        new ReplayFrame(57, 223, 337),
        new ReplayFrame(58, 226, 342),
        new ReplayFrame(59, 229, 347),
        new ReplayFrame(60, 232, 352),
        new ReplayFrame(61, 235, 357),
        new ReplayFrame(62, 238, 362),
        new ReplayFrame(63, 241, 367),
        new ReplayFrame(64, 244, 372),
        new ReplayFrame(65, 247, 377),
        new ReplayFrame(66, 250, 382),
        new ReplayFrame(67, 253, 387),
        new ReplayFrame(68, 256, 392),
        new ReplayFrame(69, 259, 397),
        new ReplayFrame(70, 262, 402),
        new ReplayFrame(71, 265, 407),
        new ReplayFrame(72, 268, 412),
        new ReplayFrame(73, 271, 417),
        new ReplayFrame(74, 274, 422),
        new ReplayFrame(75, 277, 427),
        new ReplayFrame(76, 280, 432),
        new ReplayFrame(77, 283, 437),
        new ReplayFrame(78, 286, 442),
        new ReplayFrame(79, 289, 447)
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
