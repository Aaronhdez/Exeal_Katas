using FluentAssertions;
using PasswordValidation;

namespace PasswordValidation_Tests;

public class Tests
{
    private readonly PasswordValidator _passwordValidator = new PasswordValidator();
    private string _validationResults;
    private const string ErrorPasswordMustBeAlLeastEightCharacters = "Password must be at least 8 characters";
    private const string ErrorPasswordMustContainAlLeastTwoNumbers = "Password must contain at least 2 numbers";
    private const string ErrorPasswordMustContainAtLeastACapitalLetter = "Password must contain al least one capital letter";

    [SetUp]
    public void Setup()
    {
        _validationResults = string.Empty;
    }

    [Test]
    public void Return_error_message_if_password_is_not_long_enough()
    {
        var result = _passwordValidator.Validate("A32erfg", out _validationResults);

        _validationResults.Should().Be(ErrorPasswordMustBeAlLeastEightCharacters);
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_contain_at_least_two_numbers()
    {
        var result = _passwordValidator.Validate("Gggg1jjaj", out _validationResults);

        _validationResults.Should().Be(ErrorPasswordMustContainAlLeastTwoNumbers);
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_fulfill_the_conditions_with_only_numbers()
    {
        var result = _passwordValidator.Validate("G73763", out _validationResults);

        _validationResults.Should().Be(ErrorPasswordMustBeAlLeastEightCharacters);
        result.Should().BeFalse();
    }

    [TestCase("Abcd",false)]
    [TestCase("Abcde",false)]
    [TestCase("Abcdef",false)]
    public void Return_error_message_if_password_not_fulfill_the_conditions(string input, bool expectedResult)
    {
        var result = _passwordValidator.Validate(input, out _validationResults);

        _validationResults.Should()
            .Be($"{ErrorPasswordMustBeAlLeastEightCharacters}\n{ErrorPasswordMustContainAlLeastTwoNumbers}");
        result.Should().Be(expectedResult);
    }

    [Test]
    public void Return_false_for_abcdef12()
    {
        var result = _passwordValidator.Validate("abcdef12", out _validationResults);
        
        result.Should().BeFalse();
        _validationResults.Should().Be(ErrorPasswordMustContainAtLeastACapitalLetter);
    }

    [Test]
    public void Return_false_for_bcdefg12()
    {
        var result = _passwordValidator.Validate("bcdefg12", out _validationResults);
        
        result.Should().BeFalse();
        _validationResults.Should().Be(ErrorPasswordMustContainAtLeastACapitalLetter);
    }
}