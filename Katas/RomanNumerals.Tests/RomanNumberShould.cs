using FluentAssertions;

namespace RomanNumerals.Tests;

public class RomanNumberShould
{
    private RomanNumber _romanNumber;

    [SetUp]
    public void Setup()
    {
    }

    [TestCase("I", 1)]
    [TestCase("II", 2)]
    [TestCase("III", 3)]
    public void ReturnResultsForStrokes(string input, int expectedResult)
    {
        _romanNumber = new RomanNumber(input);
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(expectedResult);
    }
    
    [TestCase("X", 10)]
    [TestCase("XX", 20)]
    [TestCase("XXX", 30)]
    public void ReturnResultsForX(string input, int expectedResult)
    {
        _romanNumber = new RomanNumber(input);
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void ReturnFiveForAV()
    {
        _romanNumber = new RomanNumber("V");
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(5);
    }
    
    [Test]
    public void Return50ForAL()
    {
        _romanNumber = new RomanNumber("L");
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(50);
    }

    [Test]
    public void ThrowExceptionWhenMoreThanThreeStrokesAreDisplayed()
    {
        _romanNumber = new RomanNumber("IIII");
        
        var result = () => _romanNumber.ToDigit();
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [Test]
    public void ThrowExceptionWhenMoreThanOneVIsDisplayed()
    {
        _romanNumber = new RomanNumber("VV");
        
        var result = () => _romanNumber.ToDigit();
        
        result.Should().Throw<InvalidDataException>();
    }
    
    [Test]
    public void ThrowExceptionWhenMoreThanThreeXsAreDisplayed()
    {
        _romanNumber = new RomanNumber("XXXX");
        
        var result = () => _romanNumber.ToDigit();
        
        result.Should().Throw<InvalidDataException>();
    }
}