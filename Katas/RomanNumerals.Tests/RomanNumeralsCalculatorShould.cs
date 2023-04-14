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
    public void ReturnTwoForTwoStrokes()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("II");
        
        result.Should().Be(2);
    }

    [Test]
    public void ReturnThreeForThreeStrokes()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("III");
        
        result.Should().Be(3);
    }
    
    [Test]
    public void ReturnFiveForAV()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("V");
        
        result.Should().Be(5);
    }
    

    [Test]
    public void ThrowExceptionWhenMoreThanThreeStrokesAreDisplayed()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = () => romanNumeralsCalculator.ToDigit("IIII");
        
        result.Should().Throw<InvalidDataException>();
    }
}