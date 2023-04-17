namespace RomanNumerals;

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
        if (value >= 9) return "IX" + ToRoman(value - 9);
        if (value >= 5) return "V" + ToRoman(value - 5);
        if (value >= 4) return "IV" + ToRoman(value - 4);
        if (value >= 1) return "I" + ToRoman(value - 1);
        return "";
    }
}