namespace SymbolEngine;

public class WaitFor
{
    public TimeSpan Delay {get; init;}

    private WaitFor(TimeSpan time)
    {
        Delay = time;
    }

    public static WaitFor Time(TimeSpan time)
    {
        return new WaitFor(time);
    }

    public static WaitFor Seconds(double seconds)
    {
        return Time(TimeSpan.FromSeconds(seconds));
    }
}
