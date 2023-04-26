using OrdersWebApi.Models.Orders;

namespace OrdersWebApi.Repositories;

public class InMemoryOrdersRepository : IOrderRepository
{
    private List<Order> _ordersList;

    public InMemoryOrdersRepository()
    {
        _ordersList = new List<Order>();
    }
    
    public void Create(Order order)
    {
        _ordersList.Add(order);
    }

    public Order GetById(string id)
    {
        return _ordersList.Where(o => o.Id == id).ToList()[0];
    }

    public void Update(Order orderModel)
    {
        
    }
}