namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus54
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 54, 54),
        new ReplayFrame(1, 57, 59),
        new ReplayFrame(2, 60, 64),
        new ReplayFrame(3, 63, 69),
        new ReplayFrame(4, 66, 74),
        new ReplayFrame(5, 69, 79),
        new ReplayFrame(6, 72, 84),
        new ReplayFrame(7, 75, 89),
        new ReplayFrame(8, 78, 94),
        new ReplayFrame(9, 81, 99),
        new ReplayFrame(10, 84, 104),
        new ReplayFrame(11, 87, 109),
        new ReplayFrame(12, 90, 114),
        new ReplayFrame(13, 93, 119),
        new ReplayFrame(14, 96, 124),
        new ReplayFrame(15, 99, 129),
        new ReplayFrame(16, 102, 134),
        new ReplayFrame(17, 105, 139),
        new ReplayFrame(18, 108, 144),
        new ReplayFrame(19, 111, 149),
        new ReplayFrame(20, 114, 154),
        new ReplayFrame(21, 117, 159),
        new ReplayFrame(22, 120, 164),
        new ReplayFrame(23, 123, 169),
        new ReplayFrame(24, 126, 174),
        new ReplayFrame(25, 129, 179),
        new ReplayFrame(26, 132, 184),
        new ReplayFrame(27, 135, 189),
        new ReplayFrame(28, 138, 194),
        new ReplayFrame(29, 141, 199),
        new ReplayFrame(30, 144, 204),
        new ReplayFrame(31, 147, 209),
        new ReplayFrame(32, 150, 214),
        new ReplayFrame(33, 153, 219),
        new ReplayFrame(34, 156, 224),
        new ReplayFrame(35, 159, 229),
        new ReplayFrame(36, 162, 234),
        new ReplayFrame(37, 165, 239),
        new ReplayFrame(38, 168, 244),
        new ReplayFrame(39, 171, 249),
        new ReplayFrame(40, 174, 254),
        new ReplayFrame(41, 177, 259),
        new ReplayFrame(42, 180, 264),
        new ReplayFrame(43, 183, 269),
        new ReplayFrame(44, 186, 274),
        new ReplayFrame(45, 189, 279),
        new ReplayFrame(46, 192, 284),
        new ReplayFrame(47, 195, 289),
        new ReplayFrame(48, 198, 294),
        new ReplayFrame(49, 201, 299),
        new ReplayFrame(50, 204, 304),
        new ReplayFrame(51, 207, 309),
        new ReplayFrame(52, 210, 314),
        new ReplayFrame(53, 213, 319),
        new ReplayFrame(54, 216, 324),
        new ReplayFrame(55, 219, 329),
        new ReplayFrame(56, 222, 334),
        new ReplayFrame(57, 225, 339),
        new ReplayFrame(58, 228, 344),
        new ReplayFrame(59, 231, 349),
        new ReplayFrame(60, 234, 354),
        new ReplayFrame(61, 237, 359),
        new ReplayFrame(62, 240, 364),
        new ReplayFrame(63, 243, 369),
        new ReplayFrame(64, 246, 374),
        new ReplayFrame(65, 249, 379),
        new ReplayFrame(66, 252, 384),
        new ReplayFrame(67, 255, 389),
        new ReplayFrame(68, 258, 394),
        new ReplayFrame(69, 261, 399),
        new ReplayFrame(70, 264, 404),
        new ReplayFrame(71, 267, 409),
        new ReplayFrame(72, 270, 414),
        new ReplayFrame(73, 273, 419),
        new ReplayFrame(74, 276, 424),
        new ReplayFrame(75, 279, 429),
        new ReplayFrame(76, 282, 434),
        new ReplayFrame(77, 285, 439),
        new ReplayFrame(78, 288, 444),
        new ReplayFrame(79, 291, 449)
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
