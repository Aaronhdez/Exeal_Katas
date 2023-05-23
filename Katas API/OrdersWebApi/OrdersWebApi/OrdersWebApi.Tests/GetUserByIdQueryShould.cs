using FluentAssertions;
using NSubstitute;

namespace OrdersWebApi.Tests; 

public class GetUserByIdQueryShould {
    private InMemoryUsersRepository _usersRepository;

    [Test]
    public async Task RetrieveAnExistentUser() {
        _usersRepository = new InMemoryUsersRepository();
        var existentUser = new User("An Id", "A Name", "An Address");
        _usersRepository.Create(existentUser);
        var handler = new GetUserByIdQueryHandler(_usersRepository);

        var retrievedUser = await handler.Handle(new GetUserByIdQuery("An Id"), default);

        var expectedUser = new ReadUserDto(existentUser.Id, existentUser.Name, existentUser.Address);
        retrievedUser.Should().BeEquivalentTo(expectedUser);
    }
}