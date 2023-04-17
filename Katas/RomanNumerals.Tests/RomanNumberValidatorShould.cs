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
    
    [TestCase("IIV")]
    [TestCase("IIIV")]
    [TestCase("IIX")]
    [TestCase("IIIX")]
    public void ThrowExceptionWhenFormatIsNotCorrect(string input)
    {
        var result = () => new RomanNumber(input);
        
        result.Should().Throw<InvalidDataException>();
    }

    [Test]
    public void ThrowExceptionForXXL()
    {
        var result = () => new RomanNumber("XXL");
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [Test]
    public void NotThrowExceptionForXL()
    {
        var result = () => new RomanNumber("XL");
        
        result.Should().NotThrow<InvalidDataException>();
    }
    
    
    [Test]
    public void NotThrowExceptionForXC()
    {
        var result = () => new RomanNumber("XC");
        
        result.Should().NotThrow<InvalidDataException>();
    }
}