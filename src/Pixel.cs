namespace SymbolEngine;

public record Pixel(char Symbol, ConsoleColor Color, bool Transparent)
{
    public Pixel() : this(' ', ConsoleColor.White, true)
    {
    }

    public static implicit operator Pixel((char, ConsoleColor, bool) tuple)
    {
        return new Pixel(tuple.Item1, tuple.Item2, tuple.Item3);
    }
}