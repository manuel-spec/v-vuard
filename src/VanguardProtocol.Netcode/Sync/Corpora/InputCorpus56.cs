namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus56
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 56, 56),
        new ReplayFrame(1, 59, 61),
        new ReplayFrame(2, 62, 66),
        new ReplayFrame(3, 65, 71),
        new ReplayFrame(4, 68, 76),
        new ReplayFrame(5, 71, 81),
        new ReplayFrame(6, 74, 86),
        new ReplayFrame(7, 77, 91),
        new ReplayFrame(8, 80, 96),
        new ReplayFrame(9, 83, 101),
        new ReplayFrame(10, 86, 106),
        new ReplayFrame(11, 89, 111),
        new ReplayFrame(12, 92, 116),
        new ReplayFrame(13, 95, 121),
        new ReplayFrame(14, 98, 126),
        new ReplayFrame(15, 101, 131),
        new ReplayFrame(16, 104, 136),
        new ReplayFrame(17, 107, 141),
        new ReplayFrame(18, 110, 146),
        new ReplayFrame(19, 113, 151),
        new ReplayFrame(20, 116, 156),
        new ReplayFrame(21, 119, 161),
        new ReplayFrame(22, 122, 166),
        new ReplayFrame(23, 125, 171),
        new ReplayFrame(24, 128, 176),
        new ReplayFrame(25, 131, 181),
        new ReplayFrame(26, 134, 186),
        new ReplayFrame(27, 137, 191),
        new ReplayFrame(28, 140, 196),
        new ReplayFrame(29, 143, 201),
        new ReplayFrame(30, 146, 206),
        new ReplayFrame(31, 149, 211),
        new ReplayFrame(32, 152, 216),
        new ReplayFrame(33, 155, 221),
        new ReplayFrame(34, 158, 226),
        new ReplayFrame(35, 161, 231),
        new ReplayFrame(36, 164, 236),
        new ReplayFrame(37, 167, 241),
        new ReplayFrame(38, 170, 246),
        new ReplayFrame(39, 173, 251),
        new ReplayFrame(40, 176, 256),
        new ReplayFrame(41, 179, 261),
        new ReplayFrame(42, 182, 266),
        new ReplayFrame(43, 185, 271),
        new ReplayFrame(44, 188, 276),
        new ReplayFrame(45, 191, 281),
        new ReplayFrame(46, 194, 286),
        new ReplayFrame(47, 197, 291),
        new ReplayFrame(48, 200, 296),
        new ReplayFrame(49, 203, 301),
        new ReplayFrame(50, 206, 306),
        new ReplayFrame(51, 209, 311),
        new ReplayFrame(52, 212, 316),
        new ReplayFrame(53, 215, 321),
        new ReplayFrame(54, 218, 326),
        new ReplayFrame(55, 221, 331),
        new ReplayFrame(56, 224, 336),
        new ReplayFrame(57, 227, 341),
        new ReplayFrame(58, 230, 346),
        new ReplayFrame(59, 233, 351),
        new ReplayFrame(60, 236, 356),
        new ReplayFrame(61, 239, 361),
        new ReplayFrame(62, 242, 366),
        new ReplayFrame(63, 245, 371),
        new ReplayFrame(64, 248, 376),
        new ReplayFrame(65, 251, 381),
        new ReplayFrame(66, 254, 386),
        new ReplayFrame(67, 257, 391),
        new ReplayFrame(68, 260, 396),
        new ReplayFrame(69, 263, 401),
        new ReplayFrame(70, 266, 406),
        new ReplayFrame(71, 269, 411),
        new ReplayFrame(72, 272, 416),
        new ReplayFrame(73, 275, 421),
        new ReplayFrame(74, 278, 426),
        new ReplayFrame(75, 281, 431),
        new ReplayFrame(76, 284, 436),
        new ReplayFrame(77, 287, 441),
        new ReplayFrame(78, 290, 446),
        new ReplayFrame(79, 293, 451)
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
