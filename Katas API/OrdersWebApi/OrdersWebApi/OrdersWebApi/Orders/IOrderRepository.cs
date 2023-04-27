namespace OrdersWebApi.Models.Orders;

#pragma warning disable CS8602
public interface IOrderRepository
{
    void Create(Order order);
    Order GetById(string id);
    void Update(Order orderModel);
}