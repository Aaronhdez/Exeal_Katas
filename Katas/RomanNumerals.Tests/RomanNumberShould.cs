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

    [TestCase("C", 100)]
    [TestCase("CC", 200)]
    [TestCase("CCC", 300)]
    public void ReturnResultsForC(string input, int expectedResult)
    {
        _romanNumber = new RomanNumber(input);
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(expectedResult);
    }
    
    [TestCase("M", 1000)]
    [TestCase("MM", 2000)]
    [TestCase("MMM", 3000)]
    public void ReturnResultsForAM(string input, int expectedResult)
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
    public void Return500ForAD()
    {
        _romanNumber = new RomanNumber("D");
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(500);
    }
    
    
    [TestCase("VI", 6)]
    [TestCase("VII", 7)]
    [TestCase("VIII", 8)]
    public void ReturnSumOfCharacters(string input, int expectedResult)
    {
        _romanNumber = new RomanNumber(input);
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(expectedResult);
    }
    
    [Test]
    public void Return9ForIX()
    {
        _romanNumber = new RomanNumber("IX");
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(9);
    }
    
    [Test]
    public void Return90ForXC()
    {
        _romanNumber = new RomanNumber("XC");
        
        var result = _romanNumber.ToDigit();
        
        result.Should().Be(90);
    }

    [TestCase("IIII")]
    [TestCase("XXXX")]
    [TestCase("CCCC")]
    [TestCase("MMMM")]
    [TestCase("VV")]
    [TestCase("LL")]
    [TestCase("DD")]
    [TestCase("IIV")]
    [TestCase("IIIV")]
    [TestCase("IIX")]
    [TestCase("IIIX")]
    [TestCase("XXL")]
    public static void ThrowExceptionWhenFormatIsNotCorrect(string input)
    {
        var result = () => new RomanNumber(input);
        
        result.Should().Throw<InvalidDataException>();
    }

    [TestCase("IV")]
    [TestCase("IX")]
    [TestCase("XL")]
    [TestCase("XC")]
    [TestCase("CD")]
    [TestCase("CM")]
    public static void NotThrowExceptionWhenFormatIsCorrect(string input)
    {
        var result = () => new RomanNumber(input);
        
        result.Should().NotThrow<InvalidDataException>();
    }
}