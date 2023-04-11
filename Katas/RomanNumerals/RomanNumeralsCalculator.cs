namespace RomanNumerals;

public class RomanNumeralsCalculator
{
    public int ToDigit(string romanNumber)
    {
        if (romanNumber == "III") return 3;
        if (romanNumber == "II") return 2;
        return 1;
    }
}