using MediatR;
using OrdersWebApi.Products;

namespace OrdersWebApi.Orders.Commands.AddProductsToOrder;
#pragma warning disable CS8602

public class AddProductsToOrderCommandHandler : IRequestHandler<AddProductsToOrderCommand> {
    private readonly IOrderRepository _orderRepository;
    private readonly IProductsRepository _productsRepository;

    public AddProductsToOrderCommandHandler(IOrderRepository orderRepository, IProductsRepository productsRepository) {
        _orderRepository = orderRepository;
        _productsRepository = productsRepository;
    }

    public Task Handle(AddProductsToOrderCommand request, CancellationToken cancellationToken) {
        var order = _orderRepository.GetById(request.Id).Result;
        var addedItems = request.Products.Select(
            productId => _productsRepository.GetById(productId).Result).ToList();
        order.AddProducts(addedItems);
        return _orderRepository.Update(order);
    }
}