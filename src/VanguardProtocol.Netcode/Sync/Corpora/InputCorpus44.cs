namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus44
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 44, 44),
        new ReplayFrame(1, 47, 49),
        new ReplayFrame(2, 50, 54),
        new ReplayFrame(3, 53, 59),
        new ReplayFrame(4, 56, 64),
        new ReplayFrame(5, 59, 69),
        new ReplayFrame(6, 62, 74),
        new ReplayFrame(7, 65, 79),
        new ReplayFrame(8, 68, 84),
        new ReplayFrame(9, 71, 89),
        new ReplayFrame(10, 74, 94),
        new ReplayFrame(11, 77, 99),
        new ReplayFrame(12, 80, 104),
        new ReplayFrame(13, 83, 109),
        new ReplayFrame(14, 86, 114),
        new ReplayFrame(15, 89, 119),
        new ReplayFrame(16, 92, 124),
        new ReplayFrame(17, 95, 129),
        new ReplayFrame(18, 98, 134),
        new ReplayFrame(19, 101, 139),
        new ReplayFrame(20, 104, 144),
        new ReplayFrame(21, 107, 149),
        new ReplayFrame(22, 110, 154),
        new ReplayFrame(23, 113, 159),
        new ReplayFrame(24, 116, 164),
        new ReplayFrame(25, 119, 169),
        new ReplayFrame(26, 122, 174),
        new ReplayFrame(27, 125, 179),
        new ReplayFrame(28, 128, 184),
        new ReplayFrame(29, 131, 189),
        new ReplayFrame(30, 134, 194),
        new ReplayFrame(31, 137, 199),
        new ReplayFrame(32, 140, 204),
        new ReplayFrame(33, 143, 209),
        new ReplayFrame(34, 146, 214),
        new ReplayFrame(35, 149, 219),
        new ReplayFrame(36, 152, 224),
        new ReplayFrame(37, 155, 229),
        new ReplayFrame(38, 158, 234),
        new ReplayFrame(39, 161, 239),
        new ReplayFrame(40, 164, 244),
        new ReplayFrame(41, 167, 249),
        new ReplayFrame(42, 170, 254),
        new ReplayFrame(43, 173, 259),
        new ReplayFrame(44, 176, 264),
        new ReplayFrame(45, 179, 269),
        new ReplayFrame(46, 182, 274),
        new ReplayFrame(47, 185, 279),
        new ReplayFrame(48, 188, 284),
        new ReplayFrame(49, 191, 289),
        new ReplayFrame(50, 194, 294),
        new ReplayFrame(51, 197, 299),
        new ReplayFrame(52, 200, 304),
        new ReplayFrame(53, 203, 309),
        new ReplayFrame(54, 206, 314),
        new ReplayFrame(55, 209, 319),
        new ReplayFrame(56, 212, 324),
        new ReplayFrame(57, 215, 329),
        new ReplayFrame(58, 218, 334),
        new ReplayFrame(59, 221, 339),
        new ReplayFrame(60, 224, 344),
        new ReplayFrame(61, 227, 349),
        new ReplayFrame(62, 230, 354),
        new ReplayFrame(63, 233, 359),
        new ReplayFrame(64, 236, 364),
        new ReplayFrame(65, 239, 369),
        new ReplayFrame(66, 242, 374),
        new ReplayFrame(67, 245, 379),
        new ReplayFrame(68, 248, 384),
        new ReplayFrame(69, 251, 389),
        new ReplayFrame(70, 254, 394),
        new ReplayFrame(71, 257, 399),
        new ReplayFrame(72, 260, 404),
        new ReplayFrame(73, 263, 409),
        new ReplayFrame(74, 266, 414),
        new ReplayFrame(75, 269, 419),
        new ReplayFrame(76, 272, 424),
        new ReplayFrame(77, 275, 429),
        new ReplayFrame(78, 278, 434),
        new ReplayFrame(79, 281, 439)
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
