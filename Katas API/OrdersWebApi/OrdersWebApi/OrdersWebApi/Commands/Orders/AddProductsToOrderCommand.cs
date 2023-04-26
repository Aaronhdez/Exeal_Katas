using OrdersWebApi.Controllers.Orders.Dto;
using OrdersWebApi.Models.Orders;

namespace OrdersWebApi.Commands.Orders;

#pragma warning disable CS8602
public class AddProductsToOrderCommand
{
    private readonly IOrderRepository _orderRepository;

    public AddProductsToOrderCommand(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public void Execute(AddProductsDto addProductsDto)
    {
        var order = _orderRepository.GetById(addProductsDto.Id);
        order.AddProducts(addProductsDto.Products.ToList());
        _orderRepository.Update(order);
    }
}