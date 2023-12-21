namespace SymbolEngine;

public struct Point(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public static implicit operator Point((int, int) tuple)
    {
        return new Point(tuple.Item1, tuple.Item2);
    }
}