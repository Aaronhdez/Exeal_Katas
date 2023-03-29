namespace MarsRover;

public class Routine
{
    public Routine(Order[] orders)
    {
        Orders = orders;
    }

    public Order[] Orders { get; }
}