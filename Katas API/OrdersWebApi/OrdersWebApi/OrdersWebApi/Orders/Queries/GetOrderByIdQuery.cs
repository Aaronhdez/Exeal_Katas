using MediatR;

namespace OrdersWebApi.Orders.Queries;

public class GetOrderByIdQuery : IRequest<Order>
{
    public string OrderId { get; }

    public GetOrderByIdQuery(string orderId)
    {
        OrderId = orderId;
    }
}