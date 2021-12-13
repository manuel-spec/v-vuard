namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus36
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 36, 36),
        new ReplayFrame(1, 39, 41),
        new ReplayFrame(2, 42, 46),
        new ReplayFrame(3, 45, 51),
        new ReplayFrame(4, 48, 56),
        new ReplayFrame(5, 51, 61),
        new ReplayFrame(6, 54, 66),
        new ReplayFrame(7, 57, 71),
        new ReplayFrame(8, 60, 76),
        new ReplayFrame(9, 63, 81),
        new ReplayFrame(10, 66, 86),
        new ReplayFrame(11, 69, 91),
        new ReplayFrame(12, 72, 96),
        new ReplayFrame(13, 75, 101),
        new ReplayFrame(14, 78, 106),
        new ReplayFrame(15, 81, 111),
        new ReplayFrame(16, 84, 116),
        new ReplayFrame(17, 87, 121),
        new ReplayFrame(18, 90, 126),
        new ReplayFrame(19, 93, 131),
        new ReplayFrame(20, 96, 136),
        new ReplayFrame(21, 99, 141),
        new ReplayFrame(22, 102, 146),
        new ReplayFrame(23, 105, 151),
        new ReplayFrame(24, 108, 156),
        new ReplayFrame(25, 111, 161),
        new ReplayFrame(26, 114, 166),
        new ReplayFrame(27, 117, 171),
        new ReplayFrame(28, 120, 176),
        new ReplayFrame(29, 123, 181),
        new ReplayFrame(30, 126, 186),
        new ReplayFrame(31, 129, 191),
        new ReplayFrame(32, 132, 196),
        new ReplayFrame(33, 135, 201),
        new ReplayFrame(34, 138, 206),
        new ReplayFrame(35, 141, 211),
        new ReplayFrame(36, 144, 216),
        new ReplayFrame(37, 147, 221),
        new ReplayFrame(38, 150, 226),
        new ReplayFrame(39, 153, 231),
        new ReplayFrame(40, 156, 236),
        new ReplayFrame(41, 159, 241),
        new ReplayFrame(42, 162, 246),
        new ReplayFrame(43, 165, 251),
        new ReplayFrame(44, 168, 256),
        new ReplayFrame(45, 171, 261),
        new ReplayFrame(46, 174, 266),
        new ReplayFrame(47, 177, 271),
        new ReplayFrame(48, 180, 276),
        new ReplayFrame(49, 183, 281),
        new ReplayFrame(50, 186, 286),
        new ReplayFrame(51, 189, 291),
        new ReplayFrame(52, 192, 296),
        new ReplayFrame(53, 195, 301),
        new ReplayFrame(54, 198, 306),
        new ReplayFrame(55, 201, 311),
        new ReplayFrame(56, 204, 316),
        new ReplayFrame(57, 207, 321),
        new ReplayFrame(58, 210, 326),
        new ReplayFrame(59, 213, 331),
        new ReplayFrame(60, 216, 336),
        new ReplayFrame(61, 219, 341),
        new ReplayFrame(62, 222, 346),
        new ReplayFrame(63, 225, 351),
        new ReplayFrame(64, 228, 356),
        new ReplayFrame(65, 231, 361),
        new ReplayFrame(66, 234, 366),
        new ReplayFrame(67, 237, 371),
        new ReplayFrame(68, 240, 376),
        new ReplayFrame(69, 243, 381),
        new ReplayFrame(70, 246, 386),
        new ReplayFrame(71, 249, 391),
        new ReplayFrame(72, 252, 396),
        new ReplayFrame(73, 255, 401),
        new ReplayFrame(74, 258, 406),
        new ReplayFrame(75, 261, 411),
        new ReplayFrame(76, 264, 416),
        new ReplayFrame(77, 267, 421),
        new ReplayFrame(78, 270, 426),
        new ReplayFrame(79, 273, 431)
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
