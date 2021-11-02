using System;

namespace VanguardProtocol.Game;

public static class Program
{
    [STAThread]
    public static void Main()
    {
        using var game = new VanguardGame();
        game.Run();
    }
}
