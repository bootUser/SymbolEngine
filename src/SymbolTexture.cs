namespace SymbolEngine;

public class SymbolTexture(string text, ConsoleColor color, Point pivot) : IDrawable
{
    public Point Pivot { get; init; } = pivot;

    public Pixel[,] GetPixels()
    {
        var lines = text.Split('\n');
        var height = lines.Length;
        var width = lines.Select((line) => line.Length).Max();
        var result = new Pixel[width, height];

        for (int y = 0; y < height; y++)
        {
            var line = lines[y];
            var index = line.IndexOf(' ');
            for (int x = 0; x < width; x++)
            {
                if (x >= line.Length)
                    result[x, y] = new Pixel();
                else if (x < index)
                    result[x, y] = (line[x], color, true);
                else
                    result[x, y] = (line[x], color, false);
            }
        }


        return result;
    }
}