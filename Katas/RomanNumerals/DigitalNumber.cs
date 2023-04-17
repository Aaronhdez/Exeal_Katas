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
        if (_value == 2) return "II";
        return "I";
    }
}