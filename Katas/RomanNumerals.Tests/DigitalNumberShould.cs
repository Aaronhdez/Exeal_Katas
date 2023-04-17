using FluentAssertions;

namespace RomanNumerals.Tests;

public class DigitalNumberShould
{
    private DigitalNumber _digitalNumber;

    [Test]
    public void ReturnAStrokeFor1()
    {
        _digitalNumber = new DigitalNumber("1");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("I");
    }
    
    [Test]
    public void ReturnTwoStrokesFor2()
    {
        _digitalNumber = new DigitalNumber("2");

        var result = _digitalNumber.ToRomanNumeral();

        result.Should().Be("II");
    }
}