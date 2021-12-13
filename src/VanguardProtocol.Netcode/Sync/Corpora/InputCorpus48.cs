namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus48
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 48, 48),
        new ReplayFrame(1, 51, 53),
        new ReplayFrame(2, 54, 58),
        new ReplayFrame(3, 57, 63),
        new ReplayFrame(4, 60, 68),
        new ReplayFrame(5, 63, 73),
        new ReplayFrame(6, 66, 78),
        new ReplayFrame(7, 69, 83),
        new ReplayFrame(8, 72, 88),
        new ReplayFrame(9, 75, 93),
        new ReplayFrame(10, 78, 98),
        new ReplayFrame(11, 81, 103),
        new ReplayFrame(12, 84, 108),
        new ReplayFrame(13, 87, 113),
        new ReplayFrame(14, 90, 118),
        new ReplayFrame(15, 93, 123),
        new ReplayFrame(16, 96, 128),
        new ReplayFrame(17, 99, 133),
        new ReplayFrame(18, 102, 138),
        new ReplayFrame(19, 105, 143),
        new ReplayFrame(20, 108, 148),
        new ReplayFrame(21, 111, 153),
        new ReplayFrame(22, 114, 158),
        new ReplayFrame(23, 117, 163),
        new ReplayFrame(24, 120, 168),
        new ReplayFrame(25, 123, 173),
        new ReplayFrame(26, 126, 178),
        new ReplayFrame(27, 129, 183),
        new ReplayFrame(28, 132, 188),
        new ReplayFrame(29, 135, 193),
        new ReplayFrame(30, 138, 198),
        new ReplayFrame(31, 141, 203),
        new ReplayFrame(32, 144, 208),
        new ReplayFrame(33, 147, 213),
        new ReplayFrame(34, 150, 218),
        new ReplayFrame(35, 153, 223),
        new ReplayFrame(36, 156, 228),
        new ReplayFrame(37, 159, 233),
        new ReplayFrame(38, 162, 238),
        new ReplayFrame(39, 165, 243),
        new ReplayFrame(40, 168, 248),
        new ReplayFrame(41, 171, 253),
        new ReplayFrame(42, 174, 258),
        new ReplayFrame(43, 177, 263),
        new ReplayFrame(44, 180, 268),
        new ReplayFrame(45, 183, 273),
        new ReplayFrame(46, 186, 278),
        new ReplayFrame(47, 189, 283),
        new ReplayFrame(48, 192, 288),
        new ReplayFrame(49, 195, 293),
        new ReplayFrame(50, 198, 298),
        new ReplayFrame(51, 201, 303),
        new ReplayFrame(52, 204, 308),
        new ReplayFrame(53, 207, 313),
        new ReplayFrame(54, 210, 318),
        new ReplayFrame(55, 213, 323),
        new ReplayFrame(56, 216, 328),
        new ReplayFrame(57, 219, 333),
        new ReplayFrame(58, 222, 338),
        new ReplayFrame(59, 225, 343),
        new ReplayFrame(60, 228, 348),
        new ReplayFrame(61, 231, 353),
        new ReplayFrame(62, 234, 358),
        new ReplayFrame(63, 237, 363),
        new ReplayFrame(64, 240, 368),
        new ReplayFrame(65, 243, 373),
        new ReplayFrame(66, 246, 378),
        new ReplayFrame(67, 249, 383),
        new ReplayFrame(68, 252, 388),
        new ReplayFrame(69, 255, 393),
        new ReplayFrame(70, 258, 398),
        new ReplayFrame(71, 261, 403),
        new ReplayFrame(72, 264, 408),
        new ReplayFrame(73, 267, 413),
        new ReplayFrame(74, 270, 418),
        new ReplayFrame(75, 273, 423),
        new ReplayFrame(76, 276, 428),
        new ReplayFrame(77, 279, 433),
        new ReplayFrame(78, 282, 438),
        new ReplayFrame(79, 285, 443)
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
