namespace SymbolEngine;

public struct Point(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public static implicit operator Point((int, int) tuple)
    {
        return new Point(tuple.Item1, tuple.Item2);
    }

    public static bool operator ==(Point p, (int, int) tuple) => p.X == tuple.Item1 && p.Y == tuple.Item2;
    public static bool operator ==((int, int) tuple, Point p) => p == tuple;
    public static bool operator !=((int, int) tuple, Point p) => p != tuple;
    public static bool operator !=(Point p, (int, int) tuple) => !(p == tuple);
}