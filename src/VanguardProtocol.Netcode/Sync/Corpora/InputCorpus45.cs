namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus45
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 45, 45),
        new ReplayFrame(1, 48, 50),
        new ReplayFrame(2, 51, 55),
        new ReplayFrame(3, 54, 60),
        new ReplayFrame(4, 57, 65),
        new ReplayFrame(5, 60, 70),
        new ReplayFrame(6, 63, 75),
        new ReplayFrame(7, 66, 80),
        new ReplayFrame(8, 69, 85),
        new ReplayFrame(9, 72, 90),
        new ReplayFrame(10, 75, 95),
        new ReplayFrame(11, 78, 100),
        new ReplayFrame(12, 81, 105),
        new ReplayFrame(13, 84, 110),
        new ReplayFrame(14, 87, 115),
        new ReplayFrame(15, 90, 120),
        new ReplayFrame(16, 93, 125),
        new ReplayFrame(17, 96, 130),
        new ReplayFrame(18, 99, 135),
        new ReplayFrame(19, 102, 140),
        new ReplayFrame(20, 105, 145),
        new ReplayFrame(21, 108, 150),
        new ReplayFrame(22, 111, 155),
        new ReplayFrame(23, 114, 160),
        new ReplayFrame(24, 117, 165),
        new ReplayFrame(25, 120, 170),
        new ReplayFrame(26, 123, 175),
        new ReplayFrame(27, 126, 180),
        new ReplayFrame(28, 129, 185),
        new ReplayFrame(29, 132, 190),
        new ReplayFrame(30, 135, 195),
        new ReplayFrame(31, 138, 200),
        new ReplayFrame(32, 141, 205),
        new ReplayFrame(33, 144, 210),
        new ReplayFrame(34, 147, 215),
        new ReplayFrame(35, 150, 220),
        new ReplayFrame(36, 153, 225),
        new ReplayFrame(37, 156, 230),
        new ReplayFrame(38, 159, 235),
        new ReplayFrame(39, 162, 240),
        new ReplayFrame(40, 165, 245),
        new ReplayFrame(41, 168, 250),
        new ReplayFrame(42, 171, 255),
        new ReplayFrame(43, 174, 260),
        new ReplayFrame(44, 177, 265),
        new ReplayFrame(45, 180, 270),
        new ReplayFrame(46, 183, 275),
        new ReplayFrame(47, 186, 280),
        new ReplayFrame(48, 189, 285),
        new ReplayFrame(49, 192, 290),
        new ReplayFrame(50, 195, 295),
        new ReplayFrame(51, 198, 300),
        new ReplayFrame(52, 201, 305),
        new ReplayFrame(53, 204, 310),
        new ReplayFrame(54, 207, 315),
        new ReplayFrame(55, 210, 320),
        new ReplayFrame(56, 213, 325),
        new ReplayFrame(57, 216, 330),
        new ReplayFrame(58, 219, 335),
        new ReplayFrame(59, 222, 340),
        new ReplayFrame(60, 225, 345),
        new ReplayFrame(61, 228, 350),
        new ReplayFrame(62, 231, 355),
        new ReplayFrame(63, 234, 360),
        new ReplayFrame(64, 237, 365),
        new ReplayFrame(65, 240, 370),
        new ReplayFrame(66, 243, 375),
        new ReplayFrame(67, 246, 380),
        new ReplayFrame(68, 249, 385),
        new ReplayFrame(69, 252, 390),
        new ReplayFrame(70, 255, 395),
        new ReplayFrame(71, 258, 400),
        new ReplayFrame(72, 261, 405),
        new ReplayFrame(73, 264, 410),
        new ReplayFrame(74, 267, 415),
        new ReplayFrame(75, 270, 420),
        new ReplayFrame(76, 273, 425),
        new ReplayFrame(77, 276, 430),
        new ReplayFrame(78, 279, 435),
        new ReplayFrame(79, 282, 440)
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
