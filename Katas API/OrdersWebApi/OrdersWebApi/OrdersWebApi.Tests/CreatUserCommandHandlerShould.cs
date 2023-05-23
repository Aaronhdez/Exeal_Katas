using FluentAssertions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OrdersWebApi.Tests; 

public class CreatUserCommandHandlerShould {
    private IUserRepository _usersRepository;

    [Test]
    public void CreateANonExistentUser() {
        _usersRepository = new InMemoryUsersRepository();
        var handler = new CreateUserCommandHandler(_usersRepository);
        var userCreateDto = new CreateUserDto("An Id", "a Name", "An Address");

        handler.Handle(new CreateUserCommand(userCreateDto), default);

        var expectedUser = new User(userCreateDto.Name, userCreateDto.Address);
        var retrievedUser = _usersRepository.GetById("An Id");
        retrievedUser.Should().BeEquivalentTo(expectedUser);
    }
}