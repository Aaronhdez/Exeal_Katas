using MediatR;
using OrdersWebApi.Infrastructure;

namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand> {
    private readonly IClock _clock;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IClock clock) {
        _orderRepository = orderRepository;
        _clock = clock;
    }

    public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken) {
        return _orderRepository.Create(new Order(
            request.OrderData.Id,
            _clock.Timestamp().ToString("dd/MM/yyyy"),
            request.OrderData.Customer,
            request.OrderData.Address,
            request.OrderData.Products.ToList()));
    }
}