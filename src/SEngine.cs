namespace SymbolEngine;

public class SEngine
{
    private ConsoleDrawer _drawer;
    private Scene? _loadedScene;
    public SEngine(ConsoleDrawer drawer)
    {
        _drawer = drawer;
    }

    public void Start()
    {
        if(_loadedScene is null)
            throw new Exception("Scene is not loaded befor start.");
        Loop();
    }

    public void LoadScene(Scene scene)
    {
        _loadedScene = scene;
        _drawer.AddToRender([.. scene.Objects]);
    }

    private void ExecuteSetup()
    {
        var objects = _loadedScene.Objects;
    }

    private void Loop()
    {
        while (true)
        {

            _drawer.AddToRender(_loadedScene!.Objects.ToArray());
            _drawer.Draw();
        }
    }
}
