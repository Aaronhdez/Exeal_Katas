namespace RomanNumerals;

public class RomanNumber
{
    private readonly string _value;

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
        if (value.Count(c => c == 'I') > 3) return false;
        if (value.Count(c => c == 'X') > 3) return false;
        if (value.Count(c => c == 'V') > 1) return false;
        if (value.Count(c => c == 'L') > 1) return false;
        return true;
    }

    private int SumOfNumbers(string value)
    {
        if (string.IsNullOrEmpty(value)) return 0;
        return CurrentNumberToDigit(value[0]) + SumOfNumbers(value[1..]);
    }

    private int CurrentNumberToDigit(char c)
    {
        if (c == 'V') return 5;
        if (c == 'X') return 10;
        if (c == 'L') return 50;        
        if (c == 'C') return 100;
        return 1;
    }
}