using MediatR;

namespace OrdersWebApi;

public class CreateUserCommand : IRequest {
    public CreateUserDto UserData { get; }

    public CreateUserCommand(CreateUserDto createUserDto) {
        UserData = createUserDto;
    }
}