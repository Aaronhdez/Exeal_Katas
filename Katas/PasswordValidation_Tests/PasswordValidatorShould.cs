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

    [TestCase("Abcd",false)]
    [TestCase("Abcde",false)]
    [TestCase("Abcdef",false)]
    public void Return_error_message_if_password_not_fulfill_the_conditions(string input, bool expectedResult)
    {
        var result = _passwordValidator.Validate(input, out _validationResults);

        _validationResults.Should()
            .Be($"{NotEnoughCharactersError}" +
                $"\n{NotEnoughNumbersError}");
        result.Should().Be(expectedResult);
    }

    [Test]
    public void Return_false_for_abcdef12()
    {
        var result = _passwordValidator.Validate("abcdef12", out _validationResults);
        
        result.Should().BeFalse();
        _validationResults.Should().Be(NotEnoughCapitalsError);
    }

    [Test]
    public void Return_false_for_bcdefg12()
    {
        var result = _passwordValidator.Validate("bcdefg12", out _validationResults);
        
        result.Should().BeFalse();
        _validationResults.Should().Be(NotEnoughCapitalsError);
    }

    [Test]
    public void Return_false_for_cdefgh12()
    {
        var result = _passwordValidator.Validate("cdefgh12", out _validationResults);
        
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
    
    [Test]
    public void Return_true_for_Abcde123()
    {
        var result = _passwordValidator.Validate("Abcde123", out _validationResults);
        
        result.Should().BeTrue(); 
        _validationResults.Should()
            .Be($"Valid Password");
    }
    
    [Test]
    public void Return_true_for_Bcdef123()
    {
        var result = _passwordValidator.Validate("Bcdef123", out _validationResults);
        
        result.Should().BeTrue(); 
        _validationResults.Should()
            .Be($"Valid Password");
    }
    
    [Test]
    public void Return_true_for_cdEfg323()
    {
        var result = _passwordValidator.Validate("cdEfg323", out _validationResults);
        
        result.Should().BeTrue(); 
        _validationResults.Should()
            .Be($"Valid Password");
    }
}