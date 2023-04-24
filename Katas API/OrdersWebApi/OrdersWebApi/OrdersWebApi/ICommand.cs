namespace OrdersWebApi;

public interface ICommand
{
    public void Execute(CreateOrderDto expectedCreateOrder);
}