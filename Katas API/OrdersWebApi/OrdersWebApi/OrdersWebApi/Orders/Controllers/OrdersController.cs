using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Orders.Commands.AddProductsToOrder;
using OrdersWebApi.Orders.Commands.CreateOrder;
using OrdersWebApi.Orders.Controllers.Requests;
using OrdersWebApi.Orders.Controllers.Responses;
using OrdersWebApi.Orders.Queries;
using OrdersWebApi.Users.Controllers;

#pragma warning disable CS8602

namespace OrdersWebApi.Orders.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase {
    private readonly IGuidGenerator _guidGenerator;
    private readonly ISender _sender;

    public OrdersController(ISender sender, IGuidGenerator guidGenerator) {
        _sender = sender;
        _guidGenerator = guidGenerator;
    }

    [HttpPost]
    public async Task<string> Post(CreateOrderRequest request) {
        var id = _guidGenerator.NewId().ToString();
        await _sender.Send(
            new CreateOrderCommand(new CreateOrderDto(
                id, 
                request.VendorId, 
                request.CustomerId, 
                request.Products)));
        return await Task.FromResult(id);
    }

    [HttpPut("{id}")]
    public async Task Put(string id, AddProductsRequest request) {
        await _sender.Send(new AddProductsToOrderCommand(new AddProductsDto(id, request.Products)));
    }

    [HttpGet("{id}")]
    public async Task<OrderResponse> Get(string id) {
        var readDto = await _sender.Send(new GetOrderByIdQuery(id));
        return new OrderResponse(
            readDto.Id, 
            readDto.CreationDate, 
            new ReadUserResponse(readDto.Vendor.Id, readDto.Vendor.Name, readDto.Vendor.Address), 
            new ReadUserResponse(readDto.Customer.Id, readDto.Customer.Name, readDto.Customer.Address), 
            readDto.Products);
    }
}