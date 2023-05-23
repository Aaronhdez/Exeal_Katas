using MediatR;

namespace OrdersWebApi.Tests;

public class GetUserByIdQuery : IRequest, IRequest<ReadUserDto> {
    public string Id { get; }

    public GetUserByIdQuery(string Id) {
        this.Id = Id;
    }
}