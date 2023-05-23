using FluentAssertions;
using OrdersWebApi.Users;
using OrdersWebApi.Users.Commands;
using OrdersWebApi.Users.Repositories;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OrdersWebApi.Tests; 

public class CreatUserCommandHandlerShould {
    private IUsersRepository _usersRepository;
    private CreateUserCommandHandler _handler;
    private CreateUserDto _userCreateDto;

    [SetUp]
    public void SetUp() {
        _usersRepository = new InMemoryUsersRepository();
        _handler = new CreateUserCommandHandler(_usersRepository);
    }

    [Test]
    public void CreateANonExistentUser() {
        _userCreateDto = new CreateUserDto("An Id", "a Name", "An Address");
        
        _handler.Handle(new CreateUserCommand(_userCreateDto), default);

        var expectedUser = new User(_userCreateDto.Id, _userCreateDto.Name, _userCreateDto.Address);
        var retrievedUser = _usersRepository.GetById("An Id");
        retrievedUser.Should().BeEquivalentTo(expectedUser);
    }
}