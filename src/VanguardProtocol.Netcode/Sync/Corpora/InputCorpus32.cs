namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus32
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 32, 32),
        new ReplayFrame(1, 35, 37),
        new ReplayFrame(2, 38, 42),
        new ReplayFrame(3, 41, 47),
        new ReplayFrame(4, 44, 52),
        new ReplayFrame(5, 47, 57),
        new ReplayFrame(6, 50, 62),
        new ReplayFrame(7, 53, 67),
        new ReplayFrame(8, 56, 72),
        new ReplayFrame(9, 59, 77),
        new ReplayFrame(10, 62, 82),
        new ReplayFrame(11, 65, 87),
        new ReplayFrame(12, 68, 92),
        new ReplayFrame(13, 71, 97),
        new ReplayFrame(14, 74, 102),
        new ReplayFrame(15, 77, 107),
        new ReplayFrame(16, 80, 112),
        new ReplayFrame(17, 83, 117),
        new ReplayFrame(18, 86, 122),
        new ReplayFrame(19, 89, 127),
        new ReplayFrame(20, 92, 132),
        new ReplayFrame(21, 95, 137),
        new ReplayFrame(22, 98, 142),
        new ReplayFrame(23, 101, 147),
        new ReplayFrame(24, 104, 152),
        new ReplayFrame(25, 107, 157),
        new ReplayFrame(26, 110, 162),
        new ReplayFrame(27, 113, 167),
        new ReplayFrame(28, 116, 172),
        new ReplayFrame(29, 119, 177),
        new ReplayFrame(30, 122, 182),
        new ReplayFrame(31, 125, 187),
        new ReplayFrame(32, 128, 192),
        new ReplayFrame(33, 131, 197),
        new ReplayFrame(34, 134, 202),
        new ReplayFrame(35, 137, 207),
        new ReplayFrame(36, 140, 212),
        new ReplayFrame(37, 143, 217),
        new ReplayFrame(38, 146, 222),
        new ReplayFrame(39, 149, 227),
        new ReplayFrame(40, 152, 232),
        new ReplayFrame(41, 155, 237),
        new ReplayFrame(42, 158, 242),
        new ReplayFrame(43, 161, 247),
        new ReplayFrame(44, 164, 252),
        new ReplayFrame(45, 167, 257),
        new ReplayFrame(46, 170, 262),
        new ReplayFrame(47, 173, 267),
        new ReplayFrame(48, 176, 272),
        new ReplayFrame(49, 179, 277),
        new ReplayFrame(50, 182, 282),
        new ReplayFrame(51, 185, 287),
        new ReplayFrame(52, 188, 292),
        new ReplayFrame(53, 191, 297),
        new ReplayFrame(54, 194, 302),
        new ReplayFrame(55, 197, 307),
        new ReplayFrame(56, 200, 312),
        new ReplayFrame(57, 203, 317),
        new ReplayFrame(58, 206, 322),
        new ReplayFrame(59, 209, 327),
        new ReplayFrame(60, 212, 332),
        new ReplayFrame(61, 215, 337),
        new ReplayFrame(62, 218, 342),
        new ReplayFrame(63, 221, 347),
        new ReplayFrame(64, 224, 352),
        new ReplayFrame(65, 227, 357),
        new ReplayFrame(66, 230, 362),
        new ReplayFrame(67, 233, 367),
        new ReplayFrame(68, 236, 372),
        new ReplayFrame(69, 239, 377),
        new ReplayFrame(70, 242, 382),
        new ReplayFrame(71, 245, 387),
        new ReplayFrame(72, 248, 392),
        new ReplayFrame(73, 251, 397),
        new ReplayFrame(74, 254, 402),
        new ReplayFrame(75, 257, 407),
        new ReplayFrame(76, 260, 412),
        new ReplayFrame(77, 263, 417),
        new ReplayFrame(78, 266, 422),
        new ReplayFrame(79, 269, 427)
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
