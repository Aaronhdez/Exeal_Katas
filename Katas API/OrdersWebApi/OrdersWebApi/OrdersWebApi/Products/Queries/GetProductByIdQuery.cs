using MediatR;

namespace OrdersWebApi.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductReadDto> {
    public string Id { get; }

    public GetProductByIdQuery(string id) {
        Id = id;
    }
}