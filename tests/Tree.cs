using SymbolEngine;

public class Tree : SymbolObject
{
    private Pixel[,] _originalTexture;
    public Tree()
    {
        var tree = File.ReadAllText("./tree.txt");
        _originalTexture = new SymbolTexture(tree, ConsoleColor.DarkGreen, (14,26)).GetPixels();
    }

    class Temp(Func<Pixel[,]> getPixels) : IDrawable
    {
        public Point Pivot { get; init; } = (14,26);
        public Pixel[,] GetPixels() => getPixels();
    }

    public void Blink()
    {
        // 14 15 y 7
        var newColor = (ConsoleColor) Random.Shared.Next(16);
        _originalTexture[13, 6] = _originalTexture[13,6] with {Color = newColor};
        _originalTexture[14, 6] = _originalTexture[14,6] with {Color = newColor};
        Texture = new Temp(()=> _originalTexture);
    }
}