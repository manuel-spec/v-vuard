namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus42
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 42, 42),
        new ReplayFrame(1, 45, 47),
        new ReplayFrame(2, 48, 52),
        new ReplayFrame(3, 51, 57),
        new ReplayFrame(4, 54, 62),
        new ReplayFrame(5, 57, 67),
        new ReplayFrame(6, 60, 72),
        new ReplayFrame(7, 63, 77),
        new ReplayFrame(8, 66, 82),
        new ReplayFrame(9, 69, 87),
        new ReplayFrame(10, 72, 92),
        new ReplayFrame(11, 75, 97),
        new ReplayFrame(12, 78, 102),
        new ReplayFrame(13, 81, 107),
        new ReplayFrame(14, 84, 112),
        new ReplayFrame(15, 87, 117),
        new ReplayFrame(16, 90, 122),
        new ReplayFrame(17, 93, 127),
        new ReplayFrame(18, 96, 132),
        new ReplayFrame(19, 99, 137),
        new ReplayFrame(20, 102, 142),
        new ReplayFrame(21, 105, 147),
        new ReplayFrame(22, 108, 152),
        new ReplayFrame(23, 111, 157),
        new ReplayFrame(24, 114, 162),
        new ReplayFrame(25, 117, 167),
        new ReplayFrame(26, 120, 172),
        new ReplayFrame(27, 123, 177),
        new ReplayFrame(28, 126, 182),
        new ReplayFrame(29, 129, 187),
        new ReplayFrame(30, 132, 192),
        new ReplayFrame(31, 135, 197),
        new ReplayFrame(32, 138, 202),
        new ReplayFrame(33, 141, 207),
        new ReplayFrame(34, 144, 212),
        new ReplayFrame(35, 147, 217),
        new ReplayFrame(36, 150, 222),
        new ReplayFrame(37, 153, 227),
        new ReplayFrame(38, 156, 232),
        new ReplayFrame(39, 159, 237),
        new ReplayFrame(40, 162, 242),
        new ReplayFrame(41, 165, 247),
        new ReplayFrame(42, 168, 252),
        new ReplayFrame(43, 171, 257),
        new ReplayFrame(44, 174, 262),
        new ReplayFrame(45, 177, 267),
        new ReplayFrame(46, 180, 272),
        new ReplayFrame(47, 183, 277),
        new ReplayFrame(48, 186, 282),
        new ReplayFrame(49, 189, 287),
        new ReplayFrame(50, 192, 292),
        new ReplayFrame(51, 195, 297),
        new ReplayFrame(52, 198, 302),
        new ReplayFrame(53, 201, 307),
        new ReplayFrame(54, 204, 312),
        new ReplayFrame(55, 207, 317),
        new ReplayFrame(56, 210, 322),
        new ReplayFrame(57, 213, 327),
        new ReplayFrame(58, 216, 332),
        new ReplayFrame(59, 219, 337),
        new ReplayFrame(60, 222, 342),
        new ReplayFrame(61, 225, 347),
        new ReplayFrame(62, 228, 352),
        new ReplayFrame(63, 231, 357),
        new ReplayFrame(64, 234, 362),
        new ReplayFrame(65, 237, 367),
        new ReplayFrame(66, 240, 372),
        new ReplayFrame(67, 243, 377),
        new ReplayFrame(68, 246, 382),
        new ReplayFrame(69, 249, 387),
        new ReplayFrame(70, 252, 392),
        new ReplayFrame(71, 255, 397),
        new ReplayFrame(72, 258, 402),
        new ReplayFrame(73, 261, 407),
        new ReplayFrame(74, 264, 412),
        new ReplayFrame(75, 267, 417),
        new ReplayFrame(76, 270, 422),
        new ReplayFrame(77, 273, 427),
        new ReplayFrame(78, 276, 432),
        new ReplayFrame(79, 279, 437)
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
