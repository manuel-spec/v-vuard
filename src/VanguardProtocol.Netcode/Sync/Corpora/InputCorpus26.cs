namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus26
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 26, 26),
        new ReplayFrame(1, 29, 31),
        new ReplayFrame(2, 32, 36),
        new ReplayFrame(3, 35, 41),
        new ReplayFrame(4, 38, 46),
        new ReplayFrame(5, 41, 51),
        new ReplayFrame(6, 44, 56),
        new ReplayFrame(7, 47, 61),
        new ReplayFrame(8, 50, 66),
        new ReplayFrame(9, 53, 71),
        new ReplayFrame(10, 56, 76),
        new ReplayFrame(11, 59, 81),
        new ReplayFrame(12, 62, 86),
        new ReplayFrame(13, 65, 91),
        new ReplayFrame(14, 68, 96),
        new ReplayFrame(15, 71, 101),
        new ReplayFrame(16, 74, 106),
        new ReplayFrame(17, 77, 111),
        new ReplayFrame(18, 80, 116),
        new ReplayFrame(19, 83, 121),
        new ReplayFrame(20, 86, 126),
        new ReplayFrame(21, 89, 131),
        new ReplayFrame(22, 92, 136),
        new ReplayFrame(23, 95, 141),
        new ReplayFrame(24, 98, 146),
        new ReplayFrame(25, 101, 151),
        new ReplayFrame(26, 104, 156),
        new ReplayFrame(27, 107, 161),
        new ReplayFrame(28, 110, 166),
        new ReplayFrame(29, 113, 171),
        new ReplayFrame(30, 116, 176),
        new ReplayFrame(31, 119, 181),
        new ReplayFrame(32, 122, 186),
        new ReplayFrame(33, 125, 191),
        new ReplayFrame(34, 128, 196),
        new ReplayFrame(35, 131, 201),
        new ReplayFrame(36, 134, 206),
        new ReplayFrame(37, 137, 211),
        new ReplayFrame(38, 140, 216),
        new ReplayFrame(39, 143, 221),
        new ReplayFrame(40, 146, 226),
        new ReplayFrame(41, 149, 231),
        new ReplayFrame(42, 152, 236),
        new ReplayFrame(43, 155, 241),
        new ReplayFrame(44, 158, 246),
        new ReplayFrame(45, 161, 251),
        new ReplayFrame(46, 164, 256),
        new ReplayFrame(47, 167, 261),
        new ReplayFrame(48, 170, 266),
        new ReplayFrame(49, 173, 271),
        new ReplayFrame(50, 176, 276),
        new ReplayFrame(51, 179, 281),
        new ReplayFrame(52, 182, 286),
        new ReplayFrame(53, 185, 291),
        new ReplayFrame(54, 188, 296),
        new ReplayFrame(55, 191, 301),
        new ReplayFrame(56, 194, 306),
        new ReplayFrame(57, 197, 311),
        new ReplayFrame(58, 200, 316),
        new ReplayFrame(59, 203, 321),
        new ReplayFrame(60, 206, 326),
        new ReplayFrame(61, 209, 331),
        new ReplayFrame(62, 212, 336),
        new ReplayFrame(63, 215, 341),
        new ReplayFrame(64, 218, 346),
        new ReplayFrame(65, 221, 351),
        new ReplayFrame(66, 224, 356),
        new ReplayFrame(67, 227, 361),
        new ReplayFrame(68, 230, 366),
        new ReplayFrame(69, 233, 371),
        new ReplayFrame(70, 236, 376),
        new ReplayFrame(71, 239, 381),
        new ReplayFrame(72, 242, 386),
        new ReplayFrame(73, 245, 391),
        new ReplayFrame(74, 248, 396),
        new ReplayFrame(75, 251, 401),
        new ReplayFrame(76, 254, 406),
        new ReplayFrame(77, 257, 411),
        new ReplayFrame(78, 260, 416),
        new ReplayFrame(79, 263, 421)
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
