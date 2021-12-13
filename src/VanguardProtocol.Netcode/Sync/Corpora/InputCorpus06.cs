namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus06
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 6, 6),
        new ReplayFrame(1, 9, 11),
        new ReplayFrame(2, 12, 16),
        new ReplayFrame(3, 15, 21),
        new ReplayFrame(4, 18, 26),
        new ReplayFrame(5, 21, 31),
        new ReplayFrame(6, 24, 36),
        new ReplayFrame(7, 27, 41),
        new ReplayFrame(8, 30, 46),
        new ReplayFrame(9, 33, 51),
        new ReplayFrame(10, 36, 56),
        new ReplayFrame(11, 39, 61),
        new ReplayFrame(12, 42, 66),
        new ReplayFrame(13, 45, 71),
        new ReplayFrame(14, 48, 76),
        new ReplayFrame(15, 51, 81),
        new ReplayFrame(16, 54, 86),
        new ReplayFrame(17, 57, 91),
        new ReplayFrame(18, 60, 96),
        new ReplayFrame(19, 63, 101),
        new ReplayFrame(20, 66, 106),
        new ReplayFrame(21, 69, 111),
        new ReplayFrame(22, 72, 116),
        new ReplayFrame(23, 75, 121),
        new ReplayFrame(24, 78, 126),
        new ReplayFrame(25, 81, 131),
        new ReplayFrame(26, 84, 136),
        new ReplayFrame(27, 87, 141),
        new ReplayFrame(28, 90, 146),
        new ReplayFrame(29, 93, 151),
        new ReplayFrame(30, 96, 156),
        new ReplayFrame(31, 99, 161),
        new ReplayFrame(32, 102, 166),
        new ReplayFrame(33, 105, 171),
        new ReplayFrame(34, 108, 176),
        new ReplayFrame(35, 111, 181),
        new ReplayFrame(36, 114, 186),
        new ReplayFrame(37, 117, 191),
        new ReplayFrame(38, 120, 196),
        new ReplayFrame(39, 123, 201),
        new ReplayFrame(40, 126, 206),
        new ReplayFrame(41, 129, 211),
        new ReplayFrame(42, 132, 216),
        new ReplayFrame(43, 135, 221),
        new ReplayFrame(44, 138, 226),
        new ReplayFrame(45, 141, 231),
        new ReplayFrame(46, 144, 236),
        new ReplayFrame(47, 147, 241),
        new ReplayFrame(48, 150, 246),
        new ReplayFrame(49, 153, 251),
        new ReplayFrame(50, 156, 256),
        new ReplayFrame(51, 159, 261),
        new ReplayFrame(52, 162, 266),
        new ReplayFrame(53, 165, 271),
        new ReplayFrame(54, 168, 276),
        new ReplayFrame(55, 171, 281),
        new ReplayFrame(56, 174, 286),
        new ReplayFrame(57, 177, 291),
        new ReplayFrame(58, 180, 296),
        new ReplayFrame(59, 183, 301),
        new ReplayFrame(60, 186, 306),
        new ReplayFrame(61, 189, 311),
        new ReplayFrame(62, 192, 316),
        new ReplayFrame(63, 195, 321),
        new ReplayFrame(64, 198, 326),
        new ReplayFrame(65, 201, 331),
        new ReplayFrame(66, 204, 336),
        new ReplayFrame(67, 207, 341),
        new ReplayFrame(68, 210, 346),
        new ReplayFrame(69, 213, 351),
        new ReplayFrame(70, 216, 356),
        new ReplayFrame(71, 219, 361),
        new ReplayFrame(72, 222, 366),
        new ReplayFrame(73, 225, 371),
        new ReplayFrame(74, 228, 376),
        new ReplayFrame(75, 231, 381),
        new ReplayFrame(76, 234, 386),
        new ReplayFrame(77, 237, 391),
        new ReplayFrame(78, 240, 396),
        new ReplayFrame(79, 243, 401)
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
