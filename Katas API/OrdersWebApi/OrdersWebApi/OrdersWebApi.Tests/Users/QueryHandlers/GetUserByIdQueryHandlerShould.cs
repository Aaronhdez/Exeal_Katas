using FluentAssertions;
using OrdersWebApi.Users;
using OrdersWebApi.Users.Queries;
using OrdersWebApi.Users.Repositories;

namespace OrdersWebApi.Tests.Users.QueryHandlers;

public class GetUserByIdQueryHandlerShould {
    private InMemoryUsersRepository _usersRepository;
    private User _existentUser;

    [SetUp]
    public void SetUp() {
        _existentUser = UsersMother.TestUser();
        _usersRepository = new InMemoryUsersRepository();
        _usersRepository.Create(_existentUser);
    }

    [Test]
    public async Task RetrieveAnExistentUser() {
        var handler = new GetUserByIdQueryHandler(_usersRepository);

        var retrievedUser = await handler.Handle(new GetUserByIdQuery(_existentUser.Id), default);

        retrievedUser.Should().BeEquivalentTo(UsersMother.TestReadCustomerDto());
    }
}