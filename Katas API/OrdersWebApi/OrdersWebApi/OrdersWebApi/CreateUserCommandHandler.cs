using MediatR;

namespace OrdersWebApi.Tests;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand> {
    private readonly IUserRepository _usersRepository;

    public CreateUserCommandHandler(IUserRepository usersRepository) {
        _usersRepository = usersRepository;
    }

    public Task Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        _usersRepository.Create(new User(
            request.UserData.Id,
            request.UserData.Name,
            request.UserData.Address));
        return Task.CompletedTask;
    }
}