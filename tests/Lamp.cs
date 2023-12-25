using SymbolEngine;

public class Lamp : SymbolObject
{
    private string text;
    private ConsoleColor _lastColor;
    private static HashSet<ConsoleColor> _colors;
    static Lamp() => _colors = Enum.GetValues<ConsoleColor>().ToHashSet();
    public Lamp()
    {
        text = File.ReadAllText("./Textures/lamp.txt");
    }

    public void SetColor(ConsoleColor color)
    {
        _lastColor = color;
        Texture = new SymbolTexture(text, color, (0,0));
    }

    public void SetRandomColor()
    {
        var newColor = _colors.Except([_lastColor]).ToArray()[Random.Shared.Next(_colors.Count-1)];
        Texture = new SymbolTexture(text, newColor, (0,0));
    }

}