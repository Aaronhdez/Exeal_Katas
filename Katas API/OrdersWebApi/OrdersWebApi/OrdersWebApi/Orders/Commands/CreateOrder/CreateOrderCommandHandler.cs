using MediatR;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand> {
    private readonly IClock _clock;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductsRepository _productsRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IProductsRepository productsRepository,
        IClock clock) {
        _orderRepository = orderRepository;
        _productsRepository = productsRepository;
        _clock = clock;
    }

    public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken) {
        return _orderRepository.Create(new Order(
            request.OrderData.Id,
            _clock.Timestamp().ToString("dd/MM/yyyy"),
            request.OrderData.Customer,
            request.OrderData.Address,
            GetProductsAssigned(request.OrderData.Products)));
    }

    private List<Product> GetProductsAssigned(IEnumerable<string> productIds) {
        return productIds.Select(productId => _productsRepository.GetById(productId).Result).ToList();
    }
}