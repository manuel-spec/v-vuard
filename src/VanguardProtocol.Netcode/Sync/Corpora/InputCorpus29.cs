namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus29
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 29, 29),
        new ReplayFrame(1, 32, 34),
        new ReplayFrame(2, 35, 39),
        new ReplayFrame(3, 38, 44),
        new ReplayFrame(4, 41, 49),
        new ReplayFrame(5, 44, 54),
        new ReplayFrame(6, 47, 59),
        new ReplayFrame(7, 50, 64),
        new ReplayFrame(8, 53, 69),
        new ReplayFrame(9, 56, 74),
        new ReplayFrame(10, 59, 79),
        new ReplayFrame(11, 62, 84),
        new ReplayFrame(12, 65, 89),
        new ReplayFrame(13, 68, 94),
        new ReplayFrame(14, 71, 99),
        new ReplayFrame(15, 74, 104),
        new ReplayFrame(16, 77, 109),
        new ReplayFrame(17, 80, 114),
        new ReplayFrame(18, 83, 119),
        new ReplayFrame(19, 86, 124),
        new ReplayFrame(20, 89, 129),
        new ReplayFrame(21, 92, 134),
        new ReplayFrame(22, 95, 139),
        new ReplayFrame(23, 98, 144),
        new ReplayFrame(24, 101, 149),
        new ReplayFrame(25, 104, 154),
        new ReplayFrame(26, 107, 159),
        new ReplayFrame(27, 110, 164),
        new ReplayFrame(28, 113, 169),
        new ReplayFrame(29, 116, 174),
        new ReplayFrame(30, 119, 179),
        new ReplayFrame(31, 122, 184),
        new ReplayFrame(32, 125, 189),
        new ReplayFrame(33, 128, 194),
        new ReplayFrame(34, 131, 199),
        new ReplayFrame(35, 134, 204),
        new ReplayFrame(36, 137, 209),
        new ReplayFrame(37, 140, 214),
        new ReplayFrame(38, 143, 219),
        new ReplayFrame(39, 146, 224),
        new ReplayFrame(40, 149, 229),
        new ReplayFrame(41, 152, 234),
        new ReplayFrame(42, 155, 239),
        new ReplayFrame(43, 158, 244),
        new ReplayFrame(44, 161, 249),
        new ReplayFrame(45, 164, 254),
        new ReplayFrame(46, 167, 259),
        new ReplayFrame(47, 170, 264),
        new ReplayFrame(48, 173, 269),
        new ReplayFrame(49, 176, 274),
        new ReplayFrame(50, 179, 279),
        new ReplayFrame(51, 182, 284),
        new ReplayFrame(52, 185, 289),
        new ReplayFrame(53, 188, 294),
        new ReplayFrame(54, 191, 299),
        new ReplayFrame(55, 194, 304),
        new ReplayFrame(56, 197, 309),
        new ReplayFrame(57, 200, 314),
        new ReplayFrame(58, 203, 319),
        new ReplayFrame(59, 206, 324),
        new ReplayFrame(60, 209, 329),
        new ReplayFrame(61, 212, 334),
        new ReplayFrame(62, 215, 339),
        new ReplayFrame(63, 218, 344),
        new ReplayFrame(64, 221, 349),
        new ReplayFrame(65, 224, 354),
        new ReplayFrame(66, 227, 359),
        new ReplayFrame(67, 230, 364),
        new ReplayFrame(68, 233, 369),
        new ReplayFrame(69, 236, 374),
        new ReplayFrame(70, 239, 379),
        new ReplayFrame(71, 242, 384),
        new ReplayFrame(72, 245, 389),
        new ReplayFrame(73, 248, 394),
        new ReplayFrame(74, 251, 399),
        new ReplayFrame(75, 254, 404),
        new ReplayFrame(76, 257, 409),
        new ReplayFrame(77, 260, 414),
        new ReplayFrame(78, 263, 419),
        new ReplayFrame(79, 266, 424)
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
