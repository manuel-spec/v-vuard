namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus19
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 19, 19),
        new ReplayFrame(1, 22, 24),
        new ReplayFrame(2, 25, 29),
        new ReplayFrame(3, 28, 34),
        new ReplayFrame(4, 31, 39),
        new ReplayFrame(5, 34, 44),
        new ReplayFrame(6, 37, 49),
        new ReplayFrame(7, 40, 54),
        new ReplayFrame(8, 43, 59),
        new ReplayFrame(9, 46, 64),
        new ReplayFrame(10, 49, 69),
        new ReplayFrame(11, 52, 74),
        new ReplayFrame(12, 55, 79),
        new ReplayFrame(13, 58, 84),
        new ReplayFrame(14, 61, 89),
        new ReplayFrame(15, 64, 94),
        new ReplayFrame(16, 67, 99),
        new ReplayFrame(17, 70, 104),
        new ReplayFrame(18, 73, 109),
        new ReplayFrame(19, 76, 114),
        new ReplayFrame(20, 79, 119),
        new ReplayFrame(21, 82, 124),
        new ReplayFrame(22, 85, 129),
        new ReplayFrame(23, 88, 134),
        new ReplayFrame(24, 91, 139),
        new ReplayFrame(25, 94, 144),
        new ReplayFrame(26, 97, 149),
        new ReplayFrame(27, 100, 154),
        new ReplayFrame(28, 103, 159),
        new ReplayFrame(29, 106, 164),
        new ReplayFrame(30, 109, 169),
        new ReplayFrame(31, 112, 174),
        new ReplayFrame(32, 115, 179),
        new ReplayFrame(33, 118, 184),
        new ReplayFrame(34, 121, 189),
        new ReplayFrame(35, 124, 194),
        new ReplayFrame(36, 127, 199),
        new ReplayFrame(37, 130, 204),
        new ReplayFrame(38, 133, 209),
        new ReplayFrame(39, 136, 214),
        new ReplayFrame(40, 139, 219),
        new ReplayFrame(41, 142, 224),
        new ReplayFrame(42, 145, 229),
        new ReplayFrame(43, 148, 234),
        new ReplayFrame(44, 151, 239),
        new ReplayFrame(45, 154, 244),
        new ReplayFrame(46, 157, 249),
        new ReplayFrame(47, 160, 254),
        new ReplayFrame(48, 163, 259),
        new ReplayFrame(49, 166, 264),
        new ReplayFrame(50, 169, 269),
        new ReplayFrame(51, 172, 274),
        new ReplayFrame(52, 175, 279),
        new ReplayFrame(53, 178, 284),
        new ReplayFrame(54, 181, 289),
        new ReplayFrame(55, 184, 294),
        new ReplayFrame(56, 187, 299),
        new ReplayFrame(57, 190, 304),
        new ReplayFrame(58, 193, 309),
        new ReplayFrame(59, 196, 314),
        new ReplayFrame(60, 199, 319),
        new ReplayFrame(61, 202, 324),
        new ReplayFrame(62, 205, 329),
        new ReplayFrame(63, 208, 334),
        new ReplayFrame(64, 211, 339),
        new ReplayFrame(65, 214, 344),
        new ReplayFrame(66, 217, 349),
        new ReplayFrame(67, 220, 354),
        new ReplayFrame(68, 223, 359),
        new ReplayFrame(69, 226, 364),
        new ReplayFrame(70, 229, 369),
        new ReplayFrame(71, 232, 374),
        new ReplayFrame(72, 235, 379),
        new ReplayFrame(73, 238, 384),
        new ReplayFrame(74, 241, 389),
        new ReplayFrame(75, 244, 394),
        new ReplayFrame(76, 247, 399),
        new ReplayFrame(77, 250, 404),
        new ReplayFrame(78, 253, 409),
        new ReplayFrame(79, 256, 414)
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
