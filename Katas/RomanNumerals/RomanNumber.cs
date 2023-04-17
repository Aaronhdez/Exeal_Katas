using System.Text.RegularExpressions;

namespace RomanNumerals;

public class RomanNumber
{
    private readonly string _value;
    private const string RomanNumeralFormat = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
    private readonly Dictionary<char, int> _intEquivalences = new()
    {
        { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 },
    };

    public RomanNumber(string value)
    {
        if (!FormatIsCorrect(value)) throw new InvalidDataException();
        _value = value;
    }

    public int ToDigit()
    {
        if (string.IsNullOrEmpty(_value)) return 0;
        return _value.Length == 1 ? ToInt(_value[0]) : AdditionOf(_value[0], _value[1..]);
    }

    private int AdditionOf(char currentChar, string remainingChars)
    {
        var firstRemainingChar = remainingChars[0];
        return remainingChars.Length == 1
            ? IsLowerThan(currentChar, firstRemainingChar)
                ? -ToInt(currentChar) + ToInt(firstRemainingChar)
                : ToInt(currentChar) + ToInt(firstRemainingChar)
            : IsLowerThan(currentChar, firstRemainingChar)
                ? -ToInt(currentChar) + AdditionOf(firstRemainingChar, remainingChars[1..])
                : ToInt(currentChar) + AdditionOf(firstRemainingChar, remainingChars[1..]);
    }

    private bool IsLowerThan(char currentChar, char nextChar) => ToInt(currentChar) < ToInt(nextChar);
    private int ToInt(char character) => _intEquivalences[character];
    private bool FormatIsCorrect(string romanNumber) => new Regex(RomanNumeralFormat).IsMatch(romanNumber);
}