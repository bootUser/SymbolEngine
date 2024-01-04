using SymbolEngine;

var drawer = new ConsoleDrawer(150, 26) {ShowCursor = false, ShowPivot = false};
var engine = new SEngine(drawer);

var snow = new List<Snowflake>();
var tree = new Tree() {Position = (90,25)};
tree.Childrens.Add(new Garland());
Console.Clear();
while (true)
{
    Console.ReadLine();
    snow.ForEach(s => s.Position.Y++);
    snow.RemoveAll(s => s.Position.Y >= drawer.Height);
    foreach (var x in Enumerable.Range(0, 3))
        snow.Add(new(Random.Shared.Next(200), 0));

    tree.Blink();


}