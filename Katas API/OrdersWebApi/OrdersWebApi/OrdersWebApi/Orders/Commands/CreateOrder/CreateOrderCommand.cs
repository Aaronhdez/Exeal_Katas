using MediatR;

namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602

public class CreateOrderCommand : IRequest {
    public CreateOrderCommand(CreateOrderDto orderData) {
        OrderData = orderData;
    }

    public CreateOrderDto OrderData { get; }
}