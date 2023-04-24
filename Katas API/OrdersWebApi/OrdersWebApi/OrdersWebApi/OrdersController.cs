using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS8602

namespace OrdersWebApi;


[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly CreateOrderCommand _createOrderCommand;
    private readonly IClock _clock;

    public OrdersController(IClock clock, CreateOrderCommand createOrderCommand)
    {
        _createOrderCommand = createOrderCommand;
        _clock = clock;
    }
    
    [HttpPost("{orderId}")]
    public Task Post(string orderId, CreateOrderRequest createOrderRequest)
    {
        var createOrderDto = new CreateOrderDto(orderId, _clock.Timestamp(), createOrderRequest.Customer, createOrderRequest.Address,
            createOrderRequest.Products);
        _createOrderCommand.Execute(createOrderDto);
        return Task.FromResult(Task.CompletedTask);
    }
}