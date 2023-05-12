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
public class OrdersController : ControllerBase {
    private readonly ISender _sender;
    private readonly IGuidGenerator _guidGenerator;

    public OrdersController(ISender sender, IGuidGenerator guidGenerator) {
        _sender = sender;
        _guidGenerator = guidGenerator;
    }

    [HttpPost]
    public async Task<string> Post(CreateOrderRequest request) {
        var id = _guidGenerator.NewId().ToString();
        await _sender.Send(new CreateOrderCommand(new CreateOrderDto(id, request.Customer, request.Address, request.Products)));
        return await Task.FromResult(id);
    }

    [HttpPut("{id}")]
    public async Task Put(string id, AddProductsRequest request) {
        await _sender.Send(new AddProductsToOrderCommand(new AddProductsDto(id, request.Products)));
    }

    [HttpGet("{id}")]
    public Task<ReadOrderDto> Get(string id) {
        return _sender.Send(new GetOrderByIdQuery(id));
    }
}