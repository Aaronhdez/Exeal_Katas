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
        AddProductsToCurrentOrder(request, order);
        return _orderRepository.Update(order);
    }

    private void AddProductsToCurrentOrder(AddProductsToOrderCommand request, Order order) {
        var products = request.Products.Select(
            productId => _productsRepository.GetById(productId).Result).ToList();
        foreach (var newProduct in products) order.AddProduct(newProduct);
    }
}