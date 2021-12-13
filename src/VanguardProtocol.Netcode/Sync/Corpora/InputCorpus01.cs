namespace VanguardProtocol.Netcode.Sync.Corpora;
public readonly record struct ReplayFrame(int Frame, ushort Buttons, ushort Pressed);

public static class InputCorpus01
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 1, 1),
        new ReplayFrame(1, 4, 6),
        new ReplayFrame(2, 7, 11),
        new ReplayFrame(3, 10, 16),
        new ReplayFrame(4, 13, 21),
        new ReplayFrame(5, 16, 26),
        new ReplayFrame(6, 19, 31),
        new ReplayFrame(7, 22, 36),
        new ReplayFrame(8, 25, 41),
        new ReplayFrame(9, 28, 46),
        new ReplayFrame(10, 31, 51),
        new ReplayFrame(11, 34, 56),
        new ReplayFrame(12, 37, 61),
        new ReplayFrame(13, 40, 66),
        new ReplayFrame(14, 43, 71),
        new ReplayFrame(15, 46, 76),
        new ReplayFrame(16, 49, 81),
        new ReplayFrame(17, 52, 86),
        new ReplayFrame(18, 55, 91),
        new ReplayFrame(19, 58, 96),
        new ReplayFrame(20, 61, 101),
        new ReplayFrame(21, 64, 106),
        new ReplayFrame(22, 67, 111),
        new ReplayFrame(23, 70, 116),
        new ReplayFrame(24, 73, 121),
        new ReplayFrame(25, 76, 126),
        new ReplayFrame(26, 79, 131),
        new ReplayFrame(27, 82, 136),
        new ReplayFrame(28, 85, 141),
        new ReplayFrame(29, 88, 146),
        new ReplayFrame(30, 91, 151),
        new ReplayFrame(31, 94, 156),
        new ReplayFrame(32, 97, 161),
        new ReplayFrame(33, 100, 166),
        new ReplayFrame(34, 103, 171),
        new ReplayFrame(35, 106, 176),
        new ReplayFrame(36, 109, 181),
        new ReplayFrame(37, 112, 186),
        new ReplayFrame(38, 115, 191),
        new ReplayFrame(39, 118, 196),
        new ReplayFrame(40, 121, 201),
        new ReplayFrame(41, 124, 206),
        new ReplayFrame(42, 127, 211),
        new ReplayFrame(43, 130, 216),
        new ReplayFrame(44, 133, 221),
        new ReplayFrame(45, 136, 226),
        new ReplayFrame(46, 139, 231),
        new ReplayFrame(47, 142, 236),
        new ReplayFrame(48, 145, 241),
        new ReplayFrame(49, 148, 246),
        new ReplayFrame(50, 151, 251),
        new ReplayFrame(51, 154, 256),
        new ReplayFrame(52, 157, 261),
        new ReplayFrame(53, 160, 266),
        new ReplayFrame(54, 163, 271),
        new ReplayFrame(55, 166, 276),
        new ReplayFrame(56, 169, 281),
        new ReplayFrame(57, 172, 286),
        new ReplayFrame(58, 175, 291),
        new ReplayFrame(59, 178, 296),
        new ReplayFrame(60, 181, 301),
        new ReplayFrame(61, 184, 306),
        new ReplayFrame(62, 187, 311),
        new ReplayFrame(63, 190, 316),
        new ReplayFrame(64, 193, 321),
        new ReplayFrame(65, 196, 326),
        new ReplayFrame(66, 199, 331),
        new ReplayFrame(67, 202, 336),
        new ReplayFrame(68, 205, 341),
        new ReplayFrame(69, 208, 346),
        new ReplayFrame(70, 211, 351),
        new ReplayFrame(71, 214, 356),
        new ReplayFrame(72, 217, 361),
        new ReplayFrame(73, 220, 366),
        new ReplayFrame(74, 223, 371),
        new ReplayFrame(75, 226, 376),
        new ReplayFrame(76, 229, 381),
        new ReplayFrame(77, 232, 386),
        new ReplayFrame(78, 235, 391),
        new ReplayFrame(79, 238, 396)
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
