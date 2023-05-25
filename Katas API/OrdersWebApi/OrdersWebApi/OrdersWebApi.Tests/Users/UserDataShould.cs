﻿using FluentAssertions;
using OrdersWebApi.TestUtils.Users;
using OrdersWebApi.Users;

namespace OrdersWebApi.Tests.Users;

public class UserDataShould {
    [Test]
    public void NotBeCreatedIfNameIsNull() {
        var action = () => new User(UserDefaultValues.CustomerId, new UserData(null), new Address(UserDefaultValues.CustomerAddress));

        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void NotBeCreatedIfNameIsEmpty() {
        var action = () => new User(UserDefaultValues.CustomerId, new UserData(string.Empty), new Address(UserDefaultValues.CustomerAddress));

        action.Should().Throw<ArgumentException>();
    }
}