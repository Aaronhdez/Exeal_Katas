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
    public void ReturnEquivalencesToEdgeCombinations(string input, string expectedResult)
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
    public void ReturnXFor10()
    {
        _digitalNumber = new DigitalNumber("10");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("X");
    }
    
    [Test]
    public void ReturnLFor50()
    {
        _digitalNumber = new DigitalNumber("50");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("L");
    }
    
    [Test]
    public void ReturnCFor100()
    {
        _digitalNumber = new DigitalNumber("100");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("C");
    }
    
    [Test]
    public void ReturnCDFor400()
    {
        _digitalNumber = new DigitalNumber("400");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("CD");
    }
}