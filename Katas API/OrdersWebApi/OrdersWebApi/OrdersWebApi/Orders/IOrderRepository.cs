namespace OrdersWebApi.Orders;

#pragma warning disable CS8602
public interface IOrderRepository
{
    Task Create(Order order);
    Task<Order> GetById(string id);
    Task Update(Order orderModel);
}