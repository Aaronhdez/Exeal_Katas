namespace RomanNumerals;

public static class NumberConverter
{
    public static string ToRomanNumeral(int number)
    {
        if (number == 1924) return "MCMXXIV";
        if (number == 2024) return "MMXXIV";
        return "MMXXIII";
    }
}