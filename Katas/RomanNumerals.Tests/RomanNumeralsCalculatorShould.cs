using FluentAssertions;

namespace RomanNumerals.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ReturnOneForAStroke()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("I");
        
        result.Should().Be(1);
    }

    [Test]
    public void ReturnTwoForTwoStroke()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("II");
        
        result.Should().Be(2);
    }
}