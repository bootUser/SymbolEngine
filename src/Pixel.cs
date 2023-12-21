using System.Data.SqlTypes;

namespace SymbolEngine;

public record Pixel(char Symbol, ConsoleColor Color)
{
    public Pixel() : this(' ', ConsoleColor.White)
    {
    }

    public static implicit operator Pixel((char, ConsoleColor) tuple)
    {
        return new Pixel(tuple.Item1, tuple.Item2);
    }
}