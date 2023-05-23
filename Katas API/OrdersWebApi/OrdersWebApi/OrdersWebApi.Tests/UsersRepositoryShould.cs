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
}