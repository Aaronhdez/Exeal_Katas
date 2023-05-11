using MediatR;

namespace OrdersWebApi.Orders.Queries;

public class GetOrderByIdQuery : IRequest<ReadOrderDto> {
    public GetOrderByIdQuery(string orderId) {
        OrderId = orderId;
    }

    public string OrderId { get; }
}