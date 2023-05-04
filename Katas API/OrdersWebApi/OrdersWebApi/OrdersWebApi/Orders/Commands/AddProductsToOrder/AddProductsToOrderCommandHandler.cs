using MediatR;

namespace OrdersWebApi.Orders.Commands.AddProductsToOrder;
#pragma warning disable CS8602

public class AddProductsToOrderCommandHandler : IRequestHandler<AddProductsToOrderCommand>
{
    private readonly IOrderRepository _orderRepository;

    public AddProductsToOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task Handle(AddProductsToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _orderRepository.GetById(request.Id).Result;
        order.AddProducts(request.Products);
        return _orderRepository.Update(order);
    }
}