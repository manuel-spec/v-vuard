namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus27
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 27, 27),
        new ReplayFrame(1, 30, 32),
        new ReplayFrame(2, 33, 37),
        new ReplayFrame(3, 36, 42),
        new ReplayFrame(4, 39, 47),
        new ReplayFrame(5, 42, 52),
        new ReplayFrame(6, 45, 57),
        new ReplayFrame(7, 48, 62),
        new ReplayFrame(8, 51, 67),
        new ReplayFrame(9, 54, 72),
        new ReplayFrame(10, 57, 77),
        new ReplayFrame(11, 60, 82),
        new ReplayFrame(12, 63, 87),
        new ReplayFrame(13, 66, 92),
        new ReplayFrame(14, 69, 97),
        new ReplayFrame(15, 72, 102),
        new ReplayFrame(16, 75, 107),
        new ReplayFrame(17, 78, 112),
        new ReplayFrame(18, 81, 117),
        new ReplayFrame(19, 84, 122),
        new ReplayFrame(20, 87, 127),
        new ReplayFrame(21, 90, 132),
        new ReplayFrame(22, 93, 137),
        new ReplayFrame(23, 96, 142),
        new ReplayFrame(24, 99, 147),
        new ReplayFrame(25, 102, 152),
        new ReplayFrame(26, 105, 157),
        new ReplayFrame(27, 108, 162),
        new ReplayFrame(28, 111, 167),
        new ReplayFrame(29, 114, 172),
        new ReplayFrame(30, 117, 177),
        new ReplayFrame(31, 120, 182),
        new ReplayFrame(32, 123, 187),
        new ReplayFrame(33, 126, 192),
        new ReplayFrame(34, 129, 197),
        new ReplayFrame(35, 132, 202),
        new ReplayFrame(36, 135, 207),
        new ReplayFrame(37, 138, 212),
        new ReplayFrame(38, 141, 217),
        new ReplayFrame(39, 144, 222),
        new ReplayFrame(40, 147, 227),
        new ReplayFrame(41, 150, 232),
        new ReplayFrame(42, 153, 237),
        new ReplayFrame(43, 156, 242),
        new ReplayFrame(44, 159, 247),
        new ReplayFrame(45, 162, 252),
        new ReplayFrame(46, 165, 257),
        new ReplayFrame(47, 168, 262),
        new ReplayFrame(48, 171, 267),
        new ReplayFrame(49, 174, 272),
        new ReplayFrame(50, 177, 277),
        new ReplayFrame(51, 180, 282),
        new ReplayFrame(52, 183, 287),
        new ReplayFrame(53, 186, 292),
        new ReplayFrame(54, 189, 297),
        new ReplayFrame(55, 192, 302),
        new ReplayFrame(56, 195, 307),
        new ReplayFrame(57, 198, 312),
        new ReplayFrame(58, 201, 317),
        new ReplayFrame(59, 204, 322),
        new ReplayFrame(60, 207, 327),
        new ReplayFrame(61, 210, 332),
        new ReplayFrame(62, 213, 337),
        new ReplayFrame(63, 216, 342),
        new ReplayFrame(64, 219, 347),
        new ReplayFrame(65, 222, 352),
        new ReplayFrame(66, 225, 357),
        new ReplayFrame(67, 228, 362),
        new ReplayFrame(68, 231, 367),
        new ReplayFrame(69, 234, 372),
        new ReplayFrame(70, 237, 377),
        new ReplayFrame(71, 240, 382),
        new ReplayFrame(72, 243, 387),
        new ReplayFrame(73, 246, 392),
        new ReplayFrame(74, 249, 397),
        new ReplayFrame(75, 252, 402),
        new ReplayFrame(76, 255, 407),
        new ReplayFrame(77, 258, 412),
        new ReplayFrame(78, 261, 417),
        new ReplayFrame(79, 264, 422)
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
