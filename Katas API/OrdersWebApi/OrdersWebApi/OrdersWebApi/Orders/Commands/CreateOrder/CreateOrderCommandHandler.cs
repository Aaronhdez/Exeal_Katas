using MediatR;

namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand> {
    private readonly IClock _clock;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IClock clock, IGuidGenerator guidGenerator) {
        _orderRepository = orderRepository;
        _clock = clock;
        _guidGenerator = guidGenerator;
    }

    public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken) {
        return _orderRepository.Create(new Order(
            _guidGenerator.NewId().ToString(),
            _clock.Timestamp().ToString("dd/MM/yyyy"),
            request.OrderData.Customer,
            request.OrderData.Address,
            request.OrderData.Products.ToList()));
    }
}