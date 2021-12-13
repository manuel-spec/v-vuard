namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus24
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 24, 24),
        new ReplayFrame(1, 27, 29),
        new ReplayFrame(2, 30, 34),
        new ReplayFrame(3, 33, 39),
        new ReplayFrame(4, 36, 44),
        new ReplayFrame(5, 39, 49),
        new ReplayFrame(6, 42, 54),
        new ReplayFrame(7, 45, 59),
        new ReplayFrame(8, 48, 64),
        new ReplayFrame(9, 51, 69),
        new ReplayFrame(10, 54, 74),
        new ReplayFrame(11, 57, 79),
        new ReplayFrame(12, 60, 84),
        new ReplayFrame(13, 63, 89),
        new ReplayFrame(14, 66, 94),
        new ReplayFrame(15, 69, 99),
        new ReplayFrame(16, 72, 104),
        new ReplayFrame(17, 75, 109),
        new ReplayFrame(18, 78, 114),
        new ReplayFrame(19, 81, 119),
        new ReplayFrame(20, 84, 124),
        new ReplayFrame(21, 87, 129),
        new ReplayFrame(22, 90, 134),
        new ReplayFrame(23, 93, 139),
        new ReplayFrame(24, 96, 144),
        new ReplayFrame(25, 99, 149),
        new ReplayFrame(26, 102, 154),
        new ReplayFrame(27, 105, 159),
        new ReplayFrame(28, 108, 164),
        new ReplayFrame(29, 111, 169),
        new ReplayFrame(30, 114, 174),
        new ReplayFrame(31, 117, 179),
        new ReplayFrame(32, 120, 184),
        new ReplayFrame(33, 123, 189),
        new ReplayFrame(34, 126, 194),
        new ReplayFrame(35, 129, 199),
        new ReplayFrame(36, 132, 204),
        new ReplayFrame(37, 135, 209),
        new ReplayFrame(38, 138, 214),
        new ReplayFrame(39, 141, 219),
        new ReplayFrame(40, 144, 224),
        new ReplayFrame(41, 147, 229),
        new ReplayFrame(42, 150, 234),
        new ReplayFrame(43, 153, 239),
        new ReplayFrame(44, 156, 244),
        new ReplayFrame(45, 159, 249),
        new ReplayFrame(46, 162, 254),
        new ReplayFrame(47, 165, 259),
        new ReplayFrame(48, 168, 264),
        new ReplayFrame(49, 171, 269),
        new ReplayFrame(50, 174, 274),
        new ReplayFrame(51, 177, 279),
        new ReplayFrame(52, 180, 284),
        new ReplayFrame(53, 183, 289),
        new ReplayFrame(54, 186, 294),
        new ReplayFrame(55, 189, 299),
        new ReplayFrame(56, 192, 304),
        new ReplayFrame(57, 195, 309),
        new ReplayFrame(58, 198, 314),
        new ReplayFrame(59, 201, 319),
        new ReplayFrame(60, 204, 324),
        new ReplayFrame(61, 207, 329),
        new ReplayFrame(62, 210, 334),
        new ReplayFrame(63, 213, 339),
        new ReplayFrame(64, 216, 344),
        new ReplayFrame(65, 219, 349),
        new ReplayFrame(66, 222, 354),
        new ReplayFrame(67, 225, 359),
        new ReplayFrame(68, 228, 364),
        new ReplayFrame(69, 231, 369),
        new ReplayFrame(70, 234, 374),
        new ReplayFrame(71, 237, 379),
        new ReplayFrame(72, 240, 384),
        new ReplayFrame(73, 243, 389),
        new ReplayFrame(74, 246, 394),
        new ReplayFrame(75, 249, 399),
        new ReplayFrame(76, 252, 404),
        new ReplayFrame(77, 255, 409),
        new ReplayFrame(78, 258, 414),
        new ReplayFrame(79, 261, 419)
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
