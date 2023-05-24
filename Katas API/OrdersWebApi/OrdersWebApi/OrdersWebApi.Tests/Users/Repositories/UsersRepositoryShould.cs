using FluentAssertions;
using OrdersWebApi.TestUtils;
using OrdersWebApi.TestUtils.Users;
using OrdersWebApi.Users;
using OrdersWebApi.Users.Repositories;

namespace OrdersWebApi.Tests.Users.Repositories;

public class UsersRepositoryShould {
    private IUsersRepository _usersRepository;

    [Test]
    public void RetrieveAUserIfExists() {
        _usersRepository = new InMemoryUsersRepository();
        var expectedUser = UsersMother.TestUser();
        _usersRepository.Create(expectedUser);
        
        var user = _usersRepository.GetById("AnId");
        
        user.Should().BeEquivalentTo(expectedUser);
    }

    [Test]
    public void FailWhenAsUserDoesNotExist() {
        _usersRepository = new InMemoryUsersRepository();
        
        var action = () => _usersRepository.GetById(UserDefaultValues.CustomerId);
        
        action.Should().Throw<ArgumentException>();
    }
}
