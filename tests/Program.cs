using SymbolEngine;

var drawer = new ConsoleDrawer(200, 30);
var snow = new List<Snowflake>();
var tree = new Tree() {Position = (90,31)};
Console.Clear();
while (true)
{
    snow.ForEach(s => s.Position.Y++);
    snow.RemoveAll(s => s.Position.Y >= drawer.Height);
    foreach (var x in Enumerable.Range(0, 3))
        snow.Add(new(Random.Shared.Next(200), 0));

    tree.Blink();

    drawer.AddToRender(snow.ToArray());
    drawer.AddToRender(tree);
    drawer.Draw();
    Thread.Sleep(500);
}