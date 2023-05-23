using MediatR;

namespace OrdersWebApi.Users.Queries;

public class GetUserByIdQuery : IRequest<ReadUserDto> {
    public string Id { get; }

    public GetUserByIdQuery(string Id) {
        this.Id = Id;
    }
}