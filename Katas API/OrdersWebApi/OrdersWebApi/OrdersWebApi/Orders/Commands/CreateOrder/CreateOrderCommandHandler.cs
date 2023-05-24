using MediatR;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products;
using OrdersWebApi.Users;

namespace OrdersWebApi.Orders.Commands.CreateOrder;

#pragma warning disable CS8602
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand> {
    private readonly IClock _clock;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductsRepository _productsRepository;
    private IUsersRepository _usersRepository;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository, 
        IProductsRepository productsRepository,
        IUsersRepository usersRepository,
        IClock clock) {
        _orderRepository = orderRepository;
        _productsRepository = productsRepository;
        _clock = clock;
        _usersRepository = usersRepository;
    }

    public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken) {
        var vendor = _usersRepository.GetById(request.OrderData.VendorId);
        var customer = _usersRepository.GetById(request.OrderData.CustomerId);
        return _orderRepository.Create(new Order(
            request.OrderData.Id, 
            _clock.Timestamp().ToString("dd/MM/yyyy"), 
            vendor, 
            customer, 
            GetProductsAssigned(request.OrderData.Products)));
    }

    private List<Product> GetProductsAssigned(IEnumerable<string> productIds) {
        return productIds.Select(productId => _productsRepository.GetById(productId).Result).ToList();
    }
}