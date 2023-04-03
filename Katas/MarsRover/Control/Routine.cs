namespace MarsRover.Control;

public class Routine
{
    public Routine(Order[] orders)
    {
        Orders = orders;
    }

    private Order[] Orders { get; }

    public List<Order> ListOfOrders()
    {
        return Orders.ToList();
    }
}