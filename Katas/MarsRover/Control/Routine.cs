namespace MarsRover.Control;

public class Routine
{
    public Routine(Order[] orders)
    {
        Orders = orders;
    }

    public Order[] Orders { get; }

    public List<Order> ListOfOrders()
    {
        return Orders.ToList();
    }
}