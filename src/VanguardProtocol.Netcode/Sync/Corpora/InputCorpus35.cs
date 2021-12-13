namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus35
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 35, 35),
        new ReplayFrame(1, 38, 40),
        new ReplayFrame(2, 41, 45),
        new ReplayFrame(3, 44, 50),
        new ReplayFrame(4, 47, 55),
        new ReplayFrame(5, 50, 60),
        new ReplayFrame(6, 53, 65),
        new ReplayFrame(7, 56, 70),
        new ReplayFrame(8, 59, 75),
        new ReplayFrame(9, 62, 80),
        new ReplayFrame(10, 65, 85),
        new ReplayFrame(11, 68, 90),
        new ReplayFrame(12, 71, 95),
        new ReplayFrame(13, 74, 100),
        new ReplayFrame(14, 77, 105),
        new ReplayFrame(15, 80, 110),
        new ReplayFrame(16, 83, 115),
        new ReplayFrame(17, 86, 120),
        new ReplayFrame(18, 89, 125),
        new ReplayFrame(19, 92, 130),
        new ReplayFrame(20, 95, 135),
        new ReplayFrame(21, 98, 140),
        new ReplayFrame(22, 101, 145),
        new ReplayFrame(23, 104, 150),
        new ReplayFrame(24, 107, 155),
        new ReplayFrame(25, 110, 160),
        new ReplayFrame(26, 113, 165),
        new ReplayFrame(27, 116, 170),
        new ReplayFrame(28, 119, 175),
        new ReplayFrame(29, 122, 180),
        new ReplayFrame(30, 125, 185),
        new ReplayFrame(31, 128, 190),
        new ReplayFrame(32, 131, 195),
        new ReplayFrame(33, 134, 200),
        new ReplayFrame(34, 137, 205),
        new ReplayFrame(35, 140, 210),
        new ReplayFrame(36, 143, 215),
        new ReplayFrame(37, 146, 220),
        new ReplayFrame(38, 149, 225),
        new ReplayFrame(39, 152, 230),
        new ReplayFrame(40, 155, 235),
        new ReplayFrame(41, 158, 240),
        new ReplayFrame(42, 161, 245),
        new ReplayFrame(43, 164, 250),
        new ReplayFrame(44, 167, 255),
        new ReplayFrame(45, 170, 260),
        new ReplayFrame(46, 173, 265),
        new ReplayFrame(47, 176, 270),
        new ReplayFrame(48, 179, 275),
        new ReplayFrame(49, 182, 280),
        new ReplayFrame(50, 185, 285),
        new ReplayFrame(51, 188, 290),
        new ReplayFrame(52, 191, 295),
        new ReplayFrame(53, 194, 300),
        new ReplayFrame(54, 197, 305),
        new ReplayFrame(55, 200, 310),
        new ReplayFrame(56, 203, 315),
        new ReplayFrame(57, 206, 320),
        new ReplayFrame(58, 209, 325),
        new ReplayFrame(59, 212, 330),
        new ReplayFrame(60, 215, 335),
        new ReplayFrame(61, 218, 340),
        new ReplayFrame(62, 221, 345),
        new ReplayFrame(63, 224, 350),
        new ReplayFrame(64, 227, 355),
        new ReplayFrame(65, 230, 360),
        new ReplayFrame(66, 233, 365),
        new ReplayFrame(67, 236, 370),
        new ReplayFrame(68, 239, 375),
        new ReplayFrame(69, 242, 380),
        new ReplayFrame(70, 245, 385),
        new ReplayFrame(71, 248, 390),
        new ReplayFrame(72, 251, 395),
        new ReplayFrame(73, 254, 400),
        new ReplayFrame(74, 257, 405),
        new ReplayFrame(75, 260, 410),
        new ReplayFrame(76, 263, 415),
        new ReplayFrame(77, 266, 420),
        new ReplayFrame(78, 269, 425),
        new ReplayFrame(79, 272, 430)
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
