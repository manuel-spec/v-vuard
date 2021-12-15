using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VanguardProtocol.Game;

/// <summary>Tiny 3x5 bitmap font for HUD/menus without Content Pipeline fonts.</summary>
public static class TinyFont
{
    private static readonly Dictionary<char, byte[]> Glyphs = Build();

    public static void Draw(SpriteBatch batch, Texture2D pixel, string text, int x, int y, Color color, int scale = 2)
    {
        var cx = x;
        foreach (var ch in text.ToUpperInvariant())
        {
            if (ch == ' ')
            {
                cx += 4 * scale;
                continue;
            }

            if (!Glyphs.TryGetValue(ch, out var rows))
            {
                cx += 4 * scale;
                continue;
            }

            for (var row = 0; row < 5; row++)
            {
                var bits = rows[row];
                for (var col = 0; col < 3; col++)
                {
                    if ((bits & (1 << (2 - col))) == 0)
                        continue;
                    batch.Draw(pixel, new Rectangle(cx + col * scale, y + row * scale, scale, scale), color);
                }
            }

            cx += 4 * scale;
        }
    }

    public static int MeasureWidth(string text, int scale = 2) =>
        text.Length * 4 * scale;

    private static Dictionary<char, byte[]> Build()
    {
        // Each glyph: 5 rows, 3-bit columns (MSB = left).
        var map = new Dictionary<char, byte[]>();
        void G(char c, params byte[] rows) => map[c] = rows;

        G('0', 0b111, 0b101, 0b101, 0b101, 0b111);
        G('1', 0b010, 0b110, 0b010, 0b010, 0b111);
        G('2', 0b111, 0b001, 0b111, 0b100, 0b111);
        G('3', 0b111, 0b001, 0b111, 0b001, 0b111);
        G('4', 0b101, 0b101, 0b111, 0b001, 0b001);
        G('5', 0b111, 0b100, 0b111, 0b001, 0b111);
        G('6', 0b111, 0b100, 0b111, 0b101, 0b111);
        G('7', 0b111, 0b001, 0b010, 0b010, 0b010);
        G('8', 0b111, 0b101, 0b111, 0b101, 0b111);
        G('9', 0b111, 0b101, 0b111, 0b001, 0b111);
        G('A', 0b010, 0b101, 0b111, 0b101, 0b101);
        G('B', 0b110, 0b101, 0b110, 0b101, 0b110);
        G('C', 0b011, 0b100, 0b100, 0b100, 0b011);
        G('D', 0b110, 0b101, 0b101, 0b101, 0b110);
        G('E', 0b111, 0b100, 0b110, 0b100, 0b111);
        G('F', 0b111, 0b100, 0b110, 0b100, 0b100);
        G('G', 0b011, 0b100, 0b101, 0b101, 0b011);
        G('H', 0b101, 0b101, 0b111, 0b101, 0b101);
        G('I', 0b111, 0b010, 0b010, 0b010, 0b111);
        G('J', 0b001, 0b001, 0b001, 0b101, 0b010);
        G('K', 0b101, 0b101, 0b110, 0b101, 0b101);
        G('L', 0b100, 0b100, 0b100, 0b100, 0b111);
        G('M', 0b101, 0b111, 0b111, 0b101, 0b101);
        G('N', 0b101, 0b111, 0b111, 0b111, 0b101);
        G('O', 0b010, 0b101, 0b101, 0b101, 0b010);
        G('P', 0b110, 0b101, 0b110, 0b100, 0b100);
        G('Q', 0b010, 0b101, 0b101, 0b111, 0b001);
        G('R', 0b110, 0b101, 0b110, 0b101, 0b101);
        G('S', 0b011, 0b100, 0b010, 0b001, 0b110);
        G('T', 0b111, 0b010, 0b010, 0b010, 0b010);
        G('U', 0b101, 0b101, 0b101, 0b101, 0b111);
        G('V', 0b101, 0b101, 0b101, 0b101, 0b010);
        G('W', 0b101, 0b101, 0b111, 0b111, 0b101);
        G('X', 0b101, 0b101, 0b010, 0b101, 0b101);
        G('Y', 0b101, 0b101, 0b010, 0b010, 0b010);
        G('Z', 0b111, 0b001, 0b010, 0b100, 0b111);
        G('-', 0b000, 0b000, 0b111, 0b000, 0b000);
        G(':', 0b000, 0b010, 0b000, 0b010, 0b000);
        G('!', 0b010, 0b010, 0b010, 0b000, 0b010);
        G('/', 0b001, 0b001, 0b010, 0b100, 0b100);
        G('.', 0b000, 0b000, 0b000, 0b000, 0b010);
        return map;
    }
}
