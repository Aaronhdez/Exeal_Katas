using FluentAssertions;
using OrdersWebApi.TestUtils.Users;
using OrdersWebApi.Users;

namespace OrdersWebApi.Tests.Users;

public class UserShould {
    private readonly UserDataShould _userDataShould = new UserDataShould();

    [Test]
    public void NotBeCreatedIfGuidIsNull() {
        var action = () => new User(null, new UserData(UserDefaultValues.CustomerName), new Address(UserDefaultValues.CustomerAddress));

        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void NotBeCreatedIfGuidIsEmpty() {
        var action = () => new User(string.Empty, new UserData(UserDefaultValues.CustomerName), new Address(UserDefaultValues.CustomerAddress));

        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void NotBeCreatedIfAddressIsNull() {
        var action = () => new User(UserDefaultValues.CustomerId, new UserData(UserDefaultValues.CustomerName), new Address(null));

        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void NotBeCreatedIfAddressIsEmpty() {
        var action = () => new User(UserDefaultValues.CustomerId, new UserData(UserDefaultValues.CustomerName), new Address(null));

        action.Should().Throw<ArgumentException>();
    }
}