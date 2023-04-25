using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Commands.Orders;
using OrdersWebApi.Controllers.Orders.Dto;
using OrdersWebApi.Controllers.Orders.Requests;

#pragma warning disable CS8602

namespace OrdersWebApi.Controllers.Orders;


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