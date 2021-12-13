namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus53
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 53, 53),
        new ReplayFrame(1, 56, 58),
        new ReplayFrame(2, 59, 63),
        new ReplayFrame(3, 62, 68),
        new ReplayFrame(4, 65, 73),
        new ReplayFrame(5, 68, 78),
        new ReplayFrame(6, 71, 83),
        new ReplayFrame(7, 74, 88),
        new ReplayFrame(8, 77, 93),
        new ReplayFrame(9, 80, 98),
        new ReplayFrame(10, 83, 103),
        new ReplayFrame(11, 86, 108),
        new ReplayFrame(12, 89, 113),
        new ReplayFrame(13, 92, 118),
        new ReplayFrame(14, 95, 123),
        new ReplayFrame(15, 98, 128),
        new ReplayFrame(16, 101, 133),
        new ReplayFrame(17, 104, 138),
        new ReplayFrame(18, 107, 143),
        new ReplayFrame(19, 110, 148),
        new ReplayFrame(20, 113, 153),
        new ReplayFrame(21, 116, 158),
        new ReplayFrame(22, 119, 163),
        new ReplayFrame(23, 122, 168),
        new ReplayFrame(24, 125, 173),
        new ReplayFrame(25, 128, 178),
        new ReplayFrame(26, 131, 183),
        new ReplayFrame(27, 134, 188),
        new ReplayFrame(28, 137, 193),
        new ReplayFrame(29, 140, 198),
        new ReplayFrame(30, 143, 203),
        new ReplayFrame(31, 146, 208),
        new ReplayFrame(32, 149, 213),
        new ReplayFrame(33, 152, 218),
        new ReplayFrame(34, 155, 223),
        new ReplayFrame(35, 158, 228),
        new ReplayFrame(36, 161, 233),
        new ReplayFrame(37, 164, 238),
        new ReplayFrame(38, 167, 243),
        new ReplayFrame(39, 170, 248),
        new ReplayFrame(40, 173, 253),
        new ReplayFrame(41, 176, 258),
        new ReplayFrame(42, 179, 263),
        new ReplayFrame(43, 182, 268),
        new ReplayFrame(44, 185, 273),
        new ReplayFrame(45, 188, 278),
        new ReplayFrame(46, 191, 283),
        new ReplayFrame(47, 194, 288),
        new ReplayFrame(48, 197, 293),
        new ReplayFrame(49, 200, 298),
        new ReplayFrame(50, 203, 303),
        new ReplayFrame(51, 206, 308),
        new ReplayFrame(52, 209, 313),
        new ReplayFrame(53, 212, 318),
        new ReplayFrame(54, 215, 323),
        new ReplayFrame(55, 218, 328),
        new ReplayFrame(56, 221, 333),
        new ReplayFrame(57, 224, 338),
        new ReplayFrame(58, 227, 343),
        new ReplayFrame(59, 230, 348),
        new ReplayFrame(60, 233, 353),
        new ReplayFrame(61, 236, 358),
        new ReplayFrame(62, 239, 363),
        new ReplayFrame(63, 242, 368),
        new ReplayFrame(64, 245, 373),
        new ReplayFrame(65, 248, 378),
        new ReplayFrame(66, 251, 383),
        new ReplayFrame(67, 254, 388),
        new ReplayFrame(68, 257, 393),
        new ReplayFrame(69, 260, 398),
        new ReplayFrame(70, 263, 403),
        new ReplayFrame(71, 266, 408),
        new ReplayFrame(72, 269, 413),
        new ReplayFrame(73, 272, 418),
        new ReplayFrame(74, 275, 423),
        new ReplayFrame(75, 278, 428),
        new ReplayFrame(76, 281, 433),
        new ReplayFrame(77, 284, 438),
        new ReplayFrame(78, 287, 443),
        new ReplayFrame(79, 290, 448)
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
