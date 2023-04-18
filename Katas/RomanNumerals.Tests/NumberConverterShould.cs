using FluentAssertions;

namespace RomanNumerals.Tests;

public class NumberConverterShould
{
    [Test]
    public void ReturnRomanValueForAnInteger()
    {
        var result = NumberConverter.ToRomanNumeral(2023);
        
        result.Should().Be("MMXXIII");
    }
    
    [Test]
    public void ReturnRomanValueForOtherInteger()
    {
        var result = NumberConverter.ToRomanNumeral(2024);
        
        result.Should().Be("MMXXIV");
    }
    
    [Test]
    public void ReturnRomanValueForAnotherInteger()
    {
        var result = NumberConverter.ToRomanNumeral(1924);
        
        result.Should().Be("MCMXXIV");
    }
}