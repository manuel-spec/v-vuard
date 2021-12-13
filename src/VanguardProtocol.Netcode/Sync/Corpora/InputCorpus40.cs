namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus40
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 40, 40),
        new ReplayFrame(1, 43, 45),
        new ReplayFrame(2, 46, 50),
        new ReplayFrame(3, 49, 55),
        new ReplayFrame(4, 52, 60),
        new ReplayFrame(5, 55, 65),
        new ReplayFrame(6, 58, 70),
        new ReplayFrame(7, 61, 75),
        new ReplayFrame(8, 64, 80),
        new ReplayFrame(9, 67, 85),
        new ReplayFrame(10, 70, 90),
        new ReplayFrame(11, 73, 95),
        new ReplayFrame(12, 76, 100),
        new ReplayFrame(13, 79, 105),
        new ReplayFrame(14, 82, 110),
        new ReplayFrame(15, 85, 115),
        new ReplayFrame(16, 88, 120),
        new ReplayFrame(17, 91, 125),
        new ReplayFrame(18, 94, 130),
        new ReplayFrame(19, 97, 135),
        new ReplayFrame(20, 100, 140),
        new ReplayFrame(21, 103, 145),
        new ReplayFrame(22, 106, 150),
        new ReplayFrame(23, 109, 155),
        new ReplayFrame(24, 112, 160),
        new ReplayFrame(25, 115, 165),
        new ReplayFrame(26, 118, 170),
        new ReplayFrame(27, 121, 175),
        new ReplayFrame(28, 124, 180),
        new ReplayFrame(29, 127, 185),
        new ReplayFrame(30, 130, 190),
        new ReplayFrame(31, 133, 195),
        new ReplayFrame(32, 136, 200),
        new ReplayFrame(33, 139, 205),
        new ReplayFrame(34, 142, 210),
        new ReplayFrame(35, 145, 215),
        new ReplayFrame(36, 148, 220),
        new ReplayFrame(37, 151, 225),
        new ReplayFrame(38, 154, 230),
        new ReplayFrame(39, 157, 235),
        new ReplayFrame(40, 160, 240),
        new ReplayFrame(41, 163, 245),
        new ReplayFrame(42, 166, 250),
        new ReplayFrame(43, 169, 255),
        new ReplayFrame(44, 172, 260),
        new ReplayFrame(45, 175, 265),
        new ReplayFrame(46, 178, 270),
        new ReplayFrame(47, 181, 275),
        new ReplayFrame(48, 184, 280),
        new ReplayFrame(49, 187, 285),
        new ReplayFrame(50, 190, 290),
        new ReplayFrame(51, 193, 295),
        new ReplayFrame(52, 196, 300),
        new ReplayFrame(53, 199, 305),
        new ReplayFrame(54, 202, 310),
        new ReplayFrame(55, 205, 315),
        new ReplayFrame(56, 208, 320),
        new ReplayFrame(57, 211, 325),
        new ReplayFrame(58, 214, 330),
        new ReplayFrame(59, 217, 335),
        new ReplayFrame(60, 220, 340),
        new ReplayFrame(61, 223, 345),
        new ReplayFrame(62, 226, 350),
        new ReplayFrame(63, 229, 355),
        new ReplayFrame(64, 232, 360),
        new ReplayFrame(65, 235, 365),
        new ReplayFrame(66, 238, 370),
        new ReplayFrame(67, 241, 375),
        new ReplayFrame(68, 244, 380),
        new ReplayFrame(69, 247, 385),
        new ReplayFrame(70, 250, 390),
        new ReplayFrame(71, 253, 395),
        new ReplayFrame(72, 256, 400),
        new ReplayFrame(73, 259, 405),
        new ReplayFrame(74, 262, 410),
        new ReplayFrame(75, 265, 415),
        new ReplayFrame(76, 268, 420),
        new ReplayFrame(77, 271, 425),
        new ReplayFrame(78, 274, 430),
        new ReplayFrame(79, 277, 435)
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
