namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus17
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 17, 17),
        new ReplayFrame(1, 20, 22),
        new ReplayFrame(2, 23, 27),
        new ReplayFrame(3, 26, 32),
        new ReplayFrame(4, 29, 37),
        new ReplayFrame(5, 32, 42),
        new ReplayFrame(6, 35, 47),
        new ReplayFrame(7, 38, 52),
        new ReplayFrame(8, 41, 57),
        new ReplayFrame(9, 44, 62),
        new ReplayFrame(10, 47, 67),
        new ReplayFrame(11, 50, 72),
        new ReplayFrame(12, 53, 77),
        new ReplayFrame(13, 56, 82),
        new ReplayFrame(14, 59, 87),
        new ReplayFrame(15, 62, 92),
        new ReplayFrame(16, 65, 97),
        new ReplayFrame(17, 68, 102),
        new ReplayFrame(18, 71, 107),
        new ReplayFrame(19, 74, 112),
        new ReplayFrame(20, 77, 117),
        new ReplayFrame(21, 80, 122),
        new ReplayFrame(22, 83, 127),
        new ReplayFrame(23, 86, 132),
        new ReplayFrame(24, 89, 137),
        new ReplayFrame(25, 92, 142),
        new ReplayFrame(26, 95, 147),
        new ReplayFrame(27, 98, 152),
        new ReplayFrame(28, 101, 157),
        new ReplayFrame(29, 104, 162),
        new ReplayFrame(30, 107, 167),
        new ReplayFrame(31, 110, 172),
        new ReplayFrame(32, 113, 177),
        new ReplayFrame(33, 116, 182),
        new ReplayFrame(34, 119, 187),
        new ReplayFrame(35, 122, 192),
        new ReplayFrame(36, 125, 197),
        new ReplayFrame(37, 128, 202),
        new ReplayFrame(38, 131, 207),
        new ReplayFrame(39, 134, 212),
        new ReplayFrame(40, 137, 217),
        new ReplayFrame(41, 140, 222),
        new ReplayFrame(42, 143, 227),
        new ReplayFrame(43, 146, 232),
        new ReplayFrame(44, 149, 237),
        new ReplayFrame(45, 152, 242),
        new ReplayFrame(46, 155, 247),
        new ReplayFrame(47, 158, 252),
        new ReplayFrame(48, 161, 257),
        new ReplayFrame(49, 164, 262),
        new ReplayFrame(50, 167, 267),
        new ReplayFrame(51, 170, 272),
        new ReplayFrame(52, 173, 277),
        new ReplayFrame(53, 176, 282),
        new ReplayFrame(54, 179, 287),
        new ReplayFrame(55, 182, 292),
        new ReplayFrame(56, 185, 297),
        new ReplayFrame(57, 188, 302),
        new ReplayFrame(58, 191, 307),
        new ReplayFrame(59, 194, 312),
        new ReplayFrame(60, 197, 317),
        new ReplayFrame(61, 200, 322),
        new ReplayFrame(62, 203, 327),
        new ReplayFrame(63, 206, 332),
        new ReplayFrame(64, 209, 337),
        new ReplayFrame(65, 212, 342),
        new ReplayFrame(66, 215, 347),
        new ReplayFrame(67, 218, 352),
        new ReplayFrame(68, 221, 357),
        new ReplayFrame(69, 224, 362),
        new ReplayFrame(70, 227, 367),
        new ReplayFrame(71, 230, 372),
        new ReplayFrame(72, 233, 377),
        new ReplayFrame(73, 236, 382),
        new ReplayFrame(74, 239, 387),
        new ReplayFrame(75, 242, 392),
        new ReplayFrame(76, 245, 397),
        new ReplayFrame(77, 248, 402),
        new ReplayFrame(78, 251, 407),
        new ReplayFrame(79, 254, 412)
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
