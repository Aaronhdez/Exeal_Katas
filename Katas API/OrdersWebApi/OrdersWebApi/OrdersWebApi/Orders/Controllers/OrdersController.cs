using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Orders.Queries;

#pragma warning disable CS8602

namespace OrdersWebApi.Orders.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task Post(CreateOrderRequest request)
    {
        await _sender.Send(new CreateOrderCommand(request.Id, new CreateOrderDto(request.Customer,
            request.Address, request.Products)));
    }

    [HttpPut("{id}/Products")]
    public async Task Put(string id, AddProductsRequest request)
    {
        await _sender.Send(new AddProductsToOrderCommand(new AddProductsDto(id, request.Products)));
    }

    [HttpGet("{id}")]
    public Task<Order> Get(string id)
    {
        return _sender.Send(new GetOrderByIdQuery(id));
    }
}