using OrdersWebApi.Orders.Controllers.Responses;

namespace OrdersWebApi.Orders.Queries;

public class GetOrderByIdQuery
{
    private readonly IOrderRepository _ordersRepository;

    public GetOrderByIdQuery(IOrderRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }
    public OrderResponse Execute(string orderId)
    {
        var order = _ordersRepository.GetById(orderId);
        return new OrderResponse
        {
            Id = order.Id,
            CreationDate = order.Timestamp,
            Address = order.Address,
            Customer = order.Customer,
            Products = order.Products
        };
    }
}