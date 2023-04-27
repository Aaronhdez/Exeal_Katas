using MediatR;

namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602

public class CreateOrderCommand : IRequest
{
    public CreateOrderDto OrderData { get; }
    public string Id { get; }

    public CreateOrderCommand(string id, CreateOrderDto orderData)
    {
        OrderData = orderData;
        Id = id;
    }
}