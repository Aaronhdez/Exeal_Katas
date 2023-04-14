namespace RomanNumerals;

public class RomanNumeralsCalculator
{
    public int ToDigit(string romanNumber)
    {
        return SumOfNumbers(romanNumber);
    }

    private int SumOfNumbers(string romanNumber)
    {
        if (string.IsNullOrEmpty(romanNumber)) return 0;
        if (romanNumber == "IIII") throw new InvalidDataException();
        if (romanNumber == "VV") throw new InvalidDataException();
        return CurrentNumberToDigit(romanNumber[0]) + SumOfNumbers(romanNumber[1..]);
    }

    private int CurrentNumberToDigit(char c)
    {
        if (c == 'V') return 5;
        if (c == 'X') return 10;
        return 1;
    }
}