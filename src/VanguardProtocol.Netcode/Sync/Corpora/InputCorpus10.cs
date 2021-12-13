namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus10
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 10, 10),
        new ReplayFrame(1, 13, 15),
        new ReplayFrame(2, 16, 20),
        new ReplayFrame(3, 19, 25),
        new ReplayFrame(4, 22, 30),
        new ReplayFrame(5, 25, 35),
        new ReplayFrame(6, 28, 40),
        new ReplayFrame(7, 31, 45),
        new ReplayFrame(8, 34, 50),
        new ReplayFrame(9, 37, 55),
        new ReplayFrame(10, 40, 60),
        new ReplayFrame(11, 43, 65),
        new ReplayFrame(12, 46, 70),
        new ReplayFrame(13, 49, 75),
        new ReplayFrame(14, 52, 80),
        new ReplayFrame(15, 55, 85),
        new ReplayFrame(16, 58, 90),
        new ReplayFrame(17, 61, 95),
        new ReplayFrame(18, 64, 100),
        new ReplayFrame(19, 67, 105),
        new ReplayFrame(20, 70, 110),
        new ReplayFrame(21, 73, 115),
        new ReplayFrame(22, 76, 120),
        new ReplayFrame(23, 79, 125),
        new ReplayFrame(24, 82, 130),
        new ReplayFrame(25, 85, 135),
        new ReplayFrame(26, 88, 140),
        new ReplayFrame(27, 91, 145),
        new ReplayFrame(28, 94, 150),
        new ReplayFrame(29, 97, 155),
        new ReplayFrame(30, 100, 160),
        new ReplayFrame(31, 103, 165),
        new ReplayFrame(32, 106, 170),
        new ReplayFrame(33, 109, 175),
        new ReplayFrame(34, 112, 180),
        new ReplayFrame(35, 115, 185),
        new ReplayFrame(36, 118, 190),
        new ReplayFrame(37, 121, 195),
        new ReplayFrame(38, 124, 200),
        new ReplayFrame(39, 127, 205),
        new ReplayFrame(40, 130, 210),
        new ReplayFrame(41, 133, 215),
        new ReplayFrame(42, 136, 220),
        new ReplayFrame(43, 139, 225),
        new ReplayFrame(44, 142, 230),
        new ReplayFrame(45, 145, 235),
        new ReplayFrame(46, 148, 240),
        new ReplayFrame(47, 151, 245),
        new ReplayFrame(48, 154, 250),
        new ReplayFrame(49, 157, 255),
        new ReplayFrame(50, 160, 260),
        new ReplayFrame(51, 163, 265),
        new ReplayFrame(52, 166, 270),
        new ReplayFrame(53, 169, 275),
        new ReplayFrame(54, 172, 280),
        new ReplayFrame(55, 175, 285),
        new ReplayFrame(56, 178, 290),
        new ReplayFrame(57, 181, 295),
        new ReplayFrame(58, 184, 300),
        new ReplayFrame(59, 187, 305),
        new ReplayFrame(60, 190, 310),
        new ReplayFrame(61, 193, 315),
        new ReplayFrame(62, 196, 320),
        new ReplayFrame(63, 199, 325),
        new ReplayFrame(64, 202, 330),
        new ReplayFrame(65, 205, 335),
        new ReplayFrame(66, 208, 340),
        new ReplayFrame(67, 211, 345),
        new ReplayFrame(68, 214, 350),
        new ReplayFrame(69, 217, 355),
        new ReplayFrame(70, 220, 360),
        new ReplayFrame(71, 223, 365),
        new ReplayFrame(72, 226, 370),
        new ReplayFrame(73, 229, 375),
        new ReplayFrame(74, 232, 380),
        new ReplayFrame(75, 235, 385),
        new ReplayFrame(76, 238, 390),
        new ReplayFrame(77, 241, 395),
        new ReplayFrame(78, 244, 400),
        new ReplayFrame(79, 247, 405)
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
