﻿namespace RomanNumerals;

public static class NumberConverter
{
    public static string ToRomanNumeral(int number)
    {
        return new DigitalNumber(number).ToRomanNumeral();
    }
}