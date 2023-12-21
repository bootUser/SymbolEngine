namespace SymbolEngine;

public class SymbolTexture(string text, ConsoleColor color, Point pivot) : IDrawable
{
    public Point Pivot { get; init; } = pivot;

    public Pixel[,] GetPixels()
    {
        var lines = text.Split('\n');
        var height = lines.Length;
        var width = lines.Select((line)=> line.Length).Max();
        var result = new Pixel[width, height];

        for(int y = 0; y < height; y++)
        {
            var line = lines[y];
            for(int x = 0; x < width; x++)
                
        }


        return result;
    }
}