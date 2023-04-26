using OrdersWebApi.Controllers.Orders.Dto;
using OrdersWebApi.Models.Orders;

namespace OrdersWebApi.Commands.Orders;

#pragma warning disable CS8602
public class AddProductsToOrderCommand
{
    public AddProductsToOrderCommand(IOrderRepository orderRepository)
    {
        
    }
    
    public void Execute(AddProductsDto addProductsDto)
    {
        
    }
}