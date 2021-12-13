namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus58
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 58, 58),
        new ReplayFrame(1, 61, 63),
        new ReplayFrame(2, 64, 68),
        new ReplayFrame(3, 67, 73),
        new ReplayFrame(4, 70, 78),
        new ReplayFrame(5, 73, 83),
        new ReplayFrame(6, 76, 88),
        new ReplayFrame(7, 79, 93),
        new ReplayFrame(8, 82, 98),
        new ReplayFrame(9, 85, 103),
        new ReplayFrame(10, 88, 108),
        new ReplayFrame(11, 91, 113),
        new ReplayFrame(12, 94, 118),
        new ReplayFrame(13, 97, 123),
        new ReplayFrame(14, 100, 128),
        new ReplayFrame(15, 103, 133),
        new ReplayFrame(16, 106, 138),
        new ReplayFrame(17, 109, 143),
        new ReplayFrame(18, 112, 148),
        new ReplayFrame(19, 115, 153),
        new ReplayFrame(20, 118, 158),
        new ReplayFrame(21, 121, 163),
        new ReplayFrame(22, 124, 168),
        new ReplayFrame(23, 127, 173),
        new ReplayFrame(24, 130, 178),
        new ReplayFrame(25, 133, 183),
        new ReplayFrame(26, 136, 188),
        new ReplayFrame(27, 139, 193),
        new ReplayFrame(28, 142, 198),
        new ReplayFrame(29, 145, 203),
        new ReplayFrame(30, 148, 208),
        new ReplayFrame(31, 151, 213),
        new ReplayFrame(32, 154, 218),
        new ReplayFrame(33, 157, 223),
        new ReplayFrame(34, 160, 228),
        new ReplayFrame(35, 163, 233),
        new ReplayFrame(36, 166, 238),
        new ReplayFrame(37, 169, 243),
        new ReplayFrame(38, 172, 248),
        new ReplayFrame(39, 175, 253),
        new ReplayFrame(40, 178, 258),
        new ReplayFrame(41, 181, 263),
        new ReplayFrame(42, 184, 268),
        new ReplayFrame(43, 187, 273),
        new ReplayFrame(44, 190, 278),
        new ReplayFrame(45, 193, 283),
        new ReplayFrame(46, 196, 288),
        new ReplayFrame(47, 199, 293),
        new ReplayFrame(48, 202, 298),
        new ReplayFrame(49, 205, 303),
        new ReplayFrame(50, 208, 308),
        new ReplayFrame(51, 211, 313),
        new ReplayFrame(52, 214, 318),
        new ReplayFrame(53, 217, 323),
        new ReplayFrame(54, 220, 328),
        new ReplayFrame(55, 223, 333),
        new ReplayFrame(56, 226, 338),
        new ReplayFrame(57, 229, 343),
        new ReplayFrame(58, 232, 348),
        new ReplayFrame(59, 235, 353),
        new ReplayFrame(60, 238, 358),
        new ReplayFrame(61, 241, 363),
        new ReplayFrame(62, 244, 368),
        new ReplayFrame(63, 247, 373),
        new ReplayFrame(64, 250, 378),
        new ReplayFrame(65, 253, 383),
        new ReplayFrame(66, 256, 388),
        new ReplayFrame(67, 259, 393),
        new ReplayFrame(68, 262, 398),
        new ReplayFrame(69, 265, 403),
        new ReplayFrame(70, 268, 408),
        new ReplayFrame(71, 271, 413),
        new ReplayFrame(72, 274, 418),
        new ReplayFrame(73, 277, 423),
        new ReplayFrame(74, 280, 428),
        new ReplayFrame(75, 283, 433),
        new ReplayFrame(76, 286, 438),
        new ReplayFrame(77, 289, 443),
        new ReplayFrame(78, 292, 448),
        new ReplayFrame(79, 295, 453)
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
