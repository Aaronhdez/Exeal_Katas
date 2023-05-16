using MediatR;
using OrdersWebApi.Orders;

namespace OrdersWebApi.Tests.Products;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadDto> {
    private readonly IProductsRepository _productsRepository;

    public GetProductByIdQueryHandler(IProductsRepository productsRepository) {
        _productsRepository = productsRepository;
    }

    public Task<ProductReadDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}