namespace OrdersWebApi.Orders;

#pragma warning disable CS8602
public interface IOrderRepository
{
    Task Create(Order order);
    Task<Order> GetById(string orderId);
    Task Update(Order orderModel);
}