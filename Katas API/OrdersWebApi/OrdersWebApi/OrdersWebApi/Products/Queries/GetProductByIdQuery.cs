using MediatR;

namespace OrdersWebApi.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductReadDto> {
    public GetProductByIdQuery(string id) {
        Id = id;
    }

    public string Id { get; }
}