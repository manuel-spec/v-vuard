namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus02
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 2, 2),
        new ReplayFrame(1, 5, 7),
        new ReplayFrame(2, 8, 12),
        new ReplayFrame(3, 11, 17),
        new ReplayFrame(4, 14, 22),
        new ReplayFrame(5, 17, 27),
        new ReplayFrame(6, 20, 32),
        new ReplayFrame(7, 23, 37),
        new ReplayFrame(8, 26, 42),
        new ReplayFrame(9, 29, 47),
        new ReplayFrame(10, 32, 52),
        new ReplayFrame(11, 35, 57),
        new ReplayFrame(12, 38, 62),
        new ReplayFrame(13, 41, 67),
        new ReplayFrame(14, 44, 72),
        new ReplayFrame(15, 47, 77),
        new ReplayFrame(16, 50, 82),
        new ReplayFrame(17, 53, 87),
        new ReplayFrame(18, 56, 92),
        new ReplayFrame(19, 59, 97),
        new ReplayFrame(20, 62, 102),
        new ReplayFrame(21, 65, 107),
        new ReplayFrame(22, 68, 112),
        new ReplayFrame(23, 71, 117),
        new ReplayFrame(24, 74, 122),
        new ReplayFrame(25, 77, 127),
        new ReplayFrame(26, 80, 132),
        new ReplayFrame(27, 83, 137),
        new ReplayFrame(28, 86, 142),
        new ReplayFrame(29, 89, 147),
        new ReplayFrame(30, 92, 152),
        new ReplayFrame(31, 95, 157),
        new ReplayFrame(32, 98, 162),
        new ReplayFrame(33, 101, 167),
        new ReplayFrame(34, 104, 172),
        new ReplayFrame(35, 107, 177),
        new ReplayFrame(36, 110, 182),
        new ReplayFrame(37, 113, 187),
        new ReplayFrame(38, 116, 192),
        new ReplayFrame(39, 119, 197),
        new ReplayFrame(40, 122, 202),
        new ReplayFrame(41, 125, 207),
        new ReplayFrame(42, 128, 212),
        new ReplayFrame(43, 131, 217),
        new ReplayFrame(44, 134, 222),
        new ReplayFrame(45, 137, 227),
        new ReplayFrame(46, 140, 232),
        new ReplayFrame(47, 143, 237),
        new ReplayFrame(48, 146, 242),
        new ReplayFrame(49, 149, 247),
        new ReplayFrame(50, 152, 252),
        new ReplayFrame(51, 155, 257),
        new ReplayFrame(52, 158, 262),
        new ReplayFrame(53, 161, 267),
        new ReplayFrame(54, 164, 272),
        new ReplayFrame(55, 167, 277),
        new ReplayFrame(56, 170, 282),
        new ReplayFrame(57, 173, 287),
        new ReplayFrame(58, 176, 292),
        new ReplayFrame(59, 179, 297),
        new ReplayFrame(60, 182, 302),
        new ReplayFrame(61, 185, 307),
        new ReplayFrame(62, 188, 312),
        new ReplayFrame(63, 191, 317),
        new ReplayFrame(64, 194, 322),
        new ReplayFrame(65, 197, 327),
        new ReplayFrame(66, 200, 332),
        new ReplayFrame(67, 203, 337),
        new ReplayFrame(68, 206, 342),
        new ReplayFrame(69, 209, 347),
        new ReplayFrame(70, 212, 352),
        new ReplayFrame(71, 215, 357),
        new ReplayFrame(72, 218, 362),
        new ReplayFrame(73, 221, 367),
        new ReplayFrame(74, 224, 372),
        new ReplayFrame(75, 227, 377),
        new ReplayFrame(76, 230, 382),
        new ReplayFrame(77, 233, 387),
        new ReplayFrame(78, 236, 392),
        new ReplayFrame(79, 239, 397)
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
