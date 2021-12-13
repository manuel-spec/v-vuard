namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus13
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 13, 13),
        new ReplayFrame(1, 16, 18),
        new ReplayFrame(2, 19, 23),
        new ReplayFrame(3, 22, 28),
        new ReplayFrame(4, 25, 33),
        new ReplayFrame(5, 28, 38),
        new ReplayFrame(6, 31, 43),
        new ReplayFrame(7, 34, 48),
        new ReplayFrame(8, 37, 53),
        new ReplayFrame(9, 40, 58),
        new ReplayFrame(10, 43, 63),
        new ReplayFrame(11, 46, 68),
        new ReplayFrame(12, 49, 73),
        new ReplayFrame(13, 52, 78),
        new ReplayFrame(14, 55, 83),
        new ReplayFrame(15, 58, 88),
        new ReplayFrame(16, 61, 93),
        new ReplayFrame(17, 64, 98),
        new ReplayFrame(18, 67, 103),
        new ReplayFrame(19, 70, 108),
        new ReplayFrame(20, 73, 113),
        new ReplayFrame(21, 76, 118),
        new ReplayFrame(22, 79, 123),
        new ReplayFrame(23, 82, 128),
        new ReplayFrame(24, 85, 133),
        new ReplayFrame(25, 88, 138),
        new ReplayFrame(26, 91, 143),
        new ReplayFrame(27, 94, 148),
        new ReplayFrame(28, 97, 153),
        new ReplayFrame(29, 100, 158),
        new ReplayFrame(30, 103, 163),
        new ReplayFrame(31, 106, 168),
        new ReplayFrame(32, 109, 173),
        new ReplayFrame(33, 112, 178),
        new ReplayFrame(34, 115, 183),
        new ReplayFrame(35, 118, 188),
        new ReplayFrame(36, 121, 193),
        new ReplayFrame(37, 124, 198),
        new ReplayFrame(38, 127, 203),
        new ReplayFrame(39, 130, 208),
        new ReplayFrame(40, 133, 213),
        new ReplayFrame(41, 136, 218),
        new ReplayFrame(42, 139, 223),
        new ReplayFrame(43, 142, 228),
        new ReplayFrame(44, 145, 233),
        new ReplayFrame(45, 148, 238),
        new ReplayFrame(46, 151, 243),
        new ReplayFrame(47, 154, 248),
        new ReplayFrame(48, 157, 253),
        new ReplayFrame(49, 160, 258),
        new ReplayFrame(50, 163, 263),
        new ReplayFrame(51, 166, 268),
        new ReplayFrame(52, 169, 273),
        new ReplayFrame(53, 172, 278),
        new ReplayFrame(54, 175, 283),
        new ReplayFrame(55, 178, 288),
        new ReplayFrame(56, 181, 293),
        new ReplayFrame(57, 184, 298),
        new ReplayFrame(58, 187, 303),
        new ReplayFrame(59, 190, 308),
        new ReplayFrame(60, 193, 313),
        new ReplayFrame(61, 196, 318),
        new ReplayFrame(62, 199, 323),
        new ReplayFrame(63, 202, 328),
        new ReplayFrame(64, 205, 333),
        new ReplayFrame(65, 208, 338),
        new ReplayFrame(66, 211, 343),
        new ReplayFrame(67, 214, 348),
        new ReplayFrame(68, 217, 353),
        new ReplayFrame(69, 220, 358),
        new ReplayFrame(70, 223, 363),
        new ReplayFrame(71, 226, 368),
        new ReplayFrame(72, 229, 373),
        new ReplayFrame(73, 232, 378),
        new ReplayFrame(74, 235, 383),
        new ReplayFrame(75, 238, 388),
        new ReplayFrame(76, 241, 393),
        new ReplayFrame(77, 244, 398),
        new ReplayFrame(78, 247, 403),
        new ReplayFrame(79, 250, 408)
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
