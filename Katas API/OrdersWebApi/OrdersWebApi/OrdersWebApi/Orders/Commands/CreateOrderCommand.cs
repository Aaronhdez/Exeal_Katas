using MediatR;
using OrdersWebApi.Orders.Commands.Dto;

namespace OrdersWebApi.Orders.Commands;

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