namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus18
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 18, 18),
        new ReplayFrame(1, 21, 23),
        new ReplayFrame(2, 24, 28),
        new ReplayFrame(3, 27, 33),
        new ReplayFrame(4, 30, 38),
        new ReplayFrame(5, 33, 43),
        new ReplayFrame(6, 36, 48),
        new ReplayFrame(7, 39, 53),
        new ReplayFrame(8, 42, 58),
        new ReplayFrame(9, 45, 63),
        new ReplayFrame(10, 48, 68),
        new ReplayFrame(11, 51, 73),
        new ReplayFrame(12, 54, 78),
        new ReplayFrame(13, 57, 83),
        new ReplayFrame(14, 60, 88),
        new ReplayFrame(15, 63, 93),
        new ReplayFrame(16, 66, 98),
        new ReplayFrame(17, 69, 103),
        new ReplayFrame(18, 72, 108),
        new ReplayFrame(19, 75, 113),
        new ReplayFrame(20, 78, 118),
        new ReplayFrame(21, 81, 123),
        new ReplayFrame(22, 84, 128),
        new ReplayFrame(23, 87, 133),
        new ReplayFrame(24, 90, 138),
        new ReplayFrame(25, 93, 143),
        new ReplayFrame(26, 96, 148),
        new ReplayFrame(27, 99, 153),
        new ReplayFrame(28, 102, 158),
        new ReplayFrame(29, 105, 163),
        new ReplayFrame(30, 108, 168),
        new ReplayFrame(31, 111, 173),
        new ReplayFrame(32, 114, 178),
        new ReplayFrame(33, 117, 183),
        new ReplayFrame(34, 120, 188),
        new ReplayFrame(35, 123, 193),
        new ReplayFrame(36, 126, 198),
        new ReplayFrame(37, 129, 203),
        new ReplayFrame(38, 132, 208),
        new ReplayFrame(39, 135, 213),
        new ReplayFrame(40, 138, 218),
        new ReplayFrame(41, 141, 223),
        new ReplayFrame(42, 144, 228),
        new ReplayFrame(43, 147, 233),
        new ReplayFrame(44, 150, 238),
        new ReplayFrame(45, 153, 243),
        new ReplayFrame(46, 156, 248),
        new ReplayFrame(47, 159, 253),
        new ReplayFrame(48, 162, 258),
        new ReplayFrame(49, 165, 263),
        new ReplayFrame(50, 168, 268),
        new ReplayFrame(51, 171, 273),
        new ReplayFrame(52, 174, 278),
        new ReplayFrame(53, 177, 283),
        new ReplayFrame(54, 180, 288),
        new ReplayFrame(55, 183, 293),
        new ReplayFrame(56, 186, 298),
        new ReplayFrame(57, 189, 303),
        new ReplayFrame(58, 192, 308),
        new ReplayFrame(59, 195, 313),
        new ReplayFrame(60, 198, 318),
        new ReplayFrame(61, 201, 323),
        new ReplayFrame(62, 204, 328),
        new ReplayFrame(63, 207, 333),
        new ReplayFrame(64, 210, 338),
        new ReplayFrame(65, 213, 343),
        new ReplayFrame(66, 216, 348),
        new ReplayFrame(67, 219, 353),
        new ReplayFrame(68, 222, 358),
        new ReplayFrame(69, 225, 363),
        new ReplayFrame(70, 228, 368),
        new ReplayFrame(71, 231, 373),
        new ReplayFrame(72, 234, 378),
        new ReplayFrame(73, 237, 383),
        new ReplayFrame(74, 240, 388),
        new ReplayFrame(75, 243, 393),
        new ReplayFrame(76, 246, 398),
        new ReplayFrame(77, 249, 403),
        new ReplayFrame(78, 252, 408),
        new ReplayFrame(79, 255, 413)
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
