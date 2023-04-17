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
}