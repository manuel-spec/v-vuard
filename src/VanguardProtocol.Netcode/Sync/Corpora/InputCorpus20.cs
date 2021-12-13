namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus20
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 20, 20),
        new ReplayFrame(1, 23, 25),
        new ReplayFrame(2, 26, 30),
        new ReplayFrame(3, 29, 35),
        new ReplayFrame(4, 32, 40),
        new ReplayFrame(5, 35, 45),
        new ReplayFrame(6, 38, 50),
        new ReplayFrame(7, 41, 55),
        new ReplayFrame(8, 44, 60),
        new ReplayFrame(9, 47, 65),
        new ReplayFrame(10, 50, 70),
        new ReplayFrame(11, 53, 75),
        new ReplayFrame(12, 56, 80),
        new ReplayFrame(13, 59, 85),
        new ReplayFrame(14, 62, 90),
        new ReplayFrame(15, 65, 95),
        new ReplayFrame(16, 68, 100),
        new ReplayFrame(17, 71, 105),
        new ReplayFrame(18, 74, 110),
        new ReplayFrame(19, 77, 115),
        new ReplayFrame(20, 80, 120),
        new ReplayFrame(21, 83, 125),
        new ReplayFrame(22, 86, 130),
        new ReplayFrame(23, 89, 135),
        new ReplayFrame(24, 92, 140),
        new ReplayFrame(25, 95, 145),
        new ReplayFrame(26, 98, 150),
        new ReplayFrame(27, 101, 155),
        new ReplayFrame(28, 104, 160),
        new ReplayFrame(29, 107, 165),
        new ReplayFrame(30, 110, 170),
        new ReplayFrame(31, 113, 175),
        new ReplayFrame(32, 116, 180),
        new ReplayFrame(33, 119, 185),
        new ReplayFrame(34, 122, 190),
        new ReplayFrame(35, 125, 195),
        new ReplayFrame(36, 128, 200),
        new ReplayFrame(37, 131, 205),
        new ReplayFrame(38, 134, 210),
        new ReplayFrame(39, 137, 215),
        new ReplayFrame(40, 140, 220),
        new ReplayFrame(41, 143, 225),
        new ReplayFrame(42, 146, 230),
        new ReplayFrame(43, 149, 235),
        new ReplayFrame(44, 152, 240),
        new ReplayFrame(45, 155, 245),
        new ReplayFrame(46, 158, 250),
        new ReplayFrame(47, 161, 255),
        new ReplayFrame(48, 164, 260),
        new ReplayFrame(49, 167, 265),
        new ReplayFrame(50, 170, 270),
        new ReplayFrame(51, 173, 275),
        new ReplayFrame(52, 176, 280),
        new ReplayFrame(53, 179, 285),
        new ReplayFrame(54, 182, 290),
        new ReplayFrame(55, 185, 295),
        new ReplayFrame(56, 188, 300),
        new ReplayFrame(57, 191, 305),
        new ReplayFrame(58, 194, 310),
        new ReplayFrame(59, 197, 315),
        new ReplayFrame(60, 200, 320),
        new ReplayFrame(61, 203, 325),
        new ReplayFrame(62, 206, 330),
        new ReplayFrame(63, 209, 335),
        new ReplayFrame(64, 212, 340),
        new ReplayFrame(65, 215, 345),
        new ReplayFrame(66, 218, 350),
        new ReplayFrame(67, 221, 355),
        new ReplayFrame(68, 224, 360),
        new ReplayFrame(69, 227, 365),
        new ReplayFrame(70, 230, 370),
        new ReplayFrame(71, 233, 375),
        new ReplayFrame(72, 236, 380),
        new ReplayFrame(73, 239, 385),
        new ReplayFrame(74, 242, 390),
        new ReplayFrame(75, 245, 395),
        new ReplayFrame(76, 248, 400),
        new ReplayFrame(77, 251, 405),
        new ReplayFrame(78, 254, 410),
        new ReplayFrame(79, 257, 415)
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
