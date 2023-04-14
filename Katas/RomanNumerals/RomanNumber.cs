namespace RomanNumerals;

public class RomanNumber
{
    private readonly string _value;

    private Dictionary<char, int> _intEquivalences = new()
    {
        { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 },
    };

    public RomanNumber(string value)
    {
        _value = value;
    }

    public int ToDigit()
    {
        if (!IsValid(_value)) throw new InvalidDataException();
        return SumOfNumbers(_value);
    }

    private bool IsValid(string value)
    {
        if (!ValidMultipleOf10(value)) return false;
        if (!ValidMultipleOf5(value)) return false;
        return true;
    }

    private static bool ValidMultipleOf5(string value)
    {
        return value.Count(c => c == 'V') <= 1 && value.Count(c => c == 'L') <= 1 && value.Count(c => c == 'D') <= 1;
    }

    private static bool ValidMultipleOf10(string value)
    {
        return value.Count(c => c == 'I') <= 3 && value.Count(c => c == 'X') <= 3 && value.Count(c => c == 'C') <= 3;
    }

    private int SumOfNumbers(string value)
    {
        if (string.IsNullOrEmpty(value)) return 0;
        return ToInt(value[0]) + SumOfNumbers(value[1..]);
    }

    private int ToInt(char character)
    {
        return _intEquivalences[character];
    }
}