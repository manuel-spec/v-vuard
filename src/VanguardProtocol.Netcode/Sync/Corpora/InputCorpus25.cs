namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus25
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 25, 25),
        new ReplayFrame(1, 28, 30),
        new ReplayFrame(2, 31, 35),
        new ReplayFrame(3, 34, 40),
        new ReplayFrame(4, 37, 45),
        new ReplayFrame(5, 40, 50),
        new ReplayFrame(6, 43, 55),
        new ReplayFrame(7, 46, 60),
        new ReplayFrame(8, 49, 65),
        new ReplayFrame(9, 52, 70),
        new ReplayFrame(10, 55, 75),
        new ReplayFrame(11, 58, 80),
        new ReplayFrame(12, 61, 85),
        new ReplayFrame(13, 64, 90),
        new ReplayFrame(14, 67, 95),
        new ReplayFrame(15, 70, 100),
        new ReplayFrame(16, 73, 105),
        new ReplayFrame(17, 76, 110),
        new ReplayFrame(18, 79, 115),
        new ReplayFrame(19, 82, 120),
        new ReplayFrame(20, 85, 125),
        new ReplayFrame(21, 88, 130),
        new ReplayFrame(22, 91, 135),
        new ReplayFrame(23, 94, 140),
        new ReplayFrame(24, 97, 145),
        new ReplayFrame(25, 100, 150),
        new ReplayFrame(26, 103, 155),
        new ReplayFrame(27, 106, 160),
        new ReplayFrame(28, 109, 165),
        new ReplayFrame(29, 112, 170),
        new ReplayFrame(30, 115, 175),
        new ReplayFrame(31, 118, 180),
        new ReplayFrame(32, 121, 185),
        new ReplayFrame(33, 124, 190),
        new ReplayFrame(34, 127, 195),
        new ReplayFrame(35, 130, 200),
        new ReplayFrame(36, 133, 205),
        new ReplayFrame(37, 136, 210),
        new ReplayFrame(38, 139, 215),
        new ReplayFrame(39, 142, 220),
        new ReplayFrame(40, 145, 225),
        new ReplayFrame(41, 148, 230),
        new ReplayFrame(42, 151, 235),
        new ReplayFrame(43, 154, 240),
        new ReplayFrame(44, 157, 245),
        new ReplayFrame(45, 160, 250),
        new ReplayFrame(46, 163, 255),
        new ReplayFrame(47, 166, 260),
        new ReplayFrame(48, 169, 265),
        new ReplayFrame(49, 172, 270),
        new ReplayFrame(50, 175, 275),
        new ReplayFrame(51, 178, 280),
        new ReplayFrame(52, 181, 285),
        new ReplayFrame(53, 184, 290),
        new ReplayFrame(54, 187, 295),
        new ReplayFrame(55, 190, 300),
        new ReplayFrame(56, 193, 305),
        new ReplayFrame(57, 196, 310),
        new ReplayFrame(58, 199, 315),
        new ReplayFrame(59, 202, 320),
        new ReplayFrame(60, 205, 325),
        new ReplayFrame(61, 208, 330),
        new ReplayFrame(62, 211, 335),
        new ReplayFrame(63, 214, 340),
        new ReplayFrame(64, 217, 345),
        new ReplayFrame(65, 220, 350),
        new ReplayFrame(66, 223, 355),
        new ReplayFrame(67, 226, 360),
        new ReplayFrame(68, 229, 365),
        new ReplayFrame(69, 232, 370),
        new ReplayFrame(70, 235, 375),
        new ReplayFrame(71, 238, 380),
        new ReplayFrame(72, 241, 385),
        new ReplayFrame(73, 244, 390),
        new ReplayFrame(74, 247, 395),
        new ReplayFrame(75, 250, 400),
        new ReplayFrame(76, 253, 405),
        new ReplayFrame(77, 256, 410),
        new ReplayFrame(78, 259, 415),
        new ReplayFrame(79, 262, 420)
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
