namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus39
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 39, 39),
        new ReplayFrame(1, 42, 44),
        new ReplayFrame(2, 45, 49),
        new ReplayFrame(3, 48, 54),
        new ReplayFrame(4, 51, 59),
        new ReplayFrame(5, 54, 64),
        new ReplayFrame(6, 57, 69),
        new ReplayFrame(7, 60, 74),
        new ReplayFrame(8, 63, 79),
        new ReplayFrame(9, 66, 84),
        new ReplayFrame(10, 69, 89),
        new ReplayFrame(11, 72, 94),
        new ReplayFrame(12, 75, 99),
        new ReplayFrame(13, 78, 104),
        new ReplayFrame(14, 81, 109),
        new ReplayFrame(15, 84, 114),
        new ReplayFrame(16, 87, 119),
        new ReplayFrame(17, 90, 124),
        new ReplayFrame(18, 93, 129),
        new ReplayFrame(19, 96, 134),
        new ReplayFrame(20, 99, 139),
        new ReplayFrame(21, 102, 144),
        new ReplayFrame(22, 105, 149),
        new ReplayFrame(23, 108, 154),
        new ReplayFrame(24, 111, 159),
        new ReplayFrame(25, 114, 164),
        new ReplayFrame(26, 117, 169),
        new ReplayFrame(27, 120, 174),
        new ReplayFrame(28, 123, 179),
        new ReplayFrame(29, 126, 184),
        new ReplayFrame(30, 129, 189),
        new ReplayFrame(31, 132, 194),
        new ReplayFrame(32, 135, 199),
        new ReplayFrame(33, 138, 204),
        new ReplayFrame(34, 141, 209),
        new ReplayFrame(35, 144, 214),
        new ReplayFrame(36, 147, 219),
        new ReplayFrame(37, 150, 224),
        new ReplayFrame(38, 153, 229),
        new ReplayFrame(39, 156, 234),
        new ReplayFrame(40, 159, 239),
        new ReplayFrame(41, 162, 244),
        new ReplayFrame(42, 165, 249),
        new ReplayFrame(43, 168, 254),
        new ReplayFrame(44, 171, 259),
        new ReplayFrame(45, 174, 264),
        new ReplayFrame(46, 177, 269),
        new ReplayFrame(47, 180, 274),
        new ReplayFrame(48, 183, 279),
        new ReplayFrame(49, 186, 284),
        new ReplayFrame(50, 189, 289),
        new ReplayFrame(51, 192, 294),
        new ReplayFrame(52, 195, 299),
        new ReplayFrame(53, 198, 304),
        new ReplayFrame(54, 201, 309),
        new ReplayFrame(55, 204, 314),
        new ReplayFrame(56, 207, 319),
        new ReplayFrame(57, 210, 324),
        new ReplayFrame(58, 213, 329),
        new ReplayFrame(59, 216, 334),
        new ReplayFrame(60, 219, 339),
        new ReplayFrame(61, 222, 344),
        new ReplayFrame(62, 225, 349),
        new ReplayFrame(63, 228, 354),
        new ReplayFrame(64, 231, 359),
        new ReplayFrame(65, 234, 364),
        new ReplayFrame(66, 237, 369),
        new ReplayFrame(67, 240, 374),
        new ReplayFrame(68, 243, 379),
        new ReplayFrame(69, 246, 384),
        new ReplayFrame(70, 249, 389),
        new ReplayFrame(71, 252, 394),
        new ReplayFrame(72, 255, 399),
        new ReplayFrame(73, 258, 404),
        new ReplayFrame(74, 261, 409),
        new ReplayFrame(75, 264, 414),
        new ReplayFrame(76, 267, 419),
        new ReplayFrame(77, 270, 424),
        new ReplayFrame(78, 273, 429),
        new ReplayFrame(79, 276, 434)
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
