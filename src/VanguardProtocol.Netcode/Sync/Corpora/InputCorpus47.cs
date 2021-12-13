namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus47
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 47, 47),
        new ReplayFrame(1, 50, 52),
        new ReplayFrame(2, 53, 57),
        new ReplayFrame(3, 56, 62),
        new ReplayFrame(4, 59, 67),
        new ReplayFrame(5, 62, 72),
        new ReplayFrame(6, 65, 77),
        new ReplayFrame(7, 68, 82),
        new ReplayFrame(8, 71, 87),
        new ReplayFrame(9, 74, 92),
        new ReplayFrame(10, 77, 97),
        new ReplayFrame(11, 80, 102),
        new ReplayFrame(12, 83, 107),
        new ReplayFrame(13, 86, 112),
        new ReplayFrame(14, 89, 117),
        new ReplayFrame(15, 92, 122),
        new ReplayFrame(16, 95, 127),
        new ReplayFrame(17, 98, 132),
        new ReplayFrame(18, 101, 137),
        new ReplayFrame(19, 104, 142),
        new ReplayFrame(20, 107, 147),
        new ReplayFrame(21, 110, 152),
        new ReplayFrame(22, 113, 157),
        new ReplayFrame(23, 116, 162),
        new ReplayFrame(24, 119, 167),
        new ReplayFrame(25, 122, 172),
        new ReplayFrame(26, 125, 177),
        new ReplayFrame(27, 128, 182),
        new ReplayFrame(28, 131, 187),
        new ReplayFrame(29, 134, 192),
        new ReplayFrame(30, 137, 197),
        new ReplayFrame(31, 140, 202),
        new ReplayFrame(32, 143, 207),
        new ReplayFrame(33, 146, 212),
        new ReplayFrame(34, 149, 217),
        new ReplayFrame(35, 152, 222),
        new ReplayFrame(36, 155, 227),
        new ReplayFrame(37, 158, 232),
        new ReplayFrame(38, 161, 237),
        new ReplayFrame(39, 164, 242),
        new ReplayFrame(40, 167, 247),
        new ReplayFrame(41, 170, 252),
        new ReplayFrame(42, 173, 257),
        new ReplayFrame(43, 176, 262),
        new ReplayFrame(44, 179, 267),
        new ReplayFrame(45, 182, 272),
        new ReplayFrame(46, 185, 277),
        new ReplayFrame(47, 188, 282),
        new ReplayFrame(48, 191, 287),
        new ReplayFrame(49, 194, 292),
        new ReplayFrame(50, 197, 297),
        new ReplayFrame(51, 200, 302),
        new ReplayFrame(52, 203, 307),
        new ReplayFrame(53, 206, 312),
        new ReplayFrame(54, 209, 317),
        new ReplayFrame(55, 212, 322),
        new ReplayFrame(56, 215, 327),
        new ReplayFrame(57, 218, 332),
        new ReplayFrame(58, 221, 337),
        new ReplayFrame(59, 224, 342),
        new ReplayFrame(60, 227, 347),
        new ReplayFrame(61, 230, 352),
        new ReplayFrame(62, 233, 357),
        new ReplayFrame(63, 236, 362),
        new ReplayFrame(64, 239, 367),
        new ReplayFrame(65, 242, 372),
        new ReplayFrame(66, 245, 377),
        new ReplayFrame(67, 248, 382),
        new ReplayFrame(68, 251, 387),
        new ReplayFrame(69, 254, 392),
        new ReplayFrame(70, 257, 397),
        new ReplayFrame(71, 260, 402),
        new ReplayFrame(72, 263, 407),
        new ReplayFrame(73, 266, 412),
        new ReplayFrame(74, 269, 417),
        new ReplayFrame(75, 272, 422),
        new ReplayFrame(76, 275, 427),
        new ReplayFrame(77, 278, 432),
        new ReplayFrame(78, 281, 437),
        new ReplayFrame(79, 284, 442)
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
