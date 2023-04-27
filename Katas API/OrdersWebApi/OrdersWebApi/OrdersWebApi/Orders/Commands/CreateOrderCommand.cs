using OrdersWebApi.Controllers.Orders.Dto;
using OrdersWebApi.Models.Orders;

namespace OrdersWebApi.Commands.Orders;

#pragma warning disable CS8602
public class CreateOrderCommand
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommand(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public string Execute(CreateOrderDto createOrderDto)
    {
        var orderModel = new Order(
            createOrderDto.Id,
            createOrderDto.Timestamp.ToString("dd/MM/yyyy"),
            createOrderDto.Customer, 
            createOrderDto.Address, 
            new Products(createOrderDto.Products.ToList()));
        _orderRepository.Create(orderModel);
        return createOrderDto.Id;
    }
}