namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus31
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 31, 31),
        new ReplayFrame(1, 34, 36),
        new ReplayFrame(2, 37, 41),
        new ReplayFrame(3, 40, 46),
        new ReplayFrame(4, 43, 51),
        new ReplayFrame(5, 46, 56),
        new ReplayFrame(6, 49, 61),
        new ReplayFrame(7, 52, 66),
        new ReplayFrame(8, 55, 71),
        new ReplayFrame(9, 58, 76),
        new ReplayFrame(10, 61, 81),
        new ReplayFrame(11, 64, 86),
        new ReplayFrame(12, 67, 91),
        new ReplayFrame(13, 70, 96),
        new ReplayFrame(14, 73, 101),
        new ReplayFrame(15, 76, 106),
        new ReplayFrame(16, 79, 111),
        new ReplayFrame(17, 82, 116),
        new ReplayFrame(18, 85, 121),
        new ReplayFrame(19, 88, 126),
        new ReplayFrame(20, 91, 131),
        new ReplayFrame(21, 94, 136),
        new ReplayFrame(22, 97, 141),
        new ReplayFrame(23, 100, 146),
        new ReplayFrame(24, 103, 151),
        new ReplayFrame(25, 106, 156),
        new ReplayFrame(26, 109, 161),
        new ReplayFrame(27, 112, 166),
        new ReplayFrame(28, 115, 171),
        new ReplayFrame(29, 118, 176),
        new ReplayFrame(30, 121, 181),
        new ReplayFrame(31, 124, 186),
        new ReplayFrame(32, 127, 191),
        new ReplayFrame(33, 130, 196),
        new ReplayFrame(34, 133, 201),
        new ReplayFrame(35, 136, 206),
        new ReplayFrame(36, 139, 211),
        new ReplayFrame(37, 142, 216),
        new ReplayFrame(38, 145, 221),
        new ReplayFrame(39, 148, 226),
        new ReplayFrame(40, 151, 231),
        new ReplayFrame(41, 154, 236),
        new ReplayFrame(42, 157, 241),
        new ReplayFrame(43, 160, 246),
        new ReplayFrame(44, 163, 251),
        new ReplayFrame(45, 166, 256),
        new ReplayFrame(46, 169, 261),
        new ReplayFrame(47, 172, 266),
        new ReplayFrame(48, 175, 271),
        new ReplayFrame(49, 178, 276),
        new ReplayFrame(50, 181, 281),
        new ReplayFrame(51, 184, 286),
        new ReplayFrame(52, 187, 291),
        new ReplayFrame(53, 190, 296),
        new ReplayFrame(54, 193, 301),
        new ReplayFrame(55, 196, 306),
        new ReplayFrame(56, 199, 311),
        new ReplayFrame(57, 202, 316),
        new ReplayFrame(58, 205, 321),
        new ReplayFrame(59, 208, 326),
        new ReplayFrame(60, 211, 331),
        new ReplayFrame(61, 214, 336),
        new ReplayFrame(62, 217, 341),
        new ReplayFrame(63, 220, 346),
        new ReplayFrame(64, 223, 351),
        new ReplayFrame(65, 226, 356),
        new ReplayFrame(66, 229, 361),
        new ReplayFrame(67, 232, 366),
        new ReplayFrame(68, 235, 371),
        new ReplayFrame(69, 238, 376),
        new ReplayFrame(70, 241, 381),
        new ReplayFrame(71, 244, 386),
        new ReplayFrame(72, 247, 391),
        new ReplayFrame(73, 250, 396),
        new ReplayFrame(74, 253, 401),
        new ReplayFrame(75, 256, 406),
        new ReplayFrame(76, 259, 411),
        new ReplayFrame(77, 262, 416),
        new ReplayFrame(78, 265, 421),
        new ReplayFrame(79, 268, 426)
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
