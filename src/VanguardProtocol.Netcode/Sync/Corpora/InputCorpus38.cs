namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus38
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 38, 38),
        new ReplayFrame(1, 41, 43),
        new ReplayFrame(2, 44, 48),
        new ReplayFrame(3, 47, 53),
        new ReplayFrame(4, 50, 58),
        new ReplayFrame(5, 53, 63),
        new ReplayFrame(6, 56, 68),
        new ReplayFrame(7, 59, 73),
        new ReplayFrame(8, 62, 78),
        new ReplayFrame(9, 65, 83),
        new ReplayFrame(10, 68, 88),
        new ReplayFrame(11, 71, 93),
        new ReplayFrame(12, 74, 98),
        new ReplayFrame(13, 77, 103),
        new ReplayFrame(14, 80, 108),
        new ReplayFrame(15, 83, 113),
        new ReplayFrame(16, 86, 118),
        new ReplayFrame(17, 89, 123),
        new ReplayFrame(18, 92, 128),
        new ReplayFrame(19, 95, 133),
        new ReplayFrame(20, 98, 138),
        new ReplayFrame(21, 101, 143),
        new ReplayFrame(22, 104, 148),
        new ReplayFrame(23, 107, 153),
        new ReplayFrame(24, 110, 158),
        new ReplayFrame(25, 113, 163),
        new ReplayFrame(26, 116, 168),
        new ReplayFrame(27, 119, 173),
        new ReplayFrame(28, 122, 178),
        new ReplayFrame(29, 125, 183),
        new ReplayFrame(30, 128, 188),
        new ReplayFrame(31, 131, 193),
        new ReplayFrame(32, 134, 198),
        new ReplayFrame(33, 137, 203),
        new ReplayFrame(34, 140, 208),
        new ReplayFrame(35, 143, 213),
        new ReplayFrame(36, 146, 218),
        new ReplayFrame(37, 149, 223),
        new ReplayFrame(38, 152, 228),
        new ReplayFrame(39, 155, 233),
        new ReplayFrame(40, 158, 238),
        new ReplayFrame(41, 161, 243),
        new ReplayFrame(42, 164, 248),
        new ReplayFrame(43, 167, 253),
        new ReplayFrame(44, 170, 258),
        new ReplayFrame(45, 173, 263),
        new ReplayFrame(46, 176, 268),
        new ReplayFrame(47, 179, 273),
        new ReplayFrame(48, 182, 278),
        new ReplayFrame(49, 185, 283),
        new ReplayFrame(50, 188, 288),
        new ReplayFrame(51, 191, 293),
        new ReplayFrame(52, 194, 298),
        new ReplayFrame(53, 197, 303),
        new ReplayFrame(54, 200, 308),
        new ReplayFrame(55, 203, 313),
        new ReplayFrame(56, 206, 318),
        new ReplayFrame(57, 209, 323),
        new ReplayFrame(58, 212, 328),
        new ReplayFrame(59, 215, 333),
        new ReplayFrame(60, 218, 338),
        new ReplayFrame(61, 221, 343),
        new ReplayFrame(62, 224, 348),
        new ReplayFrame(63, 227, 353),
        new ReplayFrame(64, 230, 358),
        new ReplayFrame(65, 233, 363),
        new ReplayFrame(66, 236, 368),
        new ReplayFrame(67, 239, 373),
        new ReplayFrame(68, 242, 378),
        new ReplayFrame(69, 245, 383),
        new ReplayFrame(70, 248, 388),
        new ReplayFrame(71, 251, 393),
        new ReplayFrame(72, 254, 398),
        new ReplayFrame(73, 257, 403),
        new ReplayFrame(74, 260, 408),
        new ReplayFrame(75, 263, 413),
        new ReplayFrame(76, 266, 418),
        new ReplayFrame(77, 269, 423),
        new ReplayFrame(78, 272, 428),
        new ReplayFrame(79, 275, 433)
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
