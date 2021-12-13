namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus49
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 49, 49),
        new ReplayFrame(1, 52, 54),
        new ReplayFrame(2, 55, 59),
        new ReplayFrame(3, 58, 64),
        new ReplayFrame(4, 61, 69),
        new ReplayFrame(5, 64, 74),
        new ReplayFrame(6, 67, 79),
        new ReplayFrame(7, 70, 84),
        new ReplayFrame(8, 73, 89),
        new ReplayFrame(9, 76, 94),
        new ReplayFrame(10, 79, 99),
        new ReplayFrame(11, 82, 104),
        new ReplayFrame(12, 85, 109),
        new ReplayFrame(13, 88, 114),
        new ReplayFrame(14, 91, 119),
        new ReplayFrame(15, 94, 124),
        new ReplayFrame(16, 97, 129),
        new ReplayFrame(17, 100, 134),
        new ReplayFrame(18, 103, 139),
        new ReplayFrame(19, 106, 144),
        new ReplayFrame(20, 109, 149),
        new ReplayFrame(21, 112, 154),
        new ReplayFrame(22, 115, 159),
        new ReplayFrame(23, 118, 164),
        new ReplayFrame(24, 121, 169),
        new ReplayFrame(25, 124, 174),
        new ReplayFrame(26, 127, 179),
        new ReplayFrame(27, 130, 184),
        new ReplayFrame(28, 133, 189),
        new ReplayFrame(29, 136, 194),
        new ReplayFrame(30, 139, 199),
        new ReplayFrame(31, 142, 204),
        new ReplayFrame(32, 145, 209),
        new ReplayFrame(33, 148, 214),
        new ReplayFrame(34, 151, 219),
        new ReplayFrame(35, 154, 224),
        new ReplayFrame(36, 157, 229),
        new ReplayFrame(37, 160, 234),
        new ReplayFrame(38, 163, 239),
        new ReplayFrame(39, 166, 244),
        new ReplayFrame(40, 169, 249),
        new ReplayFrame(41, 172, 254),
        new ReplayFrame(42, 175, 259),
        new ReplayFrame(43, 178, 264),
        new ReplayFrame(44, 181, 269),
        new ReplayFrame(45, 184, 274),
        new ReplayFrame(46, 187, 279),
        new ReplayFrame(47, 190, 284),
        new ReplayFrame(48, 193, 289),
        new ReplayFrame(49, 196, 294),
        new ReplayFrame(50, 199, 299),
        new ReplayFrame(51, 202, 304),
        new ReplayFrame(52, 205, 309),
        new ReplayFrame(53, 208, 314),
        new ReplayFrame(54, 211, 319),
        new ReplayFrame(55, 214, 324),
        new ReplayFrame(56, 217, 329),
        new ReplayFrame(57, 220, 334),
        new ReplayFrame(58, 223, 339),
        new ReplayFrame(59, 226, 344),
        new ReplayFrame(60, 229, 349),
        new ReplayFrame(61, 232, 354),
        new ReplayFrame(62, 235, 359),
        new ReplayFrame(63, 238, 364),
        new ReplayFrame(64, 241, 369),
        new ReplayFrame(65, 244, 374),
        new ReplayFrame(66, 247, 379),
        new ReplayFrame(67, 250, 384),
        new ReplayFrame(68, 253, 389),
        new ReplayFrame(69, 256, 394),
        new ReplayFrame(70, 259, 399),
        new ReplayFrame(71, 262, 404),
        new ReplayFrame(72, 265, 409),
        new ReplayFrame(73, 268, 414),
        new ReplayFrame(74, 271, 419),
        new ReplayFrame(75, 274, 424),
        new ReplayFrame(76, 277, 429),
        new ReplayFrame(77, 280, 434),
        new ReplayFrame(78, 283, 439),
        new ReplayFrame(79, 286, 444)
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
