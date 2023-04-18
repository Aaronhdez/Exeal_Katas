﻿namespace RomanNumerals;

public class DigitalNumber
{
    private readonly int _value;

    public DigitalNumber(string digit)
    {
        _value = int.Parse(digit);
    }

    public string ToRomanNumeral()
    {
        return ToRoman(_value);
    }

    private string ToRoman(int value)
    {
        return value switch
        {
            >= 90 => "XC" + ToRoman(value - 90),
            >= 50 => "L" + ToRoman(value - 50),
            >= 40 => "XL" + ToRoman(value - 40),
            >= 10 => "X" + ToRoman(value - 10),
            >= 9 => "IX" + ToRoman(value - 9),
            >= 5 => "V" + ToRoman(value - 5),
            >= 4 => "IV" + ToRoman(value - 4),
            >= 1 => "I" + ToRoman(value - 1),
            _ => ""
        };
    }
}