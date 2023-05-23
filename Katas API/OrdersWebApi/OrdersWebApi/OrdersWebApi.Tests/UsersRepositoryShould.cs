using FluentAssertions;

namespace OrdersWebApi.Tests; 

public class UsersRepositoryShould {
    private IUserRepository _usersRepository;

    [Test]
    public void RetrieveNullWhenAsUserDoesNotExist() {
        _usersRepository = new InMemoryUsersRepository();
        
        var user = _usersRepository.GetById("AnId");
        
        user.Should().BeNull();
    }
    
    [Test]
    public void RetrieveAUserIfExists() {
        _usersRepository = new InMemoryUsersRepository();
        var expectedUser = new User("AnId", "A Name", "An Address");
        _usersRepository.Create(expectedUser);
        
        var user = _usersRepository.GetById("AnId");
        
        user.Should().BeEquivalentTo(expectedUser);
    }
}