using SymbolEngine;

public class Tree : SymbolObject
{
    public Tree()
    {
        var tree = File.ReadAllText("./Textures/tree.txt");
        Texture = new SymbolTexture(tree, ConsoleColor.DarkGreen, (13,24));
    }

    public void Blink()
    {
        foreach(var child in Childrens)
            if(child is Garland garland)
                garland.Blink();

    }
}