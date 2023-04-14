namespace RomanNumerals;

public class RomanNumeralsCalculator
{
    public int ToDigit(string value)
    {
        if (!IsValid(value)) throw new InvalidDataException();
        return SumOfNumbers(value);
    }

    private int SumOfNumbers(string value)
    {
        if (string.IsNullOrEmpty(value)) return 0;
        return CurrentNumberToDigit(value[0]) + SumOfNumbers(value[1..]);
    }

    private static bool IsValid(string value)
    {
        if (value.Count(c => c == 'I') > 3) return false;
        if (value.Count(c => c == 'X') > 3) return false;
        if (value.Count(c => c == 'V') > 1) return false;
        return true;
    }

    private int CurrentNumberToDigit(char c)
    {
        if (c == 'V') return 5;
        if (c == 'X') return 10;
        return 1;
    }
}