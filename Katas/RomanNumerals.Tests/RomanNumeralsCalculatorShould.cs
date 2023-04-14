using FluentAssertions;

namespace RomanNumerals.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("I", 1)]
    [TestCase("II", 1)]
    [TestCase("III", 1)]
    public void ReturnOneForAStroke(string input, int expectedResult)
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
    public void ReturnTenForAX()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("X");
        
        result.Should().Be(10);
    }
    
    [Test]
    public void ReturnTenForTwoX()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("XX");
        
        result.Should().Be(20);
    }
    
    [Test]
    public void ReturnTenForThreeX()
    {
        var romanNumeralsCalculator = new RomanNumeralsCalculator();
        
        var result = romanNumeralsCalculator.ToDigit("XX");
        
        result.Should().Be(20);
    }
}