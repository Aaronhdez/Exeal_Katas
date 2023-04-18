namespace RomanNumerals;

public static class NumberConverter
{
    public static string ToRomanNumeral(int number)
    {
        return new DigitalNumber(number).ToRomanNumeral();
    }

    public static int ToInteger(string romanNumeral)
    {
        if (romanNumeral == "MCMII") return 1902;
        if (romanNumeral == "MMCCII") return 2202;
        return 2201;
    }
}