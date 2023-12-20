namespace SymbolWinter;

public class ConsoleDrawer
{
    public int Width { get; init; }
    public int Height { get; init; }

    private Pixel[,] _lastFrame;
    private Pixel[,] _frame;

    public ConsoleDrawer(int width, int height)
    {
        Width = width;
        Height = height;
        _frame = CreateClearFrame(width, height);
        _lastFrame = CreateClearFrame(width, height);
    }

    private Pixel[,] CreateClearFrame(int width, int height)
    {
        var result = new Pixel[width, height];
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[x, y] = new Pixel();
        return result;
    }

    public void Draw()
    {
        Console.CursorVisible = false;
        for (int x = 0; x < Width; x++)
            for (int y = 0; y < Height; y++)
                if (_frame[x, y] != _lastFrame[x, y])
                {
                    var pixel = _frame[x, y];
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = pixel.Color;
                    Console.Write(pixel.Symbol);
                    Console.ResetColor();
                }
        Console.CursorVisible = true;
        _lastFrame = _frame;
        _frame = CreateClearFrame(Width, Height);
    }

    public void AddToRender(params SymbolObject[] objects)
    {
        foreach (var obj in objects)
        {
            var pixels = obj.Texture.GetPixels();
            var pivot = obj.Texture.Pivot;
            var position = obj.Position;
            for (int x = 0; x < pixels.GetLength(0); x++)
                for (int y = 0; y < pixels.GetLength(1); y++)
                {
                    if (x - pivot.X + position.X >= 0 || x - pivot.X + position.X < Width)
                        if (y - pivot.Y + position.Y >= 0 || y - pivot.Y + position.Y < Height)
                            _frame[x - pivot.X + position.X, y - pivot.Y + position.Y] = pixels[x, y];
                }
        }
    }
}