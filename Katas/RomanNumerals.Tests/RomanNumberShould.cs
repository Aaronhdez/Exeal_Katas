using FluentAssertions;

namespace RomanNumerals.Tests;

public class RomanNumberShould
{
    private RomanNumber _romanNumber;

    [TestCase("I", 1)]
    [TestCase("II", 2)]
    [TestCase("III", 3)]
    [TestCase("X", 10)]
    [TestCase("XX", 20)]
    [TestCase("XXX", 30)]
    [TestCase("C", 100)]
    [TestCase("CC", 200)]
    [TestCase("CCC", 300)]
    [TestCase("M", 1000)]
    [TestCase("MM", 2000)]
    [TestCase("MMM", 3000)]
    public void ReturnResultsForMultiplesOf10(string input, int expectedResult)
    {
        _romanNumber = new RomanNumber(input);

        var result = _romanNumber.ToDigit();

        result.Should().Be(expectedResult);
    }

    [TestCase("V", 5)]
    [TestCase("L", 50)]
    [TestCase("D", 500)]
    public void ReturnResultsForMultiplesOf5(string input, int expectedResult)
    {
        _romanNumber = new RomanNumber(input);

        var result = _romanNumber.ToDigit();

        result.Should().Be(expectedResult);
    }

    [TestCase("VI", 6)]
    [TestCase("VII", 7)]
    [TestCase("VIII", 8)]
    public void ReturnAdditionOfCharacters(string input, int expectedResult)
    {
        _romanNumber = new RomanNumber(input);

        var result = _romanNumber.ToDigit();

        result.Should().Be(expectedResult);
    }

    [TestCase("IV", 4)]
    [TestCase("IX", 9)]
    [TestCase("XC", 90)]
    public void ReturnSubstractionOfCharacters(string input, int expectedResult)
    {
        _romanNumber = new RomanNumber(input);

        var result = _romanNumber.ToDigit();

        result.Should().Be(expectedResult);
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
    public static void ThrowExceptionWhenInputIsNotValid(string input)
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
    public static void NotThrowExceptionWhenInputIsValid(string input)
    {
        var result = () => new RomanNumber(input);

        result.Should().NotThrow<InvalidDataException>();
    }
}