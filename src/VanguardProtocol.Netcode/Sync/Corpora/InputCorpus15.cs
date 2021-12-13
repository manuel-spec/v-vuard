namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus15
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 15, 15),
        new ReplayFrame(1, 18, 20),
        new ReplayFrame(2, 21, 25),
        new ReplayFrame(3, 24, 30),
        new ReplayFrame(4, 27, 35),
        new ReplayFrame(5, 30, 40),
        new ReplayFrame(6, 33, 45),
        new ReplayFrame(7, 36, 50),
        new ReplayFrame(8, 39, 55),
        new ReplayFrame(9, 42, 60),
        new ReplayFrame(10, 45, 65),
        new ReplayFrame(11, 48, 70),
        new ReplayFrame(12, 51, 75),
        new ReplayFrame(13, 54, 80),
        new ReplayFrame(14, 57, 85),
        new ReplayFrame(15, 60, 90),
        new ReplayFrame(16, 63, 95),
        new ReplayFrame(17, 66, 100),
        new ReplayFrame(18, 69, 105),
        new ReplayFrame(19, 72, 110),
        new ReplayFrame(20, 75, 115),
        new ReplayFrame(21, 78, 120),
        new ReplayFrame(22, 81, 125),
        new ReplayFrame(23, 84, 130),
        new ReplayFrame(24, 87, 135),
        new ReplayFrame(25, 90, 140),
        new ReplayFrame(26, 93, 145),
        new ReplayFrame(27, 96, 150),
        new ReplayFrame(28, 99, 155),
        new ReplayFrame(29, 102, 160),
        new ReplayFrame(30, 105, 165),
        new ReplayFrame(31, 108, 170),
        new ReplayFrame(32, 111, 175),
        new ReplayFrame(33, 114, 180),
        new ReplayFrame(34, 117, 185),
        new ReplayFrame(35, 120, 190),
        new ReplayFrame(36, 123, 195),
        new ReplayFrame(37, 126, 200),
        new ReplayFrame(38, 129, 205),
        new ReplayFrame(39, 132, 210),
        new ReplayFrame(40, 135, 215),
        new ReplayFrame(41, 138, 220),
        new ReplayFrame(42, 141, 225),
        new ReplayFrame(43, 144, 230),
        new ReplayFrame(44, 147, 235),
        new ReplayFrame(45, 150, 240),
        new ReplayFrame(46, 153, 245),
        new ReplayFrame(47, 156, 250),
        new ReplayFrame(48, 159, 255),
        new ReplayFrame(49, 162, 260),
        new ReplayFrame(50, 165, 265),
        new ReplayFrame(51, 168, 270),
        new ReplayFrame(52, 171, 275),
        new ReplayFrame(53, 174, 280),
        new ReplayFrame(54, 177, 285),
        new ReplayFrame(55, 180, 290),
        new ReplayFrame(56, 183, 295),
        new ReplayFrame(57, 186, 300),
        new ReplayFrame(58, 189, 305),
        new ReplayFrame(59, 192, 310),
        new ReplayFrame(60, 195, 315),
        new ReplayFrame(61, 198, 320),
        new ReplayFrame(62, 201, 325),
        new ReplayFrame(63, 204, 330),
        new ReplayFrame(64, 207, 335),
        new ReplayFrame(65, 210, 340),
        new ReplayFrame(66, 213, 345),
        new ReplayFrame(67, 216, 350),
        new ReplayFrame(68, 219, 355),
        new ReplayFrame(69, 222, 360),
        new ReplayFrame(70, 225, 365),
        new ReplayFrame(71, 228, 370),
        new ReplayFrame(72, 231, 375),
        new ReplayFrame(73, 234, 380),
        new ReplayFrame(74, 237, 385),
        new ReplayFrame(75, 240, 390),
        new ReplayFrame(76, 243, 395),
        new ReplayFrame(77, 246, 400),
        new ReplayFrame(78, 249, 405),
        new ReplayFrame(79, 252, 410)
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
