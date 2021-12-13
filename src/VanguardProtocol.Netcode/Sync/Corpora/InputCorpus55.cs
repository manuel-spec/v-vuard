namespace VanguardProtocol.Netcode.Sync.Corpora;

public static class InputCorpus55
{
    public static readonly ReplayFrame[] Frames =
    [
        new ReplayFrame(0, 55, 55),
        new ReplayFrame(1, 58, 60),
        new ReplayFrame(2, 61, 65),
        new ReplayFrame(3, 64, 70),
        new ReplayFrame(4, 67, 75),
        new ReplayFrame(5, 70, 80),
        new ReplayFrame(6, 73, 85),
        new ReplayFrame(7, 76, 90),
        new ReplayFrame(8, 79, 95),
        new ReplayFrame(9, 82, 100),
        new ReplayFrame(10, 85, 105),
        new ReplayFrame(11, 88, 110),
        new ReplayFrame(12, 91, 115),
        new ReplayFrame(13, 94, 120),
        new ReplayFrame(14, 97, 125),
        new ReplayFrame(15, 100, 130),
        new ReplayFrame(16, 103, 135),
        new ReplayFrame(17, 106, 140),
        new ReplayFrame(18, 109, 145),
        new ReplayFrame(19, 112, 150),
        new ReplayFrame(20, 115, 155),
        new ReplayFrame(21, 118, 160),
        new ReplayFrame(22, 121, 165),
        new ReplayFrame(23, 124, 170),
        new ReplayFrame(24, 127, 175),
        new ReplayFrame(25, 130, 180),
        new ReplayFrame(26, 133, 185),
        new ReplayFrame(27, 136, 190),
        new ReplayFrame(28, 139, 195),
        new ReplayFrame(29, 142, 200),
        new ReplayFrame(30, 145, 205),
        new ReplayFrame(31, 148, 210),
        new ReplayFrame(32, 151, 215),
        new ReplayFrame(33, 154, 220),
        new ReplayFrame(34, 157, 225),
        new ReplayFrame(35, 160, 230),
        new ReplayFrame(36, 163, 235),
        new ReplayFrame(37, 166, 240),
        new ReplayFrame(38, 169, 245),
        new ReplayFrame(39, 172, 250),
        new ReplayFrame(40, 175, 255),
        new ReplayFrame(41, 178, 260),
        new ReplayFrame(42, 181, 265),
        new ReplayFrame(43, 184, 270),
        new ReplayFrame(44, 187, 275),
        new ReplayFrame(45, 190, 280),
        new ReplayFrame(46, 193, 285),
        new ReplayFrame(47, 196, 290),
        new ReplayFrame(48, 199, 295),
        new ReplayFrame(49, 202, 300),
        new ReplayFrame(50, 205, 305),
        new ReplayFrame(51, 208, 310),
        new ReplayFrame(52, 211, 315),
        new ReplayFrame(53, 214, 320),
        new ReplayFrame(54, 217, 325),
        new ReplayFrame(55, 220, 330),
        new ReplayFrame(56, 223, 335),
        new ReplayFrame(57, 226, 340),
        new ReplayFrame(58, 229, 345),
        new ReplayFrame(59, 232, 350),
        new ReplayFrame(60, 235, 355),
        new ReplayFrame(61, 238, 360),
        new ReplayFrame(62, 241, 365),
        new ReplayFrame(63, 244, 370),
        new ReplayFrame(64, 247, 375),
        new ReplayFrame(65, 250, 380),
        new ReplayFrame(66, 253, 385),
        new ReplayFrame(67, 256, 390),
        new ReplayFrame(68, 259, 395),
        new ReplayFrame(69, 262, 400),
        new ReplayFrame(70, 265, 405),
        new ReplayFrame(71, 268, 410),
        new ReplayFrame(72, 271, 415),
        new ReplayFrame(73, 274, 420),
        new ReplayFrame(74, 277, 425),
        new ReplayFrame(75, 280, 430),
        new ReplayFrame(76, 283, 435),
        new ReplayFrame(77, 286, 440),
        new ReplayFrame(78, 289, 445),
        new ReplayFrame(79, 292, 450)
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
