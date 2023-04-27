namespace OrdersWebApi.Orders;

#pragma warning disable CS8602
public interface IOrderRepository
{
    Task Create(Order order);
    Order GetById(string id);
    void Update(Order orderModel);
}