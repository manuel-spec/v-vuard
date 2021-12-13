namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus57
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 57, 57),
        new ReplayFrame(1, 60, 62),
        new ReplayFrame(2, 63, 67),
        new ReplayFrame(3, 66, 72),
        new ReplayFrame(4, 69, 77),
        new ReplayFrame(5, 72, 82),
        new ReplayFrame(6, 75, 87),
        new ReplayFrame(7, 78, 92),
        new ReplayFrame(8, 81, 97),
        new ReplayFrame(9, 84, 102),
        new ReplayFrame(10, 87, 107),
        new ReplayFrame(11, 90, 112),
        new ReplayFrame(12, 93, 117),
        new ReplayFrame(13, 96, 122),
        new ReplayFrame(14, 99, 127),
        new ReplayFrame(15, 102, 132),
        new ReplayFrame(16, 105, 137),
        new ReplayFrame(17, 108, 142),
        new ReplayFrame(18, 111, 147),
        new ReplayFrame(19, 114, 152),
        new ReplayFrame(20, 117, 157),
        new ReplayFrame(21, 120, 162),
        new ReplayFrame(22, 123, 167),
        new ReplayFrame(23, 126, 172),
        new ReplayFrame(24, 129, 177),
        new ReplayFrame(25, 132, 182),
        new ReplayFrame(26, 135, 187),
        new ReplayFrame(27, 138, 192),
        new ReplayFrame(28, 141, 197),
        new ReplayFrame(29, 144, 202),
        new ReplayFrame(30, 147, 207),
        new ReplayFrame(31, 150, 212),
        new ReplayFrame(32, 153, 217),
        new ReplayFrame(33, 156, 222),
        new ReplayFrame(34, 159, 227),
        new ReplayFrame(35, 162, 232),
        new ReplayFrame(36, 165, 237),
        new ReplayFrame(37, 168, 242),
        new ReplayFrame(38, 171, 247),
        new ReplayFrame(39, 174, 252),
        new ReplayFrame(40, 177, 257),
        new ReplayFrame(41, 180, 262),
        new ReplayFrame(42, 183, 267),
        new ReplayFrame(43, 186, 272),
        new ReplayFrame(44, 189, 277),
        new ReplayFrame(45, 192, 282),
        new ReplayFrame(46, 195, 287),
        new ReplayFrame(47, 198, 292),
        new ReplayFrame(48, 201, 297),
        new ReplayFrame(49, 204, 302),
        new ReplayFrame(50, 207, 307),
        new ReplayFrame(51, 210, 312),
        new ReplayFrame(52, 213, 317),
        new ReplayFrame(53, 216, 322),
        new ReplayFrame(54, 219, 327),
        new ReplayFrame(55, 222, 332),
        new ReplayFrame(56, 225, 337),
        new ReplayFrame(57, 228, 342),
        new ReplayFrame(58, 231, 347),
        new ReplayFrame(59, 234, 352),
        new ReplayFrame(60, 237, 357),
        new ReplayFrame(61, 240, 362),
        new ReplayFrame(62, 243, 367),
        new ReplayFrame(63, 246, 372),
        new ReplayFrame(64, 249, 377),
        new ReplayFrame(65, 252, 382),
        new ReplayFrame(66, 255, 387),
        new ReplayFrame(67, 258, 392),
        new ReplayFrame(68, 261, 397),
        new ReplayFrame(69, 264, 402),
        new ReplayFrame(70, 267, 407),
        new ReplayFrame(71, 270, 412),
        new ReplayFrame(72, 273, 417),
        new ReplayFrame(73, 276, 422),
        new ReplayFrame(74, 279, 427),
        new ReplayFrame(75, 282, 432),
        new ReplayFrame(76, 285, 437),
        new ReplayFrame(77, 288, 442),
        new ReplayFrame(78, 291, 447),
        new ReplayFrame(79, 294, 452)
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
