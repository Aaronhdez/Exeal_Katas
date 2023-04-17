using System.Text.RegularExpressions;

namespace RomanNumerals;

public class RomanNumberValidator
{
    public bool Validate(string romanNumber)
    {
        return FormatIsCorrect(romanNumber);
    }

    private static bool FormatIsCorrect(string romanNumber)
    {
        var romanNumeralFormat = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        return new Regex(romanNumeralFormat).IsMatch(romanNumber);
    }
}