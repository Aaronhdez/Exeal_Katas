using FluentAssertions;
using OrdersWebApi.Users;

namespace OrdersWebApi.Tests.Users; 

public class UserShould {

    [Test]
    public void NotBeCreatedIfGuidIsNull() {
        var action = () => new User(null, "A User", "An Address");

        action.Should().Throw<ArgumentException>();
    }
    
    [Test]
    public void NotBeCreatedIfGuidIsEmpty() {
        var action = () => new User("", "A User", "An Address");

        action.Should().Throw<ArgumentException>();
    }
}