using FluentAssertions;
using OrdersWebApi.Users;
using OrdersWebApi.Users.Repositories;

namespace OrdersWebApi.Tests.Users.Repositories; 

public class UsersRepositoryShould {
    private IUsersRepository _usersesRepository;

    
    [Test]
    public void RetrieveAUserIfExists() {
        _usersesRepository = new InMemoryUsersRepository();
        var expectedUser = new User("AnId", "A Name", "An Address");
        _usersesRepository.Create(expectedUser);
        
        var user = _usersesRepository.GetById("AnId");
        
        user.Should().BeEquivalentTo(expectedUser);
    }
    
    [Test]
    public void FailWhenAsUserDoesNotExist() {
        _usersesRepository = new InMemoryUsersRepository();
        
        var action = () => _usersesRepository.GetById("AnId");
        
        action.Should().Throw<ArgumentException>();
    }
}
