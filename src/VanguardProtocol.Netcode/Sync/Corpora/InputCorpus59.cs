namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus59
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 59, 59),
        new ReplayFrame(1, 62, 64),
        new ReplayFrame(2, 65, 69),
        new ReplayFrame(3, 68, 74),
        new ReplayFrame(4, 71, 79),
        new ReplayFrame(5, 74, 84),
        new ReplayFrame(6, 77, 89),
        new ReplayFrame(7, 80, 94),
        new ReplayFrame(8, 83, 99),
        new ReplayFrame(9, 86, 104),
        new ReplayFrame(10, 89, 109),
        new ReplayFrame(11, 92, 114),
        new ReplayFrame(12, 95, 119),
        new ReplayFrame(13, 98, 124),
        new ReplayFrame(14, 101, 129),
        new ReplayFrame(15, 104, 134),
        new ReplayFrame(16, 107, 139),
        new ReplayFrame(17, 110, 144),
        new ReplayFrame(18, 113, 149),
        new ReplayFrame(19, 116, 154),
        new ReplayFrame(20, 119, 159),
        new ReplayFrame(21, 122, 164),
        new ReplayFrame(22, 125, 169),
        new ReplayFrame(23, 128, 174),
        new ReplayFrame(24, 131, 179),
        new ReplayFrame(25, 134, 184),
        new ReplayFrame(26, 137, 189),
        new ReplayFrame(27, 140, 194),
        new ReplayFrame(28, 143, 199),
        new ReplayFrame(29, 146, 204),
        new ReplayFrame(30, 149, 209),
        new ReplayFrame(31, 152, 214),
        new ReplayFrame(32, 155, 219),
        new ReplayFrame(33, 158, 224),
        new ReplayFrame(34, 161, 229),
        new ReplayFrame(35, 164, 234),
        new ReplayFrame(36, 167, 239),
        new ReplayFrame(37, 170, 244),
        new ReplayFrame(38, 173, 249),
        new ReplayFrame(39, 176, 254),
        new ReplayFrame(40, 179, 259),
        new ReplayFrame(41, 182, 264),
        new ReplayFrame(42, 185, 269),
        new ReplayFrame(43, 188, 274),
        new ReplayFrame(44, 191, 279),
        new ReplayFrame(45, 194, 284),
        new ReplayFrame(46, 197, 289),
        new ReplayFrame(47, 200, 294),
        new ReplayFrame(48, 203, 299),
        new ReplayFrame(49, 206, 304),
        new ReplayFrame(50, 209, 309),
        new ReplayFrame(51, 212, 314),
        new ReplayFrame(52, 215, 319),
        new ReplayFrame(53, 218, 324),
        new ReplayFrame(54, 221, 329),
        new ReplayFrame(55, 224, 334),
        new ReplayFrame(56, 227, 339),
        new ReplayFrame(57, 230, 344),
        new ReplayFrame(58, 233, 349),
        new ReplayFrame(59, 236, 354),
        new ReplayFrame(60, 239, 359),
        new ReplayFrame(61, 242, 364),
        new ReplayFrame(62, 245, 369),
        new ReplayFrame(63, 248, 374),
        new ReplayFrame(64, 251, 379),
        new ReplayFrame(65, 254, 384),
        new ReplayFrame(66, 257, 389),
        new ReplayFrame(67, 260, 394),
        new ReplayFrame(68, 263, 399),
        new ReplayFrame(69, 266, 404),
        new ReplayFrame(70, 269, 409),
        new ReplayFrame(71, 272, 414),
        new ReplayFrame(72, 275, 419),
        new ReplayFrame(73, 278, 424),
        new ReplayFrame(74, 281, 429),
        new ReplayFrame(75, 284, 434),
        new ReplayFrame(76, 287, 439),
        new ReplayFrame(77, 290, 444),
        new ReplayFrame(78, 293, 449),
        new ReplayFrame(79, 296, 454)
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
