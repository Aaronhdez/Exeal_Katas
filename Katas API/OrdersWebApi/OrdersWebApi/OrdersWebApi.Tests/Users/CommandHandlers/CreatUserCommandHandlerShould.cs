using FluentAssertions;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Users;
using OrdersWebApi.Users;
using OrdersWebApi.Users.Commands;
using OrdersWebApi.Users.Repositories;

namespace OrdersWebApi.Tests.Users.CommandHandlers; 

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
        _userCreateDto = UsersMother.TestCreateCustomerDto();
        
        _handler.Handle(new CreateUserCommand(_userCreateDto), default);

        var expectedUser = new User(_userCreateDto.Id, new UserData(_userCreateDto.Name), new Address(_userCreateDto.Address));
        expectedUser.Should().BeEquivalentTo(_usersRepository.GetById(UserDefaultValues.CustomerId));
    }
}