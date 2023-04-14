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
        if (!ValidMultipleOf10(value)) return false;
        if (value.Count(c => c == 'V') > 1) return false;
        if (value.Count(c => c == 'L') > 1) return false;
        return true;
    }

    private static bool ValidMultipleOf10(string value)
    {
        if (value.Count(c => c == 'I') > 3) return false;
        if (value.Count(c => c == 'X') > 3) return false;
        if (value.Count(c => c == 'C') > 3) return false;
        return true;
    }

    private int SumOfNumbers(string value)
    {
        if (string.IsNullOrEmpty(value)) return 0;
        return ToInt(value[0]) + SumOfNumbers(value[1..]);
    }

    private int ToInt(char character)
    {
        if (character == 'V') return 5;
        if (character == 'X') return 10;
        if (character == 'L') return 50;        
        if (character == 'C') return 100;
        if (character == 'D') return 500;
        return 1;
    }
}