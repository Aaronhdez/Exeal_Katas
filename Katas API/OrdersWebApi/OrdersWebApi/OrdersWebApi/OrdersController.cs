using Microsoft.AspNetCore.Mvc;

namespace OrdersWebApi;

#pragma warning disable CS8602
public class OrdersController : ControllerBase
{
    public OrdersController(ICommand createOrderCommand, IClock clock)
    {
        
    }

    public async Task Post(string orderId, CreateOrderRequest createOrderRequest)
    {
        
    }
}