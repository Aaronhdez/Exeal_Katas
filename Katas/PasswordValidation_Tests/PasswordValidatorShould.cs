using System.Text.RegularExpressions;
using FluentAssertions;

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
        
        var result = passwordValidator.Validate("asderfg");
        
        result.Should().Be("Password must be al least 8 characters");
    }

    [Test]
    public void Return_error_message_if_password_not_contain_at_least_two_numbers()
    {
        var passwordValidator = new PasswordValidator();

        var result = passwordValidator.Validate("gggg1jjaj");

        result.Should().Be("The password must contain al least 2 numbers");
    }
}

public class PasswordValidator
{
    public string Validate(string passwordToValidate)
    {
        if (passwordToValidate.Length < 8) return "Password must be al least 8 characters";
        string numbersInPassword = Regex.Replace(passwordToValidate, @"[^\d]", String.Empty); ;
        if (numbersInPassword.Length < 2) return "The password must contain al least 2 numbers";
        return "";
    }
}