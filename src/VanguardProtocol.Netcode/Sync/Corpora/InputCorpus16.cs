namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus16
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 16, 16),
        new ReplayFrame(1, 19, 21),
        new ReplayFrame(2, 22, 26),
        new ReplayFrame(3, 25, 31),
        new ReplayFrame(4, 28, 36),
        new ReplayFrame(5, 31, 41),
        new ReplayFrame(6, 34, 46),
        new ReplayFrame(7, 37, 51),
        new ReplayFrame(8, 40, 56),
        new ReplayFrame(9, 43, 61),
        new ReplayFrame(10, 46, 66),
        new ReplayFrame(11, 49, 71),
        new ReplayFrame(12, 52, 76),
        new ReplayFrame(13, 55, 81),
        new ReplayFrame(14, 58, 86),
        new ReplayFrame(15, 61, 91),
        new ReplayFrame(16, 64, 96),
        new ReplayFrame(17, 67, 101),
        new ReplayFrame(18, 70, 106),
        new ReplayFrame(19, 73, 111),
        new ReplayFrame(20, 76, 116),
        new ReplayFrame(21, 79, 121),
        new ReplayFrame(22, 82, 126),
        new ReplayFrame(23, 85, 131),
        new ReplayFrame(24, 88, 136),
        new ReplayFrame(25, 91, 141),
        new ReplayFrame(26, 94, 146),
        new ReplayFrame(27, 97, 151),
        new ReplayFrame(28, 100, 156),
        new ReplayFrame(29, 103, 161),
        new ReplayFrame(30, 106, 166),
        new ReplayFrame(31, 109, 171),
        new ReplayFrame(32, 112, 176),
        new ReplayFrame(33, 115, 181),
        new ReplayFrame(34, 118, 186),
        new ReplayFrame(35, 121, 191),
        new ReplayFrame(36, 124, 196),
        new ReplayFrame(37, 127, 201),
        new ReplayFrame(38, 130, 206),
        new ReplayFrame(39, 133, 211),
        new ReplayFrame(40, 136, 216),
        new ReplayFrame(41, 139, 221),
        new ReplayFrame(42, 142, 226),
        new ReplayFrame(43, 145, 231),
        new ReplayFrame(44, 148, 236),
        new ReplayFrame(45, 151, 241),
        new ReplayFrame(46, 154, 246),
        new ReplayFrame(47, 157, 251),
        new ReplayFrame(48, 160, 256),
        new ReplayFrame(49, 163, 261),
        new ReplayFrame(50, 166, 266),
        new ReplayFrame(51, 169, 271),
        new ReplayFrame(52, 172, 276),
        new ReplayFrame(53, 175, 281),
        new ReplayFrame(54, 178, 286),
        new ReplayFrame(55, 181, 291),
        new ReplayFrame(56, 184, 296),
        new ReplayFrame(57, 187, 301),
        new ReplayFrame(58, 190, 306),
        new ReplayFrame(59, 193, 311),
        new ReplayFrame(60, 196, 316),
        new ReplayFrame(61, 199, 321),
        new ReplayFrame(62, 202, 326),
        new ReplayFrame(63, 205, 331),
        new ReplayFrame(64, 208, 336),
        new ReplayFrame(65, 211, 341),
        new ReplayFrame(66, 214, 346),
        new ReplayFrame(67, 217, 351),
        new ReplayFrame(68, 220, 356),
        new ReplayFrame(69, 223, 361),
        new ReplayFrame(70, 226, 366),
        new ReplayFrame(71, 229, 371),
        new ReplayFrame(72, 232, 376),
        new ReplayFrame(73, 235, 381),
        new ReplayFrame(74, 238, 386),
        new ReplayFrame(75, 241, 391),
        new ReplayFrame(76, 244, 396),
        new ReplayFrame(77, 247, 401),
        new ReplayFrame(78, 250, 406),
        new ReplayFrame(79, 253, 411)
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
