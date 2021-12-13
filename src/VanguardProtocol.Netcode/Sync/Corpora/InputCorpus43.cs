namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus43
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 43, 43),
        new ReplayFrame(1, 46, 48),
        new ReplayFrame(2, 49, 53),
        new ReplayFrame(3, 52, 58),
        new ReplayFrame(4, 55, 63),
        new ReplayFrame(5, 58, 68),
        new ReplayFrame(6, 61, 73),
        new ReplayFrame(7, 64, 78),
        new ReplayFrame(8, 67, 83),
        new ReplayFrame(9, 70, 88),
        new ReplayFrame(10, 73, 93),
        new ReplayFrame(11, 76, 98),
        new ReplayFrame(12, 79, 103),
        new ReplayFrame(13, 82, 108),
        new ReplayFrame(14, 85, 113),
        new ReplayFrame(15, 88, 118),
        new ReplayFrame(16, 91, 123),
        new ReplayFrame(17, 94, 128),
        new ReplayFrame(18, 97, 133),
        new ReplayFrame(19, 100, 138),
        new ReplayFrame(20, 103, 143),
        new ReplayFrame(21, 106, 148),
        new ReplayFrame(22, 109, 153),
        new ReplayFrame(23, 112, 158),
        new ReplayFrame(24, 115, 163),
        new ReplayFrame(25, 118, 168),
        new ReplayFrame(26, 121, 173),
        new ReplayFrame(27, 124, 178),
        new ReplayFrame(28, 127, 183),
        new ReplayFrame(29, 130, 188),
        new ReplayFrame(30, 133, 193),
        new ReplayFrame(31, 136, 198),
        new ReplayFrame(32, 139, 203),
        new ReplayFrame(33, 142, 208),
        new ReplayFrame(34, 145, 213),
        new ReplayFrame(35, 148, 218),
        new ReplayFrame(36, 151, 223),
        new ReplayFrame(37, 154, 228),
        new ReplayFrame(38, 157, 233),
        new ReplayFrame(39, 160, 238),
        new ReplayFrame(40, 163, 243),
        new ReplayFrame(41, 166, 248),
        new ReplayFrame(42, 169, 253),
        new ReplayFrame(43, 172, 258),
        new ReplayFrame(44, 175, 263),
        new ReplayFrame(45, 178, 268),
        new ReplayFrame(46, 181, 273),
        new ReplayFrame(47, 184, 278),
        new ReplayFrame(48, 187, 283),
        new ReplayFrame(49, 190, 288),
        new ReplayFrame(50, 193, 293),
        new ReplayFrame(51, 196, 298),
        new ReplayFrame(52, 199, 303),
        new ReplayFrame(53, 202, 308),
        new ReplayFrame(54, 205, 313),
        new ReplayFrame(55, 208, 318),
        new ReplayFrame(56, 211, 323),
        new ReplayFrame(57, 214, 328),
        new ReplayFrame(58, 217, 333),
        new ReplayFrame(59, 220, 338),
        new ReplayFrame(60, 223, 343),
        new ReplayFrame(61, 226, 348),
        new ReplayFrame(62, 229, 353),
        new ReplayFrame(63, 232, 358),
        new ReplayFrame(64, 235, 363),
        new ReplayFrame(65, 238, 368),
        new ReplayFrame(66, 241, 373),
        new ReplayFrame(67, 244, 378),
        new ReplayFrame(68, 247, 383),
        new ReplayFrame(69, 250, 388),
        new ReplayFrame(70, 253, 393),
        new ReplayFrame(71, 256, 398),
        new ReplayFrame(72, 259, 403),
        new ReplayFrame(73, 262, 408),
        new ReplayFrame(74, 265, 413),
        new ReplayFrame(75, 268, 418),
        new ReplayFrame(76, 271, 423),
        new ReplayFrame(77, 274, 428),
        new ReplayFrame(78, 277, 433),
        new ReplayFrame(79, 280, 438)
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
