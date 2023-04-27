namespace OrdersWebApi.Orders.Repositories;

public class InMemoryOrdersRepository : IOrderRepository
{
    private List<Order> _ordersList;

    public InMemoryOrdersRepository()
    {
        _ordersList = new List<Order>();
    }
    
    public Task Create(Order order)
    {
        _ordersList.Add(order);
        return Task.CompletedTask;
    }

    public Order GetById(string id)
    {
        return _ordersList.Where(o => o.Id == id).ToList()[0];
    }

    public Task Update(Order orderModel)
    {   
        return Task.CompletedTask;
    }
}