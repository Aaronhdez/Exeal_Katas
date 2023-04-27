using MediatR;

namespace OrdersWebApi.Orders.Commands;

#pragma warning disable CS8602
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IClock _clock;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IClock clock)
    {
        _orderRepository = orderRepository;
        _clock = clock;
    }

    public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        return _orderRepository.Create(new Order(
            request.Id,
            _clock.Timestamp().ToString("dd/MM/yyyy"),
            request.OrderData.Customer, 
            request.OrderData.Address, 
            new Products(request.OrderData.Products.ToList())));
    }
}