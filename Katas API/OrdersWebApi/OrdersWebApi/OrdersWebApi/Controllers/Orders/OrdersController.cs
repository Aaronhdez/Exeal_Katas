using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Commands.Orders;
using OrdersWebApi.Controllers.Orders.Dto;
using OrdersWebApi.Controllers.Orders.Requests;
using OrdersWebApi.Queries;

#pragma warning disable CS8602

namespace OrdersWebApi.Controllers.Orders;


[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IClock _clock;
    private readonly CreateOrderCommand _createOrderCommand;
    private readonly GetOrderByIdQuery _getOrderByIdQuery;

    public OrdersController(IClock clock, CreateOrderCommand createOrderCommand,
        AddProductsToOrderCommand addProductsToOrderCommand, GetOrderByIdQuery getOrderByIdQuery)
    {
        _createOrderCommand = createOrderCommand;
        _getOrderByIdQuery = getOrderByIdQuery;
        _clock = clock;
    }
    
    [HttpPost]
    public Task Post(CreateOrderRequest createOrderRequest)
    {
        var createOrderDto = new CreateOrderDto(createOrderRequest.Id, _clock.Timestamp(), createOrderRequest.Customer, createOrderRequest.Address,
            createOrderRequest.Products);
        _createOrderCommand.Execute(createOrderDto);
        return Task.CompletedTask;
    }
    
    [HttpPut("{id}/Products")]
    public Task Put(string id, AddProductsRequest addProductsRequest)
    {
        var addProductsDto = new AddProductsDto(id, addProductsRequest.Products);
        return null;
    }

    [HttpGet("{id}")]
    public ActionResult<OrderResponse> Get(string id)
    {
        return _getOrderByIdQuery.Execute(id);
    }
}