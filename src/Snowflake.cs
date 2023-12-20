
namespace SymbolWinter;

public class Snowflake : SymbolObject
{
    public Snowflake(int x, int y)
    {
        Position = new Point {X = x, Y = y};
        Texture = new SymbolTexture("*", ConsoleColor.DarkBlue, (0,0));
    }
}