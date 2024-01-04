using SymbolEngine;
public class Snowflake : SymbolObject
{
    public Snowflake(int x, int y)
    {
        Position = new Point {X = x, Y = y};
        Texture = new SymbolTexture("*", ConsoleColor.DarkBlue, (0,0));
    }

    public override async Task<WaitFor> Update()
    {
        return null;
    }
}