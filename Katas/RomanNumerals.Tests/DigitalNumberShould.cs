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

    [Test]
    public void ReturnIVForA4()
    {
        _digitalNumber = new DigitalNumber("4");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("IV");
    }
    

    [Test]
    public void ReturnVForA5()
    {
        _digitalNumber = new DigitalNumber("5");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("V");
    }
    
    [Test]
    public void ReturnIXForA9()
    {
        _digitalNumber = new DigitalNumber("9");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("IX");
    }
    
    [Test]
    public void ReturnXFor10()
    {
        _digitalNumber = new DigitalNumber("10");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("X");
    }
}