namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus60
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 60, 60),
        new ReplayFrame(1, 63, 65),
        new ReplayFrame(2, 66, 70),
        new ReplayFrame(3, 69, 75),
        new ReplayFrame(4, 72, 80),
        new ReplayFrame(5, 75, 85),
        new ReplayFrame(6, 78, 90),
        new ReplayFrame(7, 81, 95),
        new ReplayFrame(8, 84, 100),
        new ReplayFrame(9, 87, 105),
        new ReplayFrame(10, 90, 110),
        new ReplayFrame(11, 93, 115),
        new ReplayFrame(12, 96, 120),
        new ReplayFrame(13, 99, 125),
        new ReplayFrame(14, 102, 130),
        new ReplayFrame(15, 105, 135),
        new ReplayFrame(16, 108, 140),
        new ReplayFrame(17, 111, 145),
        new ReplayFrame(18, 114, 150),
        new ReplayFrame(19, 117, 155),
        new ReplayFrame(20, 120, 160),
        new ReplayFrame(21, 123, 165),
        new ReplayFrame(22, 126, 170),
        new ReplayFrame(23, 129, 175),
        new ReplayFrame(24, 132, 180),
        new ReplayFrame(25, 135, 185),
        new ReplayFrame(26, 138, 190),
        new ReplayFrame(27, 141, 195),
        new ReplayFrame(28, 144, 200),
        new ReplayFrame(29, 147, 205),
        new ReplayFrame(30, 150, 210),
        new ReplayFrame(31, 153, 215),
        new ReplayFrame(32, 156, 220),
        new ReplayFrame(33, 159, 225),
        new ReplayFrame(34, 162, 230),
        new ReplayFrame(35, 165, 235),
        new ReplayFrame(36, 168, 240),
        new ReplayFrame(37, 171, 245),
        new ReplayFrame(38, 174, 250),
        new ReplayFrame(39, 177, 255),
        new ReplayFrame(40, 180, 260),
        new ReplayFrame(41, 183, 265),
        new ReplayFrame(42, 186, 270),
        new ReplayFrame(43, 189, 275),
        new ReplayFrame(44, 192, 280),
        new ReplayFrame(45, 195, 285),
        new ReplayFrame(46, 198, 290),
        new ReplayFrame(47, 201, 295),
        new ReplayFrame(48, 204, 300),
        new ReplayFrame(49, 207, 305),
        new ReplayFrame(50, 210, 310),
        new ReplayFrame(51, 213, 315),
        new ReplayFrame(52, 216, 320),
        new ReplayFrame(53, 219, 325),
        new ReplayFrame(54, 222, 330),
        new ReplayFrame(55, 225, 335),
        new ReplayFrame(56, 228, 340),
        new ReplayFrame(57, 231, 345),
        new ReplayFrame(58, 234, 350),
        new ReplayFrame(59, 237, 355),
        new ReplayFrame(60, 240, 360),
        new ReplayFrame(61, 243, 365),
        new ReplayFrame(62, 246, 370),
        new ReplayFrame(63, 249, 375),
        new ReplayFrame(64, 252, 380),
        new ReplayFrame(65, 255, 385),
        new ReplayFrame(66, 258, 390),
        new ReplayFrame(67, 261, 395),
        new ReplayFrame(68, 264, 400),
        new ReplayFrame(69, 267, 405),
        new ReplayFrame(70, 270, 410),
        new ReplayFrame(71, 273, 415),
        new ReplayFrame(72, 276, 420),
        new ReplayFrame(73, 279, 425),
        new ReplayFrame(74, 282, 430),
        new ReplayFrame(75, 285, 435),
        new ReplayFrame(76, 288, 440),
        new ReplayFrame(77, 291, 445),
        new ReplayFrame(78, 294, 450),
        new ReplayFrame(79, 297, 455)
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
