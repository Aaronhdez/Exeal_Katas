using MediatR;

namespace OrdersWebApi.Orders.Queries;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order> {
    private readonly IOrderRepository _ordersRepository;

    public GetOrderByIdQueryHandler(IOrderRepository ordersRepository) {
        _ordersRepository = ordersRepository;
    }

    public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) {
        return _ordersRepository.GetById(request.OrderId);
    }
}