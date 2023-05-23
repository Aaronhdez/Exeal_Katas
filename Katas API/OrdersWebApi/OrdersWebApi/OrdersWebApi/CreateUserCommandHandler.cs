using MediatR;

namespace OrdersWebApi.Tests;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand> {
    private readonly IUserRepository _usersRepository;

    public CreateUserCommandHandler(IUserRepository usersRepository) {
        _usersRepository = usersRepository;
    }

    public Task Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        return Task.CompletedTask;
    }
}