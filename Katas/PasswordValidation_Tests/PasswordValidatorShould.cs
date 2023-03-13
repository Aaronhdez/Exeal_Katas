using FluentAssertions;
using PasswordValidation;

namespace PasswordValidation_Tests;

public class Tests
{
    private readonly PasswordValidator _passwordValidator = new PasswordValidator();
    private string _validationResults;
    private const string ErrorPasswordMustBeAlLeastEightCharacters = "Password must be at least 8 characters";
    private const string ErrorPasswordMustContainAlLeastTwoNumbers = "Password must contain at least 2 numbers";

    [SetUp]
    public void Setup()
    {
        _validationResults = string.Empty;
    }

    [Test]
    public void Return_error_message_if_password_is_not_long_enough()
    {
        var result = _passwordValidator.Validate("a32erfg", out _validationResults);

        _validationResults.Should().Be(ErrorPasswordMustBeAlLeastEightCharacters);
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_contain_at_least_two_numbers()
    {
        var result = _passwordValidator.Validate("gggg1jjaj", out _validationResults);

        _validationResults.Should().Be(ErrorPasswordMustContainAlLeastTwoNumbers);
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_fulfill_the_conditions_with_only_numbers()
    {
        var result = _passwordValidator.Validate("73763", out _validationResults);

        _validationResults.Should().Be(ErrorPasswordMustBeAlLeastEightCharacters);
        result.Should().BeFalse();
    }

    [TestCase("abcd",false)]
    [TestCase("abcde",false)]
    [TestCase("abcdef",false)]
    public void Return_error_message_if_password_not_fulfill_the_conditions(string input, bool expectedResult)
    {
        var result = _passwordValidator.Validate(input, out _validationResults);

        _validationResults.Should()
            .Be($"{ErrorPasswordMustBeAlLeastEightCharacters}\n{ErrorPasswordMustContainAlLeastTwoNumbers}");
        result.Should().Be(expectedResult);
    }
}