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
        if (value > 1) return "I" + ToRoman(value - 1);
        return "I";
    }
}