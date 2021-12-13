namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus50
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 50, 50),
        new ReplayFrame(1, 53, 55),
        new ReplayFrame(2, 56, 60),
        new ReplayFrame(3, 59, 65),
        new ReplayFrame(4, 62, 70),
        new ReplayFrame(5, 65, 75),
        new ReplayFrame(6, 68, 80),
        new ReplayFrame(7, 71, 85),
        new ReplayFrame(8, 74, 90),
        new ReplayFrame(9, 77, 95),
        new ReplayFrame(10, 80, 100),
        new ReplayFrame(11, 83, 105),
        new ReplayFrame(12, 86, 110),
        new ReplayFrame(13, 89, 115),
        new ReplayFrame(14, 92, 120),
        new ReplayFrame(15, 95, 125),
        new ReplayFrame(16, 98, 130),
        new ReplayFrame(17, 101, 135),
        new ReplayFrame(18, 104, 140),
        new ReplayFrame(19, 107, 145),
        new ReplayFrame(20, 110, 150),
        new ReplayFrame(21, 113, 155),
        new ReplayFrame(22, 116, 160),
        new ReplayFrame(23, 119, 165),
        new ReplayFrame(24, 122, 170),
        new ReplayFrame(25, 125, 175),
        new ReplayFrame(26, 128, 180),
        new ReplayFrame(27, 131, 185),
        new ReplayFrame(28, 134, 190),
        new ReplayFrame(29, 137, 195),
        new ReplayFrame(30, 140, 200),
        new ReplayFrame(31, 143, 205),
        new ReplayFrame(32, 146, 210),
        new ReplayFrame(33, 149, 215),
        new ReplayFrame(34, 152, 220),
        new ReplayFrame(35, 155, 225),
        new ReplayFrame(36, 158, 230),
        new ReplayFrame(37, 161, 235),
        new ReplayFrame(38, 164, 240),
        new ReplayFrame(39, 167, 245),
        new ReplayFrame(40, 170, 250),
        new ReplayFrame(41, 173, 255),
        new ReplayFrame(42, 176, 260),
        new ReplayFrame(43, 179, 265),
        new ReplayFrame(44, 182, 270),
        new ReplayFrame(45, 185, 275),
        new ReplayFrame(46, 188, 280),
        new ReplayFrame(47, 191, 285),
        new ReplayFrame(48, 194, 290),
        new ReplayFrame(49, 197, 295),
        new ReplayFrame(50, 200, 300),
        new ReplayFrame(51, 203, 305),
        new ReplayFrame(52, 206, 310),
        new ReplayFrame(53, 209, 315),
        new ReplayFrame(54, 212, 320),
        new ReplayFrame(55, 215, 325),
        new ReplayFrame(56, 218, 330),
        new ReplayFrame(57, 221, 335),
        new ReplayFrame(58, 224, 340),
        new ReplayFrame(59, 227, 345),
        new ReplayFrame(60, 230, 350),
        new ReplayFrame(61, 233, 355),
        new ReplayFrame(62, 236, 360),
        new ReplayFrame(63, 239, 365),
        new ReplayFrame(64, 242, 370),
        new ReplayFrame(65, 245, 375),
        new ReplayFrame(66, 248, 380),
        new ReplayFrame(67, 251, 385),
        new ReplayFrame(68, 254, 390),
        new ReplayFrame(69, 257, 395),
        new ReplayFrame(70, 260, 400),
        new ReplayFrame(71, 263, 405),
        new ReplayFrame(72, 266, 410),
        new ReplayFrame(73, 269, 415),
        new ReplayFrame(74, 272, 420),
        new ReplayFrame(75, 275, 425),
        new ReplayFrame(76, 278, 430),
        new ReplayFrame(77, 281, 435),
        new ReplayFrame(78, 284, 440),
        new ReplayFrame(79, 287, 445)
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
