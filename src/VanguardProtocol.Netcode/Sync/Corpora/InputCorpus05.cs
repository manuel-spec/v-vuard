namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus05
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 5, 5),
        new ReplayFrame(1, 8, 10),
        new ReplayFrame(2, 11, 15),
        new ReplayFrame(3, 14, 20),
        new ReplayFrame(4, 17, 25),
        new ReplayFrame(5, 20, 30),
        new ReplayFrame(6, 23, 35),
        new ReplayFrame(7, 26, 40),
        new ReplayFrame(8, 29, 45),
        new ReplayFrame(9, 32, 50),
        new ReplayFrame(10, 35, 55),
        new ReplayFrame(11, 38, 60),
        new ReplayFrame(12, 41, 65),
        new ReplayFrame(13, 44, 70),
        new ReplayFrame(14, 47, 75),
        new ReplayFrame(15, 50, 80),
        new ReplayFrame(16, 53, 85),
        new ReplayFrame(17, 56, 90),
        new ReplayFrame(18, 59, 95),
        new ReplayFrame(19, 62, 100),
        new ReplayFrame(20, 65, 105),
        new ReplayFrame(21, 68, 110),
        new ReplayFrame(22, 71, 115),
        new ReplayFrame(23, 74, 120),
        new ReplayFrame(24, 77, 125),
        new ReplayFrame(25, 80, 130),
        new ReplayFrame(26, 83, 135),
        new ReplayFrame(27, 86, 140),
        new ReplayFrame(28, 89, 145),
        new ReplayFrame(29, 92, 150),
        new ReplayFrame(30, 95, 155),
        new ReplayFrame(31, 98, 160),
        new ReplayFrame(32, 101, 165),
        new ReplayFrame(33, 104, 170),
        new ReplayFrame(34, 107, 175),
        new ReplayFrame(35, 110, 180),
        new ReplayFrame(36, 113, 185),
        new ReplayFrame(37, 116, 190),
        new ReplayFrame(38, 119, 195),
        new ReplayFrame(39, 122, 200),
        new ReplayFrame(40, 125, 205),
        new ReplayFrame(41, 128, 210),
        new ReplayFrame(42, 131, 215),
        new ReplayFrame(43, 134, 220),
        new ReplayFrame(44, 137, 225),
        new ReplayFrame(45, 140, 230),
        new ReplayFrame(46, 143, 235),
        new ReplayFrame(47, 146, 240),
        new ReplayFrame(48, 149, 245),
        new ReplayFrame(49, 152, 250),
        new ReplayFrame(50, 155, 255),
        new ReplayFrame(51, 158, 260),
        new ReplayFrame(52, 161, 265),
        new ReplayFrame(53, 164, 270),
        new ReplayFrame(54, 167, 275),
        new ReplayFrame(55, 170, 280),
        new ReplayFrame(56, 173, 285),
        new ReplayFrame(57, 176, 290),
        new ReplayFrame(58, 179, 295),
        new ReplayFrame(59, 182, 300),
        new ReplayFrame(60, 185, 305),
        new ReplayFrame(61, 188, 310),
        new ReplayFrame(62, 191, 315),
        new ReplayFrame(63, 194, 320),
        new ReplayFrame(64, 197, 325),
        new ReplayFrame(65, 200, 330),
        new ReplayFrame(66, 203, 335),
        new ReplayFrame(67, 206, 340),
        new ReplayFrame(68, 209, 345),
        new ReplayFrame(69, 212, 350),
        new ReplayFrame(70, 215, 355),
        new ReplayFrame(71, 218, 360),
        new ReplayFrame(72, 221, 365),
        new ReplayFrame(73, 224, 370),
        new ReplayFrame(74, 227, 375),
        new ReplayFrame(75, 230, 380),
        new ReplayFrame(76, 233, 385),
        new ReplayFrame(77, 236, 390),
        new ReplayFrame(78, 239, 395),
        new ReplayFrame(79, 242, 400)
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
