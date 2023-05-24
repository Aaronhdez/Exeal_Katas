using MediatR;
using OrdersWebApi.Users.Queries;

namespace OrdersWebApi.Orders.Queries;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, ReadOrderDto> {
    private readonly IOrderRepository _ordersRepository;

    public GetOrderByIdQueryHandler(IOrderRepository ordersRepository) {
        _ordersRepository = ordersRepository;
    }

    public async Task<ReadOrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) {
        var order = await _ordersRepository.GetById(request.OrderId);
        return new ReadOrderDto(
            order.Id, 
            order.CreationDate, 
            new ReadUserDto(order.Vendor.Id, order.Vendor.Name, order.Vendor.Address), 
            new ReadUserDto(order.Customer.Id, order.Customer.Name, order.Customer.Address), 
            order.Products);
    }
}