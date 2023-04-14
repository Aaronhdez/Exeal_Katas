using FluentAssertions;

namespace RomanNumerals.Tests;

public class RomanNumberShould
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("I", 1)]
    [TestCase("II", 2)]
    [TestCase("III", 3)]
    public void ReturnResultsForStrokes(string input, int expectedResult)
    {
        var romanNumeralsCalculator = new RomanNumber(input);
        
        var result = romanNumeralsCalculator.ToDigit();
        
        result.Should().Be(expectedResult);
    }
    
    [TestCase("X", 10)]
    [TestCase("XX", 20)]
    [TestCase("XXX", 30)]
    public void ReturnResultsForX(string input, int expectedResult)
    {
        var romanNumeralsCalculator = new RomanNumber(input);
        
        var result = romanNumeralsCalculator.ToDigit();
        
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void ReturnFiveForAV()
    {
        var romanNumeralsCalculator = new RomanNumber("V");
        
        var result = romanNumeralsCalculator.ToDigit();
        
        result.Should().Be(5);
    }

    [Test]
    public void ThrowExceptionWhenMoreThanThreeStrokesAreDisplayed()
    {
        var romanNumeralsCalculator = new RomanNumber("IIII");
        
        var result = () => romanNumeralsCalculator.ToDigit();
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [Test]
    public void ThrowExceptionWhenMoreThanOneVIsDisplayed()
    {
        var romanNumeralsCalculator = new RomanNumber("VV");
        
        var result = () => romanNumeralsCalculator.ToDigit();
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [Test]
    public void ThrowExceptionWhenMoreThanThreeXsAreDisplayed()
    {
        var romanNumeralsCalculator = new RomanNumber("XXXX");
        
        var result = () => romanNumeralsCalculator.ToDigit();
        
        result.Should().Throw<InvalidDataException>();
    }
}