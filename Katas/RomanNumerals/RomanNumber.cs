using System.Text.RegularExpressions;

namespace RomanNumerals;

public class RomanNumber
{
    private readonly string _value;

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
        return SumOfNumbers(_value);
    }

    private int SumOfNumbers(string value)
    {
        if (value == "IV") return 4;
        if (value == "IX") return 9;
        if (value == "XC") return 90;
        if (string.IsNullOrEmpty(value)) return 0;
        return ToInt(value[0]) + SumOfNumbers(value[1..]);
    }

    private int ToInt(char character)
    {
        return _intEquivalences[character];
    }

    private bool FormatIsCorrect(string romanNumber)
    {
        var romanNumeralFormat = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        return new Regex(romanNumeralFormat).IsMatch(romanNumber);
    }
}