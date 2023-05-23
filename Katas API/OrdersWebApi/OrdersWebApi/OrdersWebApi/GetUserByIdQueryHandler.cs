using MediatR;

namespace OrdersWebApi.Tests;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ReadUserDto> {
    private readonly IUsersRepository _usersRepository;

    public GetUserByIdQueryHandler(IUsersRepository usersRepository) {
        _usersRepository = usersRepository;
    }

    public Task<ReadUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) {
        var user = _usersRepository.GetById(request.Id);
        return Task.FromResult(new ReadUserDto(user.Id, user.Name, user.Address));
    }
}