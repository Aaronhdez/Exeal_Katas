using MediatR;

namespace OrdersWebApi.Products;

public class CreateProductCommand : IRequest {
    public CreateProductCommand(CreateProductDto productDto) {
        ProductDto = productDto;
    }

    public CreateProductDto ProductDto { get; }
}