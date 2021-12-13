namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus51
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 51, 51),
        new ReplayFrame(1, 54, 56),
        new ReplayFrame(2, 57, 61),
        new ReplayFrame(3, 60, 66),
        new ReplayFrame(4, 63, 71),
        new ReplayFrame(5, 66, 76),
        new ReplayFrame(6, 69, 81),
        new ReplayFrame(7, 72, 86),
        new ReplayFrame(8, 75, 91),
        new ReplayFrame(9, 78, 96),
        new ReplayFrame(10, 81, 101),
        new ReplayFrame(11, 84, 106),
        new ReplayFrame(12, 87, 111),
        new ReplayFrame(13, 90, 116),
        new ReplayFrame(14, 93, 121),
        new ReplayFrame(15, 96, 126),
        new ReplayFrame(16, 99, 131),
        new ReplayFrame(17, 102, 136),
        new ReplayFrame(18, 105, 141),
        new ReplayFrame(19, 108, 146),
        new ReplayFrame(20, 111, 151),
        new ReplayFrame(21, 114, 156),
        new ReplayFrame(22, 117, 161),
        new ReplayFrame(23, 120, 166),
        new ReplayFrame(24, 123, 171),
        new ReplayFrame(25, 126, 176),
        new ReplayFrame(26, 129, 181),
        new ReplayFrame(27, 132, 186),
        new ReplayFrame(28, 135, 191),
        new ReplayFrame(29, 138, 196),
        new ReplayFrame(30, 141, 201),
        new ReplayFrame(31, 144, 206),
        new ReplayFrame(32, 147, 211),
        new ReplayFrame(33, 150, 216),
        new ReplayFrame(34, 153, 221),
        new ReplayFrame(35, 156, 226),
        new ReplayFrame(36, 159, 231),
        new ReplayFrame(37, 162, 236),
        new ReplayFrame(38, 165, 241),
        new ReplayFrame(39, 168, 246),
        new ReplayFrame(40, 171, 251),
        new ReplayFrame(41, 174, 256),
        new ReplayFrame(42, 177, 261),
        new ReplayFrame(43, 180, 266),
        new ReplayFrame(44, 183, 271),
        new ReplayFrame(45, 186, 276),
        new ReplayFrame(46, 189, 281),
        new ReplayFrame(47, 192, 286),
        new ReplayFrame(48, 195, 291),
        new ReplayFrame(49, 198, 296),
        new ReplayFrame(50, 201, 301),
        new ReplayFrame(51, 204, 306),
        new ReplayFrame(52, 207, 311),
        new ReplayFrame(53, 210, 316),
        new ReplayFrame(54, 213, 321),
        new ReplayFrame(55, 216, 326),
        new ReplayFrame(56, 219, 331),
        new ReplayFrame(57, 222, 336),
        new ReplayFrame(58, 225, 341),
        new ReplayFrame(59, 228, 346),
        new ReplayFrame(60, 231, 351),
        new ReplayFrame(61, 234, 356),
        new ReplayFrame(62, 237, 361),
        new ReplayFrame(63, 240, 366),
        new ReplayFrame(64, 243, 371),
        new ReplayFrame(65, 246, 376),
        new ReplayFrame(66, 249, 381),
        new ReplayFrame(67, 252, 386),
        new ReplayFrame(68, 255, 391),
        new ReplayFrame(69, 258, 396),
        new ReplayFrame(70, 261, 401),
        new ReplayFrame(71, 264, 406),
        new ReplayFrame(72, 267, 411),
        new ReplayFrame(73, 270, 416),
        new ReplayFrame(74, 273, 421),
        new ReplayFrame(75, 276, 426),
        new ReplayFrame(76, 279, 431),
        new ReplayFrame(77, 282, 436),
        new ReplayFrame(78, 285, 441),
        new ReplayFrame(79, 288, 446)
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
