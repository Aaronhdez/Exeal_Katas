using MediatR;

namespace OrdersWebApi.Orders.Queries;

public class GetOrderByIdQuery : IRequest<Order> {
    public GetOrderByIdQuery(string orderId) {
        OrderId = orderId;
    }

    public string OrderId { get; }
}