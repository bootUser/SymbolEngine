using SymbolEngine;

public class Garland : SymbolObject
{
    private ConsoleColor _lastColor;
    public Garland()
    {
        Childrens = [
            new Lamp {Position = (13,6)},

            new Lamp {Position = (11,9)},
            new Lamp {Position = (15,9)},

            new Lamp {Position = (9,12)},
            new Lamp {Position = (13,12)},
            new Lamp {Position = (17,12)},

            new Lamp {Position = (7,15)},
            new Lamp {Position = (11,15)},
            new Lamp {Position = (15,15)},
            new Lamp {Position = (19,15)},

            new Lamp {Position = (5,18)},
            new Lamp {Position = (9,18)},
            new Lamp {Position = (13,18)},
            new Lamp {Position = (17,18)},
            new Lamp {Position = (21,18)},
        ];
    }

    public void Blink()
    {
        foreach(var child in Childrens)
            if(child is Lamp lamp)
                lamp.SetRandomColor();
    }
}