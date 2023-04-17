using FluentAssertions;

namespace RomanNumerals.Tests;

public class RomanNumberValidatorShould
{
    [TestCase("IIII")]
    [TestCase("XXXX")]
    [TestCase("CCCC")]
    [TestCase("MMMM")]
    [TestCase("VV")]
    [TestCase("LL")]
    [TestCase("DD")]
    public void ThrowExceptionWhenValueProvidedIsNotValid(string input)
    {
        var result = () => new RomanNumber(input);
        
        result.Should().Throw<InvalidDataException>();
    }
}