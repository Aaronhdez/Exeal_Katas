using FluentAssertions;

namespace RomanNumerals.Tests;

public class DigitalNumberShould
{
    private DigitalNumber _digitalNumber;

    [TestCase("1", "I")]
    [TestCase("2", "II")]
    [TestCase("3", "III")]
    public void ReturnEquivalencesToStrokes(string input, string expectedResult)
    {
        _digitalNumber = new DigitalNumber(input);

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be(expectedResult);
    }

    [TestCase("4", "IV")]
    [TestCase("9", "IX")]
    [TestCase("40", "XL")]
    [TestCase("90", "XC")]
    [TestCase("400", "CD")]
    [TestCase("900", "CM")]
    public void ReturnEquivalencesToEdgeCombinations(string input, string expectedResult)
    {
        _digitalNumber = new DigitalNumber(input);

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be(expectedResult);
    }
    
    [TestCase("10", "X")]
    [TestCase("100", "C")]
    [TestCase("1000", "M")]
    public void ReturnEquivalencesToMutiplesOf10(string input, string expectedResult)
    {
        _digitalNumber = new DigitalNumber(input);

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be(expectedResult);
    }
    
    [TestCase("5", "V")]
    [TestCase("50", "L")]
    [TestCase("500", "D")]
    public void ReturnEquivalencesToMutiplesOf5(string input, string expectedResult)
    {
        _digitalNumber = new DigitalNumber(input);

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be(expectedResult);
    }
}