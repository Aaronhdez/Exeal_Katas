using MediatR;

namespace OrdersWebApi.Products.Queries;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadDto> {
    private readonly IProductsRepository _repository;

    public GetProductByIdQueryHandler(IProductsRepository repository) {
        _repository = repository;
    }

    public async Task<ProductReadDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) {
        return await _repository.GetById(request.Id);
    }
}