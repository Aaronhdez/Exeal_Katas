using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrdersWebApi.Infrastructure;

namespace OrdersWebApi.Products;

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
    
    
    //[HttpGet("{id}")]
    //public async Task<ProductQueryResponse> GetById(CreateProductRequest request) {
    //    var productReadDto = _guidGenerator.NewId().ToString();
    //    await _sender.Send(new CreateProductCommand(
    //        new CreateProductDto(
    //            id,
    //            request.Type, 
    //            request.Name, 
    //            request.Description,
    //            request.Manufacturer, 
    //            request.ManufacturerReference, 
    //            request.Value)));
    //    return await Task.FromResult(id);
    //}
}