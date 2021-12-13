namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus08
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 8, 8),
        new ReplayFrame(1, 11, 13),
        new ReplayFrame(2, 14, 18),
        new ReplayFrame(3, 17, 23),
        new ReplayFrame(4, 20, 28),
        new ReplayFrame(5, 23, 33),
        new ReplayFrame(6, 26, 38),
        new ReplayFrame(7, 29, 43),
        new ReplayFrame(8, 32, 48),
        new ReplayFrame(9, 35, 53),
        new ReplayFrame(10, 38, 58),
        new ReplayFrame(11, 41, 63),
        new ReplayFrame(12, 44, 68),
        new ReplayFrame(13, 47, 73),
        new ReplayFrame(14, 50, 78),
        new ReplayFrame(15, 53, 83),
        new ReplayFrame(16, 56, 88),
        new ReplayFrame(17, 59, 93),
        new ReplayFrame(18, 62, 98),
        new ReplayFrame(19, 65, 103),
        new ReplayFrame(20, 68, 108),
        new ReplayFrame(21, 71, 113),
        new ReplayFrame(22, 74, 118),
        new ReplayFrame(23, 77, 123),
        new ReplayFrame(24, 80, 128),
        new ReplayFrame(25, 83, 133),
        new ReplayFrame(26, 86, 138),
        new ReplayFrame(27, 89, 143),
        new ReplayFrame(28, 92, 148),
        new ReplayFrame(29, 95, 153),
        new ReplayFrame(30, 98, 158),
        new ReplayFrame(31, 101, 163),
        new ReplayFrame(32, 104, 168),
        new ReplayFrame(33, 107, 173),
        new ReplayFrame(34, 110, 178),
        new ReplayFrame(35, 113, 183),
        new ReplayFrame(36, 116, 188),
        new ReplayFrame(37, 119, 193),
        new ReplayFrame(38, 122, 198),
        new ReplayFrame(39, 125, 203),
        new ReplayFrame(40, 128, 208),
        new ReplayFrame(41, 131, 213),
        new ReplayFrame(42, 134, 218),
        new ReplayFrame(43, 137, 223),
        new ReplayFrame(44, 140, 228),
        new ReplayFrame(45, 143, 233),
        new ReplayFrame(46, 146, 238),
        new ReplayFrame(47, 149, 243),
        new ReplayFrame(48, 152, 248),
        new ReplayFrame(49, 155, 253),
        new ReplayFrame(50, 158, 258),
        new ReplayFrame(51, 161, 263),
        new ReplayFrame(52, 164, 268),
        new ReplayFrame(53, 167, 273),
        new ReplayFrame(54, 170, 278),
        new ReplayFrame(55, 173, 283),
        new ReplayFrame(56, 176, 288),
        new ReplayFrame(57, 179, 293),
        new ReplayFrame(58, 182, 298),
        new ReplayFrame(59, 185, 303),
        new ReplayFrame(60, 188, 308),
        new ReplayFrame(61, 191, 313),
        new ReplayFrame(62, 194, 318),
        new ReplayFrame(63, 197, 323),
        new ReplayFrame(64, 200, 328),
        new ReplayFrame(65, 203, 333),
        new ReplayFrame(66, 206, 338),
        new ReplayFrame(67, 209, 343),
        new ReplayFrame(68, 212, 348),
        new ReplayFrame(69, 215, 353),
        new ReplayFrame(70, 218, 358),
        new ReplayFrame(71, 221, 363),
        new ReplayFrame(72, 224, 368),
        new ReplayFrame(73, 227, 373),
        new ReplayFrame(74, 230, 378),
        new ReplayFrame(75, 233, 383),
        new ReplayFrame(76, 236, 388),
        new ReplayFrame(77, 239, 393),
        new ReplayFrame(78, 242, 398),
        new ReplayFrame(79, 245, 403)
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
