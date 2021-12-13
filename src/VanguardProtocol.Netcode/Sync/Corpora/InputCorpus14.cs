namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus14
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 14, 14),
        new ReplayFrame(1, 17, 19),
        new ReplayFrame(2, 20, 24),
        new ReplayFrame(3, 23, 29),
        new ReplayFrame(4, 26, 34),
        new ReplayFrame(5, 29, 39),
        new ReplayFrame(6, 32, 44),
        new ReplayFrame(7, 35, 49),
        new ReplayFrame(8, 38, 54),
        new ReplayFrame(9, 41, 59),
        new ReplayFrame(10, 44, 64),
        new ReplayFrame(11, 47, 69),
        new ReplayFrame(12, 50, 74),
        new ReplayFrame(13, 53, 79),
        new ReplayFrame(14, 56, 84),
        new ReplayFrame(15, 59, 89),
        new ReplayFrame(16, 62, 94),
        new ReplayFrame(17, 65, 99),
        new ReplayFrame(18, 68, 104),
        new ReplayFrame(19, 71, 109),
        new ReplayFrame(20, 74, 114),
        new ReplayFrame(21, 77, 119),
        new ReplayFrame(22, 80, 124),
        new ReplayFrame(23, 83, 129),
        new ReplayFrame(24, 86, 134),
        new ReplayFrame(25, 89, 139),
        new ReplayFrame(26, 92, 144),
        new ReplayFrame(27, 95, 149),
        new ReplayFrame(28, 98, 154),
        new ReplayFrame(29, 101, 159),
        new ReplayFrame(30, 104, 164),
        new ReplayFrame(31, 107, 169),
        new ReplayFrame(32, 110, 174),
        new ReplayFrame(33, 113, 179),
        new ReplayFrame(34, 116, 184),
        new ReplayFrame(35, 119, 189),
        new ReplayFrame(36, 122, 194),
        new ReplayFrame(37, 125, 199),
        new ReplayFrame(38, 128, 204),
        new ReplayFrame(39, 131, 209),
        new ReplayFrame(40, 134, 214),
        new ReplayFrame(41, 137, 219),
        new ReplayFrame(42, 140, 224),
        new ReplayFrame(43, 143, 229),
        new ReplayFrame(44, 146, 234),
        new ReplayFrame(45, 149, 239),
        new ReplayFrame(46, 152, 244),
        new ReplayFrame(47, 155, 249),
        new ReplayFrame(48, 158, 254),
        new ReplayFrame(49, 161, 259),
        new ReplayFrame(50, 164, 264),
        new ReplayFrame(51, 167, 269),
        new ReplayFrame(52, 170, 274),
        new ReplayFrame(53, 173, 279),
        new ReplayFrame(54, 176, 284),
        new ReplayFrame(55, 179, 289),
        new ReplayFrame(56, 182, 294),
        new ReplayFrame(57, 185, 299),
        new ReplayFrame(58, 188, 304),
        new ReplayFrame(59, 191, 309),
        new ReplayFrame(60, 194, 314),
        new ReplayFrame(61, 197, 319),
        new ReplayFrame(62, 200, 324),
        new ReplayFrame(63, 203, 329),
        new ReplayFrame(64, 206, 334),
        new ReplayFrame(65, 209, 339),
        new ReplayFrame(66, 212, 344),
        new ReplayFrame(67, 215, 349),
        new ReplayFrame(68, 218, 354),
        new ReplayFrame(69, 221, 359),
        new ReplayFrame(70, 224, 364),
        new ReplayFrame(71, 227, 369),
        new ReplayFrame(72, 230, 374),
        new ReplayFrame(73, 233, 379),
        new ReplayFrame(74, 236, 384),
        new ReplayFrame(75, 239, 389),
        new ReplayFrame(76, 242, 394),
        new ReplayFrame(77, 245, 399),
        new ReplayFrame(78, 248, 404),
        new ReplayFrame(79, 251, 409)
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
