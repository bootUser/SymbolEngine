namespace SymbolEngine;

public class ConsoleDrawer(int width, int height)
{
    public int Width { get; init; } = width;
    public int Height { get; init; } = height;
    public bool ShowCursor { get; set; }
    public bool ShowPivot {get;set;}

    private Pixel[,] _lastFrame = CreateClearFrame(width, height);
    private Pixel[,] _frame = CreateClearFrame(width, height);

    private static Pixel[,] CreateClearFrame(int width, int height)
    {
        var result = new Pixel[width, height];
        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                result[x, y] = new Pixel(' ');
        return result;
    }

    internal void Draw()
    {
        Console.CursorVisible = ShowCursor;
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
        _lastFrame = _frame;
        _frame = CreateClearFrame(Width, Height);
    }

    internal void AddToRender(params SymbolObject[] objects) => Array.ForEach(objects, obj => PlaceObjectOnFrame(obj, null, (0, 0)));

    private void PlaceObjectOnFrame(SymbolObject obj, SymbolObject? parent, Point parentOrigin)
    {
        if (parent is not null)
        {
            parentOrigin.X += parent.Position.X - parent.Texture?.Pivot.X ?? 0;
            parentOrigin.Y += parent.Position.Y - parent.Texture?.Pivot.Y ?? 0;
        }
        if (obj.Texture is not null)
        {
            var pixels = obj.Texture.GetPixels();
            var pivot = obj.Texture.Pivot;
            var position = obj.Position;
            var tWidth = pixels.GetLength(0);
            var tHeight = pixels.GetLength(1);

            for (int x = 0; x < tWidth; x++)
                for (int y = 0; y < tHeight; y++)
                    if (pixels[x, y].Symbol != '\0')
                    {
                        var deltaX = x - pivot.X + position.X + parentOrigin.X;
                        var deltaY = y - pivot.Y + position.Y + parentOrigin.Y;
                        if (deltaX >= 0 && deltaX < Width)
                            if (deltaY >= 0 && deltaY < Height)
                                _frame[deltaX, deltaY] = ShowPivot && pivot == (x,y) ? new Pixel('$', ConsoleColor.Red) : pixels[x, y];
                    }
        }
        foreach (var child in obj.Childrens)
            PlaceObjectOnFrame(child, obj, parentOrigin);
    }
}