using MediatR;

namespace OrdersWebApi.Products.Commands;

public class CreateProductCommand : IRequest {
    public CreateProductCommand(CreateProductDto productDto) {
        ProductDto = productDto;
    }

    public CreateProductDto ProductDto { get; }
}