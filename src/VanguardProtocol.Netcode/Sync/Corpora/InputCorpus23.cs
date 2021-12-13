namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus23
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 23, 23),
        new ReplayFrame(1, 26, 28),
        new ReplayFrame(2, 29, 33),
        new ReplayFrame(3, 32, 38),
        new ReplayFrame(4, 35, 43),
        new ReplayFrame(5, 38, 48),
        new ReplayFrame(6, 41, 53),
        new ReplayFrame(7, 44, 58),
        new ReplayFrame(8, 47, 63),
        new ReplayFrame(9, 50, 68),
        new ReplayFrame(10, 53, 73),
        new ReplayFrame(11, 56, 78),
        new ReplayFrame(12, 59, 83),
        new ReplayFrame(13, 62, 88),
        new ReplayFrame(14, 65, 93),
        new ReplayFrame(15, 68, 98),
        new ReplayFrame(16, 71, 103),
        new ReplayFrame(17, 74, 108),
        new ReplayFrame(18, 77, 113),
        new ReplayFrame(19, 80, 118),
        new ReplayFrame(20, 83, 123),
        new ReplayFrame(21, 86, 128),
        new ReplayFrame(22, 89, 133),
        new ReplayFrame(23, 92, 138),
        new ReplayFrame(24, 95, 143),
        new ReplayFrame(25, 98, 148),
        new ReplayFrame(26, 101, 153),
        new ReplayFrame(27, 104, 158),
        new ReplayFrame(28, 107, 163),
        new ReplayFrame(29, 110, 168),
        new ReplayFrame(30, 113, 173),
        new ReplayFrame(31, 116, 178),
        new ReplayFrame(32, 119, 183),
        new ReplayFrame(33, 122, 188),
        new ReplayFrame(34, 125, 193),
        new ReplayFrame(35, 128, 198),
        new ReplayFrame(36, 131, 203),
        new ReplayFrame(37, 134, 208),
        new ReplayFrame(38, 137, 213),
        new ReplayFrame(39, 140, 218),
        new ReplayFrame(40, 143, 223),
        new ReplayFrame(41, 146, 228),
        new ReplayFrame(42, 149, 233),
        new ReplayFrame(43, 152, 238),
        new ReplayFrame(44, 155, 243),
        new ReplayFrame(45, 158, 248),
        new ReplayFrame(46, 161, 253),
        new ReplayFrame(47, 164, 258),
        new ReplayFrame(48, 167, 263),
        new ReplayFrame(49, 170, 268),
        new ReplayFrame(50, 173, 273),
        new ReplayFrame(51, 176, 278),
        new ReplayFrame(52, 179, 283),
        new ReplayFrame(53, 182, 288),
        new ReplayFrame(54, 185, 293),
        new ReplayFrame(55, 188, 298),
        new ReplayFrame(56, 191, 303),
        new ReplayFrame(57, 194, 308),
        new ReplayFrame(58, 197, 313),
        new ReplayFrame(59, 200, 318),
        new ReplayFrame(60, 203, 323),
        new ReplayFrame(61, 206, 328),
        new ReplayFrame(62, 209, 333),
        new ReplayFrame(63, 212, 338),
        new ReplayFrame(64, 215, 343),
        new ReplayFrame(65, 218, 348),
        new ReplayFrame(66, 221, 353),
        new ReplayFrame(67, 224, 358),
        new ReplayFrame(68, 227, 363),
        new ReplayFrame(69, 230, 368),
        new ReplayFrame(70, 233, 373),
        new ReplayFrame(71, 236, 378),
        new ReplayFrame(72, 239, 383),
        new ReplayFrame(73, 242, 388),
        new ReplayFrame(74, 245, 393),
        new ReplayFrame(75, 248, 398),
        new ReplayFrame(76, 251, 403),
        new ReplayFrame(77, 254, 408),
        new ReplayFrame(78, 257, 413),
        new ReplayFrame(79, 260, 418)
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
