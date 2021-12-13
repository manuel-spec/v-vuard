namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus33
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 33, 33),
        new ReplayFrame(1, 36, 38),
        new ReplayFrame(2, 39, 43),
        new ReplayFrame(3, 42, 48),
        new ReplayFrame(4, 45, 53),
        new ReplayFrame(5, 48, 58),
        new ReplayFrame(6, 51, 63),
        new ReplayFrame(7, 54, 68),
        new ReplayFrame(8, 57, 73),
        new ReplayFrame(9, 60, 78),
        new ReplayFrame(10, 63, 83),
        new ReplayFrame(11, 66, 88),
        new ReplayFrame(12, 69, 93),
        new ReplayFrame(13, 72, 98),
        new ReplayFrame(14, 75, 103),
        new ReplayFrame(15, 78, 108),
        new ReplayFrame(16, 81, 113),
        new ReplayFrame(17, 84, 118),
        new ReplayFrame(18, 87, 123),
        new ReplayFrame(19, 90, 128),
        new ReplayFrame(20, 93, 133),
        new ReplayFrame(21, 96, 138),
        new ReplayFrame(22, 99, 143),
        new ReplayFrame(23, 102, 148),
        new ReplayFrame(24, 105, 153),
        new ReplayFrame(25, 108, 158),
        new ReplayFrame(26, 111, 163),
        new ReplayFrame(27, 114, 168),
        new ReplayFrame(28, 117, 173),
        new ReplayFrame(29, 120, 178),
        new ReplayFrame(30, 123, 183),
        new ReplayFrame(31, 126, 188),
        new ReplayFrame(32, 129, 193),
        new ReplayFrame(33, 132, 198),
        new ReplayFrame(34, 135, 203),
        new ReplayFrame(35, 138, 208),
        new ReplayFrame(36, 141, 213),
        new ReplayFrame(37, 144, 218),
        new ReplayFrame(38, 147, 223),
        new ReplayFrame(39, 150, 228),
        new ReplayFrame(40, 153, 233),
        new ReplayFrame(41, 156, 238),
        new ReplayFrame(42, 159, 243),
        new ReplayFrame(43, 162, 248),
        new ReplayFrame(44, 165, 253),
        new ReplayFrame(45, 168, 258),
        new ReplayFrame(46, 171, 263),
        new ReplayFrame(47, 174, 268),
        new ReplayFrame(48, 177, 273),
        new ReplayFrame(49, 180, 278),
        new ReplayFrame(50, 183, 283),
        new ReplayFrame(51, 186, 288),
        new ReplayFrame(52, 189, 293),
        new ReplayFrame(53, 192, 298),
        new ReplayFrame(54, 195, 303),
        new ReplayFrame(55, 198, 308),
        new ReplayFrame(56, 201, 313),
        new ReplayFrame(57, 204, 318),
        new ReplayFrame(58, 207, 323),
        new ReplayFrame(59, 210, 328),
        new ReplayFrame(60, 213, 333),
        new ReplayFrame(61, 216, 338),
        new ReplayFrame(62, 219, 343),
        new ReplayFrame(63, 222, 348),
        new ReplayFrame(64, 225, 353),
        new ReplayFrame(65, 228, 358),
        new ReplayFrame(66, 231, 363),
        new ReplayFrame(67, 234, 368),
        new ReplayFrame(68, 237, 373),
        new ReplayFrame(69, 240, 378),
        new ReplayFrame(70, 243, 383),
        new ReplayFrame(71, 246, 388),
        new ReplayFrame(72, 249, 393),
        new ReplayFrame(73, 252, 398),
        new ReplayFrame(74, 255, 403),
        new ReplayFrame(75, 258, 408),
        new ReplayFrame(76, 261, 413),
        new ReplayFrame(77, 264, 418),
        new ReplayFrame(78, 267, 423),
        new ReplayFrame(79, 270, 428)
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
