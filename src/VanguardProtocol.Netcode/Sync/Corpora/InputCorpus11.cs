namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus11
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 11, 11),
        new ReplayFrame(1, 14, 16),
        new ReplayFrame(2, 17, 21),
        new ReplayFrame(3, 20, 26),
        new ReplayFrame(4, 23, 31),
        new ReplayFrame(5, 26, 36),
        new ReplayFrame(6, 29, 41),
        new ReplayFrame(7, 32, 46),
        new ReplayFrame(8, 35, 51),
        new ReplayFrame(9, 38, 56),
        new ReplayFrame(10, 41, 61),
        new ReplayFrame(11, 44, 66),
        new ReplayFrame(12, 47, 71),
        new ReplayFrame(13, 50, 76),
        new ReplayFrame(14, 53, 81),
        new ReplayFrame(15, 56, 86),
        new ReplayFrame(16, 59, 91),
        new ReplayFrame(17, 62, 96),
        new ReplayFrame(18, 65, 101),
        new ReplayFrame(19, 68, 106),
        new ReplayFrame(20, 71, 111),
        new ReplayFrame(21, 74, 116),
        new ReplayFrame(22, 77, 121),
        new ReplayFrame(23, 80, 126),
        new ReplayFrame(24, 83, 131),
        new ReplayFrame(25, 86, 136),
        new ReplayFrame(26, 89, 141),
        new ReplayFrame(27, 92, 146),
        new ReplayFrame(28, 95, 151),
        new ReplayFrame(29, 98, 156),
        new ReplayFrame(30, 101, 161),
        new ReplayFrame(31, 104, 166),
        new ReplayFrame(32, 107, 171),
        new ReplayFrame(33, 110, 176),
        new ReplayFrame(34, 113, 181),
        new ReplayFrame(35, 116, 186),
        new ReplayFrame(36, 119, 191),
        new ReplayFrame(37, 122, 196),
        new ReplayFrame(38, 125, 201),
        new ReplayFrame(39, 128, 206),
        new ReplayFrame(40, 131, 211),
        new ReplayFrame(41, 134, 216),
        new ReplayFrame(42, 137, 221),
        new ReplayFrame(43, 140, 226),
        new ReplayFrame(44, 143, 231),
        new ReplayFrame(45, 146, 236),
        new ReplayFrame(46, 149, 241),
        new ReplayFrame(47, 152, 246),
        new ReplayFrame(48, 155, 251),
        new ReplayFrame(49, 158, 256),
        new ReplayFrame(50, 161, 261),
        new ReplayFrame(51, 164, 266),
        new ReplayFrame(52, 167, 271),
        new ReplayFrame(53, 170, 276),
        new ReplayFrame(54, 173, 281),
        new ReplayFrame(55, 176, 286),
        new ReplayFrame(56, 179, 291),
        new ReplayFrame(57, 182, 296),
        new ReplayFrame(58, 185, 301),
        new ReplayFrame(59, 188, 306),
        new ReplayFrame(60, 191, 311),
        new ReplayFrame(61, 194, 316),
        new ReplayFrame(62, 197, 321),
        new ReplayFrame(63, 200, 326),
        new ReplayFrame(64, 203, 331),
        new ReplayFrame(65, 206, 336),
        new ReplayFrame(66, 209, 341),
        new ReplayFrame(67, 212, 346),
        new ReplayFrame(68, 215, 351),
        new ReplayFrame(69, 218, 356),
        new ReplayFrame(70, 221, 361),
        new ReplayFrame(71, 224, 366),
        new ReplayFrame(72, 227, 371),
        new ReplayFrame(73, 230, 376),
        new ReplayFrame(74, 233, 381),
        new ReplayFrame(75, 236, 386),
        new ReplayFrame(76, 239, 391),
        new ReplayFrame(77, 242, 396),
        new ReplayFrame(78, 245, 401),
        new ReplayFrame(79, 248, 406)
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
