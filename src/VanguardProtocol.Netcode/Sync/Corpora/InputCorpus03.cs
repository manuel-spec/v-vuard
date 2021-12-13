namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus03
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 3, 3),
        new ReplayFrame(1, 6, 8),
        new ReplayFrame(2, 9, 13),
        new ReplayFrame(3, 12, 18),
        new ReplayFrame(4, 15, 23),
        new ReplayFrame(5, 18, 28),
        new ReplayFrame(6, 21, 33),
        new ReplayFrame(7, 24, 38),
        new ReplayFrame(8, 27, 43),
        new ReplayFrame(9, 30, 48),
        new ReplayFrame(10, 33, 53),
        new ReplayFrame(11, 36, 58),
        new ReplayFrame(12, 39, 63),
        new ReplayFrame(13, 42, 68),
        new ReplayFrame(14, 45, 73),
        new ReplayFrame(15, 48, 78),
        new ReplayFrame(16, 51, 83),
        new ReplayFrame(17, 54, 88),
        new ReplayFrame(18, 57, 93),
        new ReplayFrame(19, 60, 98),
        new ReplayFrame(20, 63, 103),
        new ReplayFrame(21, 66, 108),
        new ReplayFrame(22, 69, 113),
        new ReplayFrame(23, 72, 118),
        new ReplayFrame(24, 75, 123),
        new ReplayFrame(25, 78, 128),
        new ReplayFrame(26, 81, 133),
        new ReplayFrame(27, 84, 138),
        new ReplayFrame(28, 87, 143),
        new ReplayFrame(29, 90, 148),
        new ReplayFrame(30, 93, 153),
        new ReplayFrame(31, 96, 158),
        new ReplayFrame(32, 99, 163),
        new ReplayFrame(33, 102, 168),
        new ReplayFrame(34, 105, 173),
        new ReplayFrame(35, 108, 178),
        new ReplayFrame(36, 111, 183),
        new ReplayFrame(37, 114, 188),
        new ReplayFrame(38, 117, 193),
        new ReplayFrame(39, 120, 198),
        new ReplayFrame(40, 123, 203),
        new ReplayFrame(41, 126, 208),
        new ReplayFrame(42, 129, 213),
        new ReplayFrame(43, 132, 218),
        new ReplayFrame(44, 135, 223),
        new ReplayFrame(45, 138, 228),
        new ReplayFrame(46, 141, 233),
        new ReplayFrame(47, 144, 238),
        new ReplayFrame(48, 147, 243),
        new ReplayFrame(49, 150, 248),
        new ReplayFrame(50, 153, 253),
        new ReplayFrame(51, 156, 258),
        new ReplayFrame(52, 159, 263),
        new ReplayFrame(53, 162, 268),
        new ReplayFrame(54, 165, 273),
        new ReplayFrame(55, 168, 278),
        new ReplayFrame(56, 171, 283),
        new ReplayFrame(57, 174, 288),
        new ReplayFrame(58, 177, 293),
        new ReplayFrame(59, 180, 298),
        new ReplayFrame(60, 183, 303),
        new ReplayFrame(61, 186, 308),
        new ReplayFrame(62, 189, 313),
        new ReplayFrame(63, 192, 318),
        new ReplayFrame(64, 195, 323),
        new ReplayFrame(65, 198, 328),
        new ReplayFrame(66, 201, 333),
        new ReplayFrame(67, 204, 338),
        new ReplayFrame(68, 207, 343),
        new ReplayFrame(69, 210, 348),
        new ReplayFrame(70, 213, 353),
        new ReplayFrame(71, 216, 358),
        new ReplayFrame(72, 219, 363),
        new ReplayFrame(73, 222, 368),
        new ReplayFrame(74, 225, 373),
        new ReplayFrame(75, 228, 378),
        new ReplayFrame(76, 231, 383),
        new ReplayFrame(77, 234, 388),
        new ReplayFrame(78, 237, 393),
        new ReplayFrame(79, 240, 398)
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
