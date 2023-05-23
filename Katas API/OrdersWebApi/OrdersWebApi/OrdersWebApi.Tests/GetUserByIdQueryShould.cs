using FluentAssertions;
using NSubstitute;

namespace OrdersWebApi.Tests;

public class GetUserByIdQueryShould {
    private InMemoryUsersRepository _usersRepository;
    private User _existentUser;

    [SetUp]
    public void SetUp() {
        _existentUser = new User("An Id", "A Name", "An Address");
        _usersRepository = new InMemoryUsersRepository();
        _usersRepository.Create(_existentUser);
    }

    [Test]
    public async Task RetrieveAnExistentUser() {
        var handler = new GetUserByIdQueryHandler(_usersRepository);

        var retrievedUser = await handler.Handle(new GetUserByIdQuery(_existentUser.Id), default);

        var expectedUser = new ReadUserDto(_existentUser.Id, _existentUser.Name, _existentUser.Address);
        retrievedUser.Should().BeEquivalentTo(expectedUser);
    }
}