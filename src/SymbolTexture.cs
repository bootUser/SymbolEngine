namespace SymbolEngine;

public class SymbolTexture(string text, ConsoleColor color, Point pivot) : IDrawable
{
    public Point Pivot { get; init; } = pivot;
    public bool ShowTransparentPixels {get;set;}
    private Pixel _transparentPixel => ShowTransparentPixels ? new Pixel('#', ConsoleColor.White) : new Pixel();

    public Pixel[,] GetPixels()
    {
        var lines = text.Split('\n');
        var height = lines.Length;
        var width = lines.Select((line) => line.Length).Max();
        var result = new Pixel[width, height];

        for (int y = 0; y < height; y++)
        {
            var line = lines[y];
            int index;
            for(index = 0; index < line.Length && line[index] == ' '; index++);
            for (int x = 0; x < width; x++)
                    result[x, y] = x >= line.Length || x < index ? _transparentPixel : new Pixel(line[x], color);
        }

        return result;
    }
}