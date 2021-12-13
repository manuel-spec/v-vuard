namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus28
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 28, 28),
        new ReplayFrame(1, 31, 33),
        new ReplayFrame(2, 34, 38),
        new ReplayFrame(3, 37, 43),
        new ReplayFrame(4, 40, 48),
        new ReplayFrame(5, 43, 53),
        new ReplayFrame(6, 46, 58),
        new ReplayFrame(7, 49, 63),
        new ReplayFrame(8, 52, 68),
        new ReplayFrame(9, 55, 73),
        new ReplayFrame(10, 58, 78),
        new ReplayFrame(11, 61, 83),
        new ReplayFrame(12, 64, 88),
        new ReplayFrame(13, 67, 93),
        new ReplayFrame(14, 70, 98),
        new ReplayFrame(15, 73, 103),
        new ReplayFrame(16, 76, 108),
        new ReplayFrame(17, 79, 113),
        new ReplayFrame(18, 82, 118),
        new ReplayFrame(19, 85, 123),
        new ReplayFrame(20, 88, 128),
        new ReplayFrame(21, 91, 133),
        new ReplayFrame(22, 94, 138),
        new ReplayFrame(23, 97, 143),
        new ReplayFrame(24, 100, 148),
        new ReplayFrame(25, 103, 153),
        new ReplayFrame(26, 106, 158),
        new ReplayFrame(27, 109, 163),
        new ReplayFrame(28, 112, 168),
        new ReplayFrame(29, 115, 173),
        new ReplayFrame(30, 118, 178),
        new ReplayFrame(31, 121, 183),
        new ReplayFrame(32, 124, 188),
        new ReplayFrame(33, 127, 193),
        new ReplayFrame(34, 130, 198),
        new ReplayFrame(35, 133, 203),
        new ReplayFrame(36, 136, 208),
        new ReplayFrame(37, 139, 213),
        new ReplayFrame(38, 142, 218),
        new ReplayFrame(39, 145, 223),
        new ReplayFrame(40, 148, 228),
        new ReplayFrame(41, 151, 233),
        new ReplayFrame(42, 154, 238),
        new ReplayFrame(43, 157, 243),
        new ReplayFrame(44, 160, 248),
        new ReplayFrame(45, 163, 253),
        new ReplayFrame(46, 166, 258),
        new ReplayFrame(47, 169, 263),
        new ReplayFrame(48, 172, 268),
        new ReplayFrame(49, 175, 273),
        new ReplayFrame(50, 178, 278),
        new ReplayFrame(51, 181, 283),
        new ReplayFrame(52, 184, 288),
        new ReplayFrame(53, 187, 293),
        new ReplayFrame(54, 190, 298),
        new ReplayFrame(55, 193, 303),
        new ReplayFrame(56, 196, 308),
        new ReplayFrame(57, 199, 313),
        new ReplayFrame(58, 202, 318),
        new ReplayFrame(59, 205, 323),
        new ReplayFrame(60, 208, 328),
        new ReplayFrame(61, 211, 333),
        new ReplayFrame(62, 214, 338),
        new ReplayFrame(63, 217, 343),
        new ReplayFrame(64, 220, 348),
        new ReplayFrame(65, 223, 353),
        new ReplayFrame(66, 226, 358),
        new ReplayFrame(67, 229, 363),
        new ReplayFrame(68, 232, 368),
        new ReplayFrame(69, 235, 373),
        new ReplayFrame(70, 238, 378),
        new ReplayFrame(71, 241, 383),
        new ReplayFrame(72, 244, 388),
        new ReplayFrame(73, 247, 393),
        new ReplayFrame(74, 250, 398),
        new ReplayFrame(75, 253, 403),
        new ReplayFrame(76, 256, 408),
        new ReplayFrame(77, 259, 413),
        new ReplayFrame(78, 262, 418),
        new ReplayFrame(79, 265, 423)
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
