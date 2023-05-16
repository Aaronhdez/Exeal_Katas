using MediatR;

namespace OrdersWebApi.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadDto> {
    private readonly IProductsRepository _repository;

    public GetProductByIdQueryHandler(IProductsRepository repository) {
        _repository = repository;
    }

    public async Task<ProductReadDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {
        var product = await _repository.GetById(request.Id);
        return new ProductReadDto {
            Id = product.Id,
            ProductReference = product.ProductReference,
            Name = product.Name,
            Description = product.Description,
            Manufacturer = product.Manufacturer,
            ManufacturerReference = product.ManufacturerReference,
            Value = (int)product.Value,
        };
    }
}