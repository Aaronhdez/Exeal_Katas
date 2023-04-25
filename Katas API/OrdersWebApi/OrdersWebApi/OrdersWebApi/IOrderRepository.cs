namespace OrdersWebApi;

#pragma warning disable CS8602
public interface IOrderRepository
{
    void Create(Order order);
}