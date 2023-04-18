using FluentAssertions;

namespace RomanNumerals.Tests;

public class NumberConverterShould
{
    [TestCase(2023, "MMXXIII")]
    [TestCase(2024, "MMXXIV")]
    [TestCase(1924, "MCMXXIV")]
    public void ReturnRomanValueForIntegers(int number, string expectedConversion)
    {
        var result = NumberConverter.ToRomanNumeral(number);
        
        result.Should().Be(expectedConversion);
    }
}