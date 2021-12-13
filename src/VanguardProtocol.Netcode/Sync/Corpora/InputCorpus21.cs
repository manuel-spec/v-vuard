namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus21
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 21, 21),
        new ReplayFrame(1, 24, 26),
        new ReplayFrame(2, 27, 31),
        new ReplayFrame(3, 30, 36),
        new ReplayFrame(4, 33, 41),
        new ReplayFrame(5, 36, 46),
        new ReplayFrame(6, 39, 51),
        new ReplayFrame(7, 42, 56),
        new ReplayFrame(8, 45, 61),
        new ReplayFrame(9, 48, 66),
        new ReplayFrame(10, 51, 71),
        new ReplayFrame(11, 54, 76),
        new ReplayFrame(12, 57, 81),
        new ReplayFrame(13, 60, 86),
        new ReplayFrame(14, 63, 91),
        new ReplayFrame(15, 66, 96),
        new ReplayFrame(16, 69, 101),
        new ReplayFrame(17, 72, 106),
        new ReplayFrame(18, 75, 111),
        new ReplayFrame(19, 78, 116),
        new ReplayFrame(20, 81, 121),
        new ReplayFrame(21, 84, 126),
        new ReplayFrame(22, 87, 131),
        new ReplayFrame(23, 90, 136),
        new ReplayFrame(24, 93, 141),
        new ReplayFrame(25, 96, 146),
        new ReplayFrame(26, 99, 151),
        new ReplayFrame(27, 102, 156),
        new ReplayFrame(28, 105, 161),
        new ReplayFrame(29, 108, 166),
        new ReplayFrame(30, 111, 171),
        new ReplayFrame(31, 114, 176),
        new ReplayFrame(32, 117, 181),
        new ReplayFrame(33, 120, 186),
        new ReplayFrame(34, 123, 191),
        new ReplayFrame(35, 126, 196),
        new ReplayFrame(36, 129, 201),
        new ReplayFrame(37, 132, 206),
        new ReplayFrame(38, 135, 211),
        new ReplayFrame(39, 138, 216),
        new ReplayFrame(40, 141, 221),
        new ReplayFrame(41, 144, 226),
        new ReplayFrame(42, 147, 231),
        new ReplayFrame(43, 150, 236),
        new ReplayFrame(44, 153, 241),
        new ReplayFrame(45, 156, 246),
        new ReplayFrame(46, 159, 251),
        new ReplayFrame(47, 162, 256),
        new ReplayFrame(48, 165, 261),
        new ReplayFrame(49, 168, 266),
        new ReplayFrame(50, 171, 271),
        new ReplayFrame(51, 174, 276),
        new ReplayFrame(52, 177, 281),
        new ReplayFrame(53, 180, 286),
        new ReplayFrame(54, 183, 291),
        new ReplayFrame(55, 186, 296),
        new ReplayFrame(56, 189, 301),
        new ReplayFrame(57, 192, 306),
        new ReplayFrame(58, 195, 311),
        new ReplayFrame(59, 198, 316),
        new ReplayFrame(60, 201, 321),
        new ReplayFrame(61, 204, 326),
        new ReplayFrame(62, 207, 331),
        new ReplayFrame(63, 210, 336),
        new ReplayFrame(64, 213, 341),
        new ReplayFrame(65, 216, 346),
        new ReplayFrame(66, 219, 351),
        new ReplayFrame(67, 222, 356),
        new ReplayFrame(68, 225, 361),
        new ReplayFrame(69, 228, 366),
        new ReplayFrame(70, 231, 371),
        new ReplayFrame(71, 234, 376),
        new ReplayFrame(72, 237, 381),
        new ReplayFrame(73, 240, 386),
        new ReplayFrame(74, 243, 391),
        new ReplayFrame(75, 246, 396),
        new ReplayFrame(76, 249, 401),
        new ReplayFrame(77, 252, 406),
        new ReplayFrame(78, 255, 411),
        new ReplayFrame(79, 258, 416)
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
