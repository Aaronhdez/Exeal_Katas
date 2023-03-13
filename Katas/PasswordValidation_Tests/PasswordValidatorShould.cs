using FluentAssertions;
using PasswordValidation;

namespace PasswordValidation_Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Return_error_message_if_password_is_not_long_enough()
    {
        var passwordValidator = new PasswordValidator();
        var validationResults = string.Empty;
        
        var result = passwordValidator.Validate("asderfg", out validationResults);
        
        validationResults.Should().Be("Password must be al least 8 characters");
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_contain_at_least_two_numbers()
    {
        var passwordValidator = new PasswordValidator();
        var validationResults = string.Empty;

        var result = passwordValidator.Validate("gggg1jjaj", out validationResults);

        validationResults.Should().Be("The password must contain al least 2 numbers");
        result.Should().BeFalse();
    }
    
    [Test]
    public void Return_error_message_if_password_not_fulfill_the_conditions()
    {
        var passwordValidator = new PasswordValidator();
        var validationResults = string.Empty;

        var result = passwordValidator.Validate("abcd", out validationResults);

        validationResults.Should().Be("Password must be al least 8 characters\nThe password must contain al least 2 numbers");
        result.Should().BeFalse();
    }
    
    [Test]
    public void Return_error_message_if_password_not_fulfill_the_conditions_with_only_numbers()
    {
        var passwordValidator = new PasswordValidator();
        var validationResults = string.Empty;

        var result = passwordValidator.Validate("73763", out validationResults);

        validationResults.Should().Be("Password must be al least 8 characters");
        result.Should().BeFalse();
    }
}