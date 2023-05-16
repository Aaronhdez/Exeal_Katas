using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Infrastructure;
using OrdersWebApi.Products.Commands;
using OrdersWebApi.Products.Controllers.Requests;
using OrdersWebApi.Products.Controllers.Responses;
using OrdersWebApi.Products.Queries;

namespace OrdersWebApi.Products.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase {
    private readonly ISender _sender;
    private readonly IGuidGenerator _guidGenerator;

    public ProductsController(ISender sender, IGuidGenerator guidGenerator) {
        _sender = sender;
        _guidGenerator = guidGenerator;
    }

    [HttpPost]
    public async Task<string> Post(CreateProductRequest request) {
        var id = _guidGenerator.NewId().ToString();
        await _sender.Send(new CreateProductCommand(
            new CreateProductDto(
                id,
                request.Type, 
                request.Name, 
                request.Description,
                request.Manufacturer, 
                request.ManufacturerReference, 
                request.Value)));
        return await Task.FromResult(id);
    }
    
    
    [HttpGet("{id}")]
    public async Task<ProductQueryResponse> GetById(string id) {
        var readDto = await _sender.Send(new GetProductByIdQuery(id));
        return new ProductQueryResponse(
            readDto.Id,
            readDto.ProductReference,
            readDto.Name,
            readDto.Description,
            readDto.Manufacturer,
            readDto.ManufacturerReference,
            readDto.Value
        );
    }
}