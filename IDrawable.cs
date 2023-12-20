namespace SymbolWinter;

public interface IDrawable
{
    Point Pivot {get; init;}
    Pixel[,] GetPixels();
}