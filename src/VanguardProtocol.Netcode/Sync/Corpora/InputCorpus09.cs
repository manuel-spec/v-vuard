namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus09
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 9, 9),
        new ReplayFrame(1, 12, 14),
        new ReplayFrame(2, 15, 19),
        new ReplayFrame(3, 18, 24),
        new ReplayFrame(4, 21, 29),
        new ReplayFrame(5, 24, 34),
        new ReplayFrame(6, 27, 39),
        new ReplayFrame(7, 30, 44),
        new ReplayFrame(8, 33, 49),
        new ReplayFrame(9, 36, 54),
        new ReplayFrame(10, 39, 59),
        new ReplayFrame(11, 42, 64),
        new ReplayFrame(12, 45, 69),
        new ReplayFrame(13, 48, 74),
        new ReplayFrame(14, 51, 79),
        new ReplayFrame(15, 54, 84),
        new ReplayFrame(16, 57, 89),
        new ReplayFrame(17, 60, 94),
        new ReplayFrame(18, 63, 99),
        new ReplayFrame(19, 66, 104),
        new ReplayFrame(20, 69, 109),
        new ReplayFrame(21, 72, 114),
        new ReplayFrame(22, 75, 119),
        new ReplayFrame(23, 78, 124),
        new ReplayFrame(24, 81, 129),
        new ReplayFrame(25, 84, 134),
        new ReplayFrame(26, 87, 139),
        new ReplayFrame(27, 90, 144),
        new ReplayFrame(28, 93, 149),
        new ReplayFrame(29, 96, 154),
        new ReplayFrame(30, 99, 159),
        new ReplayFrame(31, 102, 164),
        new ReplayFrame(32, 105, 169),
        new ReplayFrame(33, 108, 174),
        new ReplayFrame(34, 111, 179),
        new ReplayFrame(35, 114, 184),
        new ReplayFrame(36, 117, 189),
        new ReplayFrame(37, 120, 194),
        new ReplayFrame(38, 123, 199),
        new ReplayFrame(39, 126, 204),
        new ReplayFrame(40, 129, 209),
        new ReplayFrame(41, 132, 214),
        new ReplayFrame(42, 135, 219),
        new ReplayFrame(43, 138, 224),
        new ReplayFrame(44, 141, 229),
        new ReplayFrame(45, 144, 234),
        new ReplayFrame(46, 147, 239),
        new ReplayFrame(47, 150, 244),
        new ReplayFrame(48, 153, 249),
        new ReplayFrame(49, 156, 254),
        new ReplayFrame(50, 159, 259),
        new ReplayFrame(51, 162, 264),
        new ReplayFrame(52, 165, 269),
        new ReplayFrame(53, 168, 274),
        new ReplayFrame(54, 171, 279),
        new ReplayFrame(55, 174, 284),
        new ReplayFrame(56, 177, 289),
        new ReplayFrame(57, 180, 294),
        new ReplayFrame(58, 183, 299),
        new ReplayFrame(59, 186, 304),
        new ReplayFrame(60, 189, 309),
        new ReplayFrame(61, 192, 314),
        new ReplayFrame(62, 195, 319),
        new ReplayFrame(63, 198, 324),
        new ReplayFrame(64, 201, 329),
        new ReplayFrame(65, 204, 334),
        new ReplayFrame(66, 207, 339),
        new ReplayFrame(67, 210, 344),
        new ReplayFrame(68, 213, 349),
        new ReplayFrame(69, 216, 354),
        new ReplayFrame(70, 219, 359),
        new ReplayFrame(71, 222, 364),
        new ReplayFrame(72, 225, 369),
        new ReplayFrame(73, 228, 374),
        new ReplayFrame(74, 231, 379),
        new ReplayFrame(75, 234, 384),
        new ReplayFrame(76, 237, 389),
        new ReplayFrame(77, 240, 394),
        new ReplayFrame(78, 243, 399),
        new ReplayFrame(79, 246, 404)
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
