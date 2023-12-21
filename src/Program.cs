using SymbolEngine;

var drawer = new ConsoleDrawer(200, 26);
var snow = new List<Snowflake>();
Console.Clear();
while (true)
{
    snow.ForEach(s => s.Position.Y++);
    snow.RemoveAll(s => s.Position.Y >= drawer.Height);
    foreach (var x in Enumerable.Range(0, 3))
        snow.Add(new(Random.Shared.Next(100), 0));

    drawer.AddToRender(snow.ToArray());

    drawer.Draw();
    Thread.Sleep(500);
}