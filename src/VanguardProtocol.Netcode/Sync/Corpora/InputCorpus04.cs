namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus04
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 4, 4),
        new ReplayFrame(1, 7, 9),
        new ReplayFrame(2, 10, 14),
        new ReplayFrame(3, 13, 19),
        new ReplayFrame(4, 16, 24),
        new ReplayFrame(5, 19, 29),
        new ReplayFrame(6, 22, 34),
        new ReplayFrame(7, 25, 39),
        new ReplayFrame(8, 28, 44),
        new ReplayFrame(9, 31, 49),
        new ReplayFrame(10, 34, 54),
        new ReplayFrame(11, 37, 59),
        new ReplayFrame(12, 40, 64),
        new ReplayFrame(13, 43, 69),
        new ReplayFrame(14, 46, 74),
        new ReplayFrame(15, 49, 79),
        new ReplayFrame(16, 52, 84),
        new ReplayFrame(17, 55, 89),
        new ReplayFrame(18, 58, 94),
        new ReplayFrame(19, 61, 99),
        new ReplayFrame(20, 64, 104),
        new ReplayFrame(21, 67, 109),
        new ReplayFrame(22, 70, 114),
        new ReplayFrame(23, 73, 119),
        new ReplayFrame(24, 76, 124),
        new ReplayFrame(25, 79, 129),
        new ReplayFrame(26, 82, 134),
        new ReplayFrame(27, 85, 139),
        new ReplayFrame(28, 88, 144),
        new ReplayFrame(29, 91, 149),
        new ReplayFrame(30, 94, 154),
        new ReplayFrame(31, 97, 159),
        new ReplayFrame(32, 100, 164),
        new ReplayFrame(33, 103, 169),
        new ReplayFrame(34, 106, 174),
        new ReplayFrame(35, 109, 179),
        new ReplayFrame(36, 112, 184),
        new ReplayFrame(37, 115, 189),
        new ReplayFrame(38, 118, 194),
        new ReplayFrame(39, 121, 199),
        new ReplayFrame(40, 124, 204),
        new ReplayFrame(41, 127, 209),
        new ReplayFrame(42, 130, 214),
        new ReplayFrame(43, 133, 219),
        new ReplayFrame(44, 136, 224),
        new ReplayFrame(45, 139, 229),
        new ReplayFrame(46, 142, 234),
        new ReplayFrame(47, 145, 239),
        new ReplayFrame(48, 148, 244),
        new ReplayFrame(49, 151, 249),
        new ReplayFrame(50, 154, 254),
        new ReplayFrame(51, 157, 259),
        new ReplayFrame(52, 160, 264),
        new ReplayFrame(53, 163, 269),
        new ReplayFrame(54, 166, 274),
        new ReplayFrame(55, 169, 279),
        new ReplayFrame(56, 172, 284),
        new ReplayFrame(57, 175, 289),
        new ReplayFrame(58, 178, 294),
        new ReplayFrame(59, 181, 299),
        new ReplayFrame(60, 184, 304),
        new ReplayFrame(61, 187, 309),
        new ReplayFrame(62, 190, 314),
        new ReplayFrame(63, 193, 319),
        new ReplayFrame(64, 196, 324),
        new ReplayFrame(65, 199, 329),
        new ReplayFrame(66, 202, 334),
        new ReplayFrame(67, 205, 339),
        new ReplayFrame(68, 208, 344),
        new ReplayFrame(69, 211, 349),
        new ReplayFrame(70, 214, 354),
        new ReplayFrame(71, 217, 359),
        new ReplayFrame(72, 220, 364),
        new ReplayFrame(73, 223, 369),
        new ReplayFrame(74, 226, 374),
        new ReplayFrame(75, 229, 379),
        new ReplayFrame(76, 232, 384),
        new ReplayFrame(77, 235, 389),
        new ReplayFrame(78, 238, 394),
        new ReplayFrame(79, 241, 399)
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
