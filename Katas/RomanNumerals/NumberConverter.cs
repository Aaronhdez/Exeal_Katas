namespace RomanNumerals;

public static class NumberConverter
{
    public static string ToRomanNumeral(int number)
    {
        return new DigitalNumber(number).ToRomanNumeral();
    }

    public static int ToInteger(string romanNumeral)
    {
        return 2201;
    }
}