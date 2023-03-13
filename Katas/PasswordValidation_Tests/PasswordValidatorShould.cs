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
}

public class PasswordValidator
{
    public string Validate(string passwordToValidate)
    {
        if (passwordToValidate.Length < 8) return "Password must be al least 8 characters";
        return "";
    }
}