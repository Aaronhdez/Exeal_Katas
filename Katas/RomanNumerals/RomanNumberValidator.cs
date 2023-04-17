using System.Text.RegularExpressions;

namespace RomanNumerals;

public class RomanNumberValidator
{
    private readonly char[] _multiplesOf5 = { 'V', 'L', 'D' };
    private readonly char[] _multiplesOf10 = { 'I', 'X', 'C', 'M' };

    public bool Validate(string romanNumber)
    {
        return OrderIsCorrect(romanNumber);
    }

    private static bool OrderIsCorrect(string romanNumber)
    {
        var romanNumeralFormat = @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";
        return new Regex(romanNumeralFormat).IsMatch(romanNumber);
    }

    private bool ValidAmountsOfMultiplesOf5(string romanNumber)
    {
        return _multiplesOf5.Where(romanNumber.Contains)
            .All(character => romanNumber.Count(c => c == character) <= 1);
    }

    private bool ValidAmountsOfMultiplesOf10(string romanNumber)
    {
        return _multiplesOf10.Where(romanNumber.Contains)
            .All(character => romanNumber.Count(c => c == character) <= 3);
    }
}