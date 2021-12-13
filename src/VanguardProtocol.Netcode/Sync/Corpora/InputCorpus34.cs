namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus34
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 34, 34),
        new ReplayFrame(1, 37, 39),
        new ReplayFrame(2, 40, 44),
        new ReplayFrame(3, 43, 49),
        new ReplayFrame(4, 46, 54),
        new ReplayFrame(5, 49, 59),
        new ReplayFrame(6, 52, 64),
        new ReplayFrame(7, 55, 69),
        new ReplayFrame(8, 58, 74),
        new ReplayFrame(9, 61, 79),
        new ReplayFrame(10, 64, 84),
        new ReplayFrame(11, 67, 89),
        new ReplayFrame(12, 70, 94),
        new ReplayFrame(13, 73, 99),
        new ReplayFrame(14, 76, 104),
        new ReplayFrame(15, 79, 109),
        new ReplayFrame(16, 82, 114),
        new ReplayFrame(17, 85, 119),
        new ReplayFrame(18, 88, 124),
        new ReplayFrame(19, 91, 129),
        new ReplayFrame(20, 94, 134),
        new ReplayFrame(21, 97, 139),
        new ReplayFrame(22, 100, 144),
        new ReplayFrame(23, 103, 149),
        new ReplayFrame(24, 106, 154),
        new ReplayFrame(25, 109, 159),
        new ReplayFrame(26, 112, 164),
        new ReplayFrame(27, 115, 169),
        new ReplayFrame(28, 118, 174),
        new ReplayFrame(29, 121, 179),
        new ReplayFrame(30, 124, 184),
        new ReplayFrame(31, 127, 189),
        new ReplayFrame(32, 130, 194),
        new ReplayFrame(33, 133, 199),
        new ReplayFrame(34, 136, 204),
        new ReplayFrame(35, 139, 209),
        new ReplayFrame(36, 142, 214),
        new ReplayFrame(37, 145, 219),
        new ReplayFrame(38, 148, 224),
        new ReplayFrame(39, 151, 229),
        new ReplayFrame(40, 154, 234),
        new ReplayFrame(41, 157, 239),
        new ReplayFrame(42, 160, 244),
        new ReplayFrame(43, 163, 249),
        new ReplayFrame(44, 166, 254),
        new ReplayFrame(45, 169, 259),
        new ReplayFrame(46, 172, 264),
        new ReplayFrame(47, 175, 269),
        new ReplayFrame(48, 178, 274),
        new ReplayFrame(49, 181, 279),
        new ReplayFrame(50, 184, 284),
        new ReplayFrame(51, 187, 289),
        new ReplayFrame(52, 190, 294),
        new ReplayFrame(53, 193, 299),
        new ReplayFrame(54, 196, 304),
        new ReplayFrame(55, 199, 309),
        new ReplayFrame(56, 202, 314),
        new ReplayFrame(57, 205, 319),
        new ReplayFrame(58, 208, 324),
        new ReplayFrame(59, 211, 329),
        new ReplayFrame(60, 214, 334),
        new ReplayFrame(61, 217, 339),
        new ReplayFrame(62, 220, 344),
        new ReplayFrame(63, 223, 349),
        new ReplayFrame(64, 226, 354),
        new ReplayFrame(65, 229, 359),
        new ReplayFrame(66, 232, 364),
        new ReplayFrame(67, 235, 369),
        new ReplayFrame(68, 238, 374),
        new ReplayFrame(69, 241, 379),
        new ReplayFrame(70, 244, 384),
        new ReplayFrame(71, 247, 389),
        new ReplayFrame(72, 250, 394),
        new ReplayFrame(73, 253, 399),
        new ReplayFrame(74, 256, 404),
        new ReplayFrame(75, 259, 409),
        new ReplayFrame(76, 262, 414),
        new ReplayFrame(77, 265, 419),
        new ReplayFrame(78, 268, 424),
        new ReplayFrame(79, 271, 429)
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
