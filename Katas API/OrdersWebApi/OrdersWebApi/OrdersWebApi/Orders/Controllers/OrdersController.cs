using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Orders.Commands;
using OrdersWebApi.Orders.Commands.Dto;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Orders.Controllers.Responses;
using OrdersWebApi.Orders.Queries;

#pragma warning disable CS8602

namespace OrdersWebApi.Orders.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly GetOrderByIdQuery _getOrderByIdQuery;
    private readonly ISender _sender;

    public OrdersController(GetOrderByIdQuery getOrderByIdQuery, ISender sender)
    {
        _getOrderByIdQuery = getOrderByIdQuery;
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
    public ActionResult<OrderResponse> Get(string id)
    {
        return _getOrderByIdQuery.Execute(id);
    }
}