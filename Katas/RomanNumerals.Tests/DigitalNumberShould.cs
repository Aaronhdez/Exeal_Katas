using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

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

    [Test]
    public void ReturnVForA5()
    {
        _digitalNumber = new DigitalNumber("5");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("V");
    }
    
    [Test]
    public void ReturnLFor50()
    {
        _digitalNumber = new DigitalNumber("50");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("L");
    }
    [Test]
    public void ReturnCFor500()
    {
        _digitalNumber = new DigitalNumber("500");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("C");
    }
}