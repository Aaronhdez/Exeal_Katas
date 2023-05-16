using MediatR;

namespace OrdersWebApi.Tests.Products;

public class GetProductByIdQuery : IRequest<ProductReadDto> {
    public string Id { get; }

    public GetProductByIdQuery(string id) {
        Id = id;
    }
}