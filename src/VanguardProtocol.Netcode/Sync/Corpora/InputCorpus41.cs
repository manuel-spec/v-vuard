namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus41
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 41, 41),
        new ReplayFrame(1, 44, 46),
        new ReplayFrame(2, 47, 51),
        new ReplayFrame(3, 50, 56),
        new ReplayFrame(4, 53, 61),
        new ReplayFrame(5, 56, 66),
        new ReplayFrame(6, 59, 71),
        new ReplayFrame(7, 62, 76),
        new ReplayFrame(8, 65, 81),
        new ReplayFrame(9, 68, 86),
        new ReplayFrame(10, 71, 91),
        new ReplayFrame(11, 74, 96),
        new ReplayFrame(12, 77, 101),
        new ReplayFrame(13, 80, 106),
        new ReplayFrame(14, 83, 111),
        new ReplayFrame(15, 86, 116),
        new ReplayFrame(16, 89, 121),
        new ReplayFrame(17, 92, 126),
        new ReplayFrame(18, 95, 131),
        new ReplayFrame(19, 98, 136),
        new ReplayFrame(20, 101, 141),
        new ReplayFrame(21, 104, 146),
        new ReplayFrame(22, 107, 151),
        new ReplayFrame(23, 110, 156),
        new ReplayFrame(24, 113, 161),
        new ReplayFrame(25, 116, 166),
        new ReplayFrame(26, 119, 171),
        new ReplayFrame(27, 122, 176),
        new ReplayFrame(28, 125, 181),
        new ReplayFrame(29, 128, 186),
        new ReplayFrame(30, 131, 191),
        new ReplayFrame(31, 134, 196),
        new ReplayFrame(32, 137, 201),
        new ReplayFrame(33, 140, 206),
        new ReplayFrame(34, 143, 211),
        new ReplayFrame(35, 146, 216),
        new ReplayFrame(36, 149, 221),
        new ReplayFrame(37, 152, 226),
        new ReplayFrame(38, 155, 231),
        new ReplayFrame(39, 158, 236),
        new ReplayFrame(40, 161, 241),
        new ReplayFrame(41, 164, 246),
        new ReplayFrame(42, 167, 251),
        new ReplayFrame(43, 170, 256),
        new ReplayFrame(44, 173, 261),
        new ReplayFrame(45, 176, 266),
        new ReplayFrame(46, 179, 271),
        new ReplayFrame(47, 182, 276),
        new ReplayFrame(48, 185, 281),
        new ReplayFrame(49, 188, 286),
        new ReplayFrame(50, 191, 291),
        new ReplayFrame(51, 194, 296),
        new ReplayFrame(52, 197, 301),
        new ReplayFrame(53, 200, 306),
        new ReplayFrame(54, 203, 311),
        new ReplayFrame(55, 206, 316),
        new ReplayFrame(56, 209, 321),
        new ReplayFrame(57, 212, 326),
        new ReplayFrame(58, 215, 331),
        new ReplayFrame(59, 218, 336),
        new ReplayFrame(60, 221, 341),
        new ReplayFrame(61, 224, 346),
        new ReplayFrame(62, 227, 351),
        new ReplayFrame(63, 230, 356),
        new ReplayFrame(64, 233, 361),
        new ReplayFrame(65, 236, 366),
        new ReplayFrame(66, 239, 371),
        new ReplayFrame(67, 242, 376),
        new ReplayFrame(68, 245, 381),
        new ReplayFrame(69, 248, 386),
        new ReplayFrame(70, 251, 391),
        new ReplayFrame(71, 254, 396),
        new ReplayFrame(72, 257, 401),
        new ReplayFrame(73, 260, 406),
        new ReplayFrame(74, 263, 411),
        new ReplayFrame(75, 266, 416),
        new ReplayFrame(76, 269, 421),
        new ReplayFrame(77, 272, 426),
        new ReplayFrame(78, 275, 431),
        new ReplayFrame(79, 278, 436)
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
