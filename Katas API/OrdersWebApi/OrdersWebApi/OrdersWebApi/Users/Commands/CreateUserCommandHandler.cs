﻿using MediatR;

namespace OrdersWebApi.Users.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand> {
    private readonly IUsersRepository _usersRepository;

    public CreateUserCommandHandler(IUsersRepository usersRepository) {
        _usersRepository = usersRepository;
    }

    public Task Handle(CreateUserCommand request, CancellationToken cancellationToken) {
        _usersRepository.Create(new User(request.UserData.Id, new UserData(request.UserData.Name), new Address(request.UserData.Address)));
        return Task.CompletedTask;
    }
}