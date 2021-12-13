namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus46
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 46, 46),
        new ReplayFrame(1, 49, 51),
        new ReplayFrame(2, 52, 56),
        new ReplayFrame(3, 55, 61),
        new ReplayFrame(4, 58, 66),
        new ReplayFrame(5, 61, 71),
        new ReplayFrame(6, 64, 76),
        new ReplayFrame(7, 67, 81),
        new ReplayFrame(8, 70, 86),
        new ReplayFrame(9, 73, 91),
        new ReplayFrame(10, 76, 96),
        new ReplayFrame(11, 79, 101),
        new ReplayFrame(12, 82, 106),
        new ReplayFrame(13, 85, 111),
        new ReplayFrame(14, 88, 116),
        new ReplayFrame(15, 91, 121),
        new ReplayFrame(16, 94, 126),
        new ReplayFrame(17, 97, 131),
        new ReplayFrame(18, 100, 136),
        new ReplayFrame(19, 103, 141),
        new ReplayFrame(20, 106, 146),
        new ReplayFrame(21, 109, 151),
        new ReplayFrame(22, 112, 156),
        new ReplayFrame(23, 115, 161),
        new ReplayFrame(24, 118, 166),
        new ReplayFrame(25, 121, 171),
        new ReplayFrame(26, 124, 176),
        new ReplayFrame(27, 127, 181),
        new ReplayFrame(28, 130, 186),
        new ReplayFrame(29, 133, 191),
        new ReplayFrame(30, 136, 196),
        new ReplayFrame(31, 139, 201),
        new ReplayFrame(32, 142, 206),
        new ReplayFrame(33, 145, 211),
        new ReplayFrame(34, 148, 216),
        new ReplayFrame(35, 151, 221),
        new ReplayFrame(36, 154, 226),
        new ReplayFrame(37, 157, 231),
        new ReplayFrame(38, 160, 236),
        new ReplayFrame(39, 163, 241),
        new ReplayFrame(40, 166, 246),
        new ReplayFrame(41, 169, 251),
        new ReplayFrame(42, 172, 256),
        new ReplayFrame(43, 175, 261),
        new ReplayFrame(44, 178, 266),
        new ReplayFrame(45, 181, 271),
        new ReplayFrame(46, 184, 276),
        new ReplayFrame(47, 187, 281),
        new ReplayFrame(48, 190, 286),
        new ReplayFrame(49, 193, 291),
        new ReplayFrame(50, 196, 296),
        new ReplayFrame(51, 199, 301),
        new ReplayFrame(52, 202, 306),
        new ReplayFrame(53, 205, 311),
        new ReplayFrame(54, 208, 316),
        new ReplayFrame(55, 211, 321),
        new ReplayFrame(56, 214, 326),
        new ReplayFrame(57, 217, 331),
        new ReplayFrame(58, 220, 336),
        new ReplayFrame(59, 223, 341),
        new ReplayFrame(60, 226, 346),
        new ReplayFrame(61, 229, 351),
        new ReplayFrame(62, 232, 356),
        new ReplayFrame(63, 235, 361),
        new ReplayFrame(64, 238, 366),
        new ReplayFrame(65, 241, 371),
        new ReplayFrame(66, 244, 376),
        new ReplayFrame(67, 247, 381),
        new ReplayFrame(68, 250, 386),
        new ReplayFrame(69, 253, 391),
        new ReplayFrame(70, 256, 396),
        new ReplayFrame(71, 259, 401),
        new ReplayFrame(72, 262, 406),
        new ReplayFrame(73, 265, 411),
        new ReplayFrame(74, 268, 416),
        new ReplayFrame(75, 271, 421),
        new ReplayFrame(76, 274, 426),
        new ReplayFrame(77, 277, 431),
        new ReplayFrame(78, 280, 436),
        new ReplayFrame(79, 283, 441)
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
