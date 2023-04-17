using FluentAssertions;

namespace RomanNumerals.Tests;

public class RomanNumberValidatorShould
{
    
    [TestCase("IIII")]
    [TestCase("XXXX")]
    [TestCase("CCCC")]
    [TestCase("MMMM")]
    public void ThrowExceptionWhenAMultipleOf10IsRepeatedMoreThanThrice(string input)
    {
        var result = () => new RomanNumber(input);
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [TestCase("VV")]
    [TestCase("LL")]
    [TestCase("DD")]
    public void ThrowExceptionWhenAMultipleOf5IsRepeatedMoreThanOnce(string input)
    {
        var result = () => new RomanNumber(input);
        
        result.Should().Throw<InvalidDataException>();
    }

    [Test]
    public void ThrowExceptionForIIV()
    {
        var result = () => new RomanNumber("IIV");
        
        result.Should().Throw<InvalidDataException>();
    }

    [Test]
    public void ThrowExceptionForIIIV()
    {
        var result = () => new RomanNumber("IIIV");
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [Test]
    public void ThrowExceptionForIIX()
    {
        var result = () => new RomanNumber("IIX");
        
        result.Should().Throw<InvalidDataException>();
    }
}