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

    public Task<Order> GetById(string orderId)
    {
        return Task.FromResult(_ordersList.Where(o => o.Id == orderId).ToList()[0]);
    }

    public Task Update(Order orderModel)
    {
        var currentOrder = _ordersList.First(o => o.Id == orderModel.Id);
        _ordersList.Remove(currentOrder);
        _ordersList.Add(orderModel);
        return Task.CompletedTask;
    }
}