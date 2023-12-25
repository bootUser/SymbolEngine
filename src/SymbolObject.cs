namespace SymbolEngine;

public abstract class SymbolObject
{
    public Point Position;

    public IDrawable? Texture;
    public List<SymbolObject> Childrens = [];
}