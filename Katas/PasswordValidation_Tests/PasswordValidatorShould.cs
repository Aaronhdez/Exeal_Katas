using FluentAssertions;
using PasswordValidation;

namespace PasswordValidation_Tests;

public class Tests
{
    private readonly PasswordValidator _passwordValidator = new PasswordValidator();
    private string _validationResults;
    private const string NotEnoughCharactersError = "Password must be at least 8 characters";
    private const string NotEnoughNumbersError = "Password must contain at least 2 numbers";
    private const string NotEnoughCapitalsError = "Password must contain al least one capital letter";
    private const string ValidPasswordMessage = "Valid Password";

    [SetUp]
    public void Setup()
    {
        _validationResults = string.Empty;
    }

    [Test]
    public void Return_error_message_if_password_is_not_long_enough()
    {
        var result = _passwordValidator.Validate("A32erfg", out _validationResults);

        _validationResults.Should().Be(NotEnoughCharactersError);
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_contain_at_least_two_numbers()
    {
        var result = _passwordValidator.Validate("Gggg1jjaj", out _validationResults);

        _validationResults.Should().Be(NotEnoughNumbersError);
        result.Should().BeFalse();
    }

    [Test]
    public void Return_error_message_if_password_not_fulfill_the_conditions_with_only_numbers()
    {
        var result = _passwordValidator.Validate("G73763", out _validationResults);

        _validationResults.Should().Be(NotEnoughCharactersError);
        result.Should().BeFalse();
    }

    [TestCase("Abcd", false)]
    [TestCase("Abcde", false)]
    [TestCase("Abcdef", false)]
    public void Return_error_message_if_password_not_fulfill_the_conditions(string input, bool expectedResult)
    {
        var result = _passwordValidator.Validate(input, out _validationResults);

        _validationResults.Should()
            .Be($"{NotEnoughCharactersError}" +
                $"\n{NotEnoughNumbersError}");
        result.Should().Be(expectedResult);
    }

    [TestCase("abcdef12", false)]
    [TestCase("bcdefg12", false)]
    [TestCase("cdefgh12", false)]
    public void Return_not_enough_capitals_error_when_not_enough_capitals_are_provided(string input, bool expectedResult)
    {
        var result = _passwordValidator.Validate(input, out _validationResults);
        
        result.Should().BeFalse();
        _validationResults.Should().Be(NotEnoughCapitalsError);
    }

    [Test]
    public void Return_false_for_cdefgh1()
    {
        var result = _passwordValidator.Validate("cdefgh1", out _validationResults);

        result.Should().BeFalse();
        _validationResults.Should()
            .Be($"{NotEnoughCharactersError}" +
                $"\n{NotEnoughNumbersError}" +
                $"\n{NotEnoughCapitalsError}");
    }

    [TestCase("Abcde123", true)]
    [TestCase("Bcdef123", true)]
    [TestCase("cdEfg323", true)]
    public void Return_true_if_password_requirements_are_met(string input, bool expectedResult)
    {
        var result = _passwordValidator.Validate(input, out _validationResults);
        
        result.Should().BeTrue();
        _validationResults.Should().Be($"{ValidPasswordMessage}");
    }
}