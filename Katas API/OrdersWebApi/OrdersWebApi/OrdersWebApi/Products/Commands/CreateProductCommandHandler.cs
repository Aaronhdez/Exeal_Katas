using MediatR;
using OrdersWebApi.Infrastructure;

namespace OrdersWebApi.Products.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand> {
    private readonly ProductReferenceGenerator _productReferenceGenerator;
    private readonly IProductsRepository _repository;

    public CreateProductCommandHandler(IProductsRepository repository,
        ProductReferenceGenerator productReferenceGenerator) {
        _repository = repository;
        _productReferenceGenerator = productReferenceGenerator;
    }

    public async Task Handle(CreateProductCommand command, CancellationToken cancellationToken) {
        var item = new Product(
            command.ProductDto.Id,
            await _productReferenceGenerator.GenerateReferenceForTag(command.ProductDto.Type),
            command.ProductDto.Type,
            command.ProductDto.Name,
            command.ProductDto.Description,
            command.ProductDto.Manufacturer,
            command.ProductDto.ManufacturerReference,
            command.ProductDto.Value);
        await _repository.Create(item);
    }
}