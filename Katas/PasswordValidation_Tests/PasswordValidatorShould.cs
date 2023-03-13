using FluentAssertions;
using PasswordValidation;

namespace PasswordValidation_Tests;

public class Tests
{
    private readonly PasswordValidator _passwordValidator = new PasswordValidator();
    private string _validationResults;

    [SetUp]
    public void Setup()
    {
        _validationResults = string.Empty;
    }

    [Test]
    public void Return_error_message_if_password_is_not_long_enough()
    {
        var result = _passwordValidator.Validate("asderfg", out _validationResults);

        _validationResults.Should().Be("Password must be al least 8 characters");
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_contain_at_least_two_numbers()
    {
        var result = _passwordValidator.Validate("gggg1jjaj", out _validationResults);

        _validationResults.Should().Be("The password must contain al least 2 numbers");
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_fulfill_the_conditions()
    {
        var result = _passwordValidator.Validate("abcd", out _validationResults);

        _validationResults.Should()
            .Be("Password must be al least 8 characters\nThe password must contain al least 2 numbers");
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_fulfill_the_conditions_with_only_numbers()
    {
        var result = _passwordValidator.Validate("73763", out _validationResults);

        _validationResults.Should().Be("Password must be al least 8 characters");
        result.Should().BeFalse();
    }
}