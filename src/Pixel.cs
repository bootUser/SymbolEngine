namespace SymbolEngine;

public record Pixel(char Symbol, ConsoleColor Color)
{
    public Pixel() : this('\0', default)
    {
    }
    public Pixel(char symbol) : this(symbol, default)
    {
    }

    public static implicit operator Pixel((char, ConsoleColor) tuple) => new Pixel(tuple.Item1, tuple.Item2);
}