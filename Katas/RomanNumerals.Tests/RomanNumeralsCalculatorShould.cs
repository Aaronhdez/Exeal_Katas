using FluentAssertions;

namespace RomanNumerals.Tests;

public class Tests
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
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit(input);
        
        result.Should().Be(expectedResult);
    }
    
    [TestCase("X", 10)]
    [TestCase("XX", 20)]
    [TestCase("XXX", 30)]
    public void ReturnResultsForX(string input, int expectedResult)
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit(input);
        
        result.Should().Be(expectedResult);
    }

    [Test]
    public void ThrowExceptionWhenMoreThanThreeStrokesAreDisplayed()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = () => romanNumeralsCalculator.ToDigit("IIII");
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [Test]
    public void ReturnFiveForAV()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("V");
        
        result.Should().Be(5);
    }
    
    [Test]
    public void ThrowExceptionWhenMoreThanOneVIsDisplayed()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = () => romanNumeralsCalculator.ToDigit("VV");
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [Test]
    public void ThrowExceptionWhenMoreThanThreeXsAreDisplayed()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = () => romanNumeralsCalculator.ToDigit("XXXX");
        
        result.Should().Throw<InvalidDataException>();
    }
}