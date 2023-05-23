using MediatR;

namespace OrdersWebApi.Users.Commands;

public class CreateUserCommand : IRequest {
    public CreateUserDto UserData { get; }

    public CreateUserCommand(CreateUserDto createUserDto) {
        UserData = createUserDto;
    }
}