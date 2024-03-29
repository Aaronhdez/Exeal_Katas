﻿namespace RomanNumerals;

public class DigitalNumber
{
    private readonly int _value;

    public DigitalNumber(int digit)
    {
        if (!IsValid(digit)) throw new InvalidDataException();
        _value = digit;
    }

    private bool IsValid(int digit)
    {
        return digit is <= 3000 and >= 1;
    }

    public string ToRomanNumeral()
    {
        return ToRoman(_value);
    }

    private string ToRoman(int value)
    {
        return value switch
        {
            >= 1000 => "M" + ToRoman(value - 1000),
            >= 900 => "CM" + ToRoman(value - 900),
            >= 500 => "D" + ToRoman(value - 500),
            >= 400 => "CD" + ToRoman(value - 400),
            >= 100 => "C" + ToRoman(value - 100),
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