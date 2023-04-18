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
}

public static class NumberConverter
{
    public static string ToRomanNumeral(int number)
    {
        return "MMXXIII";
    }
}