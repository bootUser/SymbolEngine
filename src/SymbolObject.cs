namespace SymbolEngine;

public abstract class SymbolObject
{
    public Point Position;

    public IDrawable? Texture;
    public List<SymbolObject> Childrens = [];

    public virtual Task Setup() => Task.CompletedTask;

    public virtual Task Update() => Task.CompletedTask;
}