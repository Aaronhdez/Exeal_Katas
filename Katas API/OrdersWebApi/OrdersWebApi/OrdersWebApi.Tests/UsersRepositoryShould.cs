using FluentAssertions;

namespace OrdersWebApi.Tests; 

public class UsersRepositoryShould {
    private IUserRepository _usersRepository;

    
    [Test]
    public void RetrieveAUserIfExists() {
        _usersRepository = new InMemoryUsersRepository();
        var expectedUser = new User("AnId", "A Name", "An Address");
        _usersRepository.Create(expectedUser);
        
        var user = _usersRepository.GetById("AnId");
        
        user.Should().BeEquivalentTo(expectedUser);
    }
    
    [Test]
    public void FailWhenAsUserDoesNotExist() {
        _usersRepository = new InMemoryUsersRepository();
        
        var action = () => _usersRepository.GetById("AnId");
        
        action.Should().Throw<ArgumentException>();
    }
}
