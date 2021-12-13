namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus30
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 30, 30),
        new ReplayFrame(1, 33, 35),
        new ReplayFrame(2, 36, 40),
        new ReplayFrame(3, 39, 45),
        new ReplayFrame(4, 42, 50),
        new ReplayFrame(5, 45, 55),
        new ReplayFrame(6, 48, 60),
        new ReplayFrame(7, 51, 65),
        new ReplayFrame(8, 54, 70),
        new ReplayFrame(9, 57, 75),
        new ReplayFrame(10, 60, 80),
        new ReplayFrame(11, 63, 85),
        new ReplayFrame(12, 66, 90),
        new ReplayFrame(13, 69, 95),
        new ReplayFrame(14, 72, 100),
        new ReplayFrame(15, 75, 105),
        new ReplayFrame(16, 78, 110),
        new ReplayFrame(17, 81, 115),
        new ReplayFrame(18, 84, 120),
        new ReplayFrame(19, 87, 125),
        new ReplayFrame(20, 90, 130),
        new ReplayFrame(21, 93, 135),
        new ReplayFrame(22, 96, 140),
        new ReplayFrame(23, 99, 145),
        new ReplayFrame(24, 102, 150),
        new ReplayFrame(25, 105, 155),
        new ReplayFrame(26, 108, 160),
        new ReplayFrame(27, 111, 165),
        new ReplayFrame(28, 114, 170),
        new ReplayFrame(29, 117, 175),
        new ReplayFrame(30, 120, 180),
        new ReplayFrame(31, 123, 185),
        new ReplayFrame(32, 126, 190),
        new ReplayFrame(33, 129, 195),
        new ReplayFrame(34, 132, 200),
        new ReplayFrame(35, 135, 205),
        new ReplayFrame(36, 138, 210),
        new ReplayFrame(37, 141, 215),
        new ReplayFrame(38, 144, 220),
        new ReplayFrame(39, 147, 225),
        new ReplayFrame(40, 150, 230),
        new ReplayFrame(41, 153, 235),
        new ReplayFrame(42, 156, 240),
        new ReplayFrame(43, 159, 245),
        new ReplayFrame(44, 162, 250),
        new ReplayFrame(45, 165, 255),
        new ReplayFrame(46, 168, 260),
        new ReplayFrame(47, 171, 265),
        new ReplayFrame(48, 174, 270),
        new ReplayFrame(49, 177, 275),
        new ReplayFrame(50, 180, 280),
        new ReplayFrame(51, 183, 285),
        new ReplayFrame(52, 186, 290),
        new ReplayFrame(53, 189, 295),
        new ReplayFrame(54, 192, 300),
        new ReplayFrame(55, 195, 305),
        new ReplayFrame(56, 198, 310),
        new ReplayFrame(57, 201, 315),
        new ReplayFrame(58, 204, 320),
        new ReplayFrame(59, 207, 325),
        new ReplayFrame(60, 210, 330),
        new ReplayFrame(61, 213, 335),
        new ReplayFrame(62, 216, 340),
        new ReplayFrame(63, 219, 345),
        new ReplayFrame(64, 222, 350),
        new ReplayFrame(65, 225, 355),
        new ReplayFrame(66, 228, 360),
        new ReplayFrame(67, 231, 365),
        new ReplayFrame(68, 234, 370),
        new ReplayFrame(69, 237, 375),
        new ReplayFrame(70, 240, 380),
        new ReplayFrame(71, 243, 385),
        new ReplayFrame(72, 246, 390),
        new ReplayFrame(73, 249, 395),
        new ReplayFrame(74, 252, 400),
        new ReplayFrame(75, 255, 405),
        new ReplayFrame(76, 258, 410),
        new ReplayFrame(77, 261, 415),
        new ReplayFrame(78, 264, 420),
        new ReplayFrame(79, 267, 425)
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
