namespace RomanNumerals;

public class RomanNumber
{
    private readonly string _value;
    private readonly RomanNumberValidator _validator;

    private Dictionary<char, int> _intEquivalences = new()
    {
        { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 },
    };

    public RomanNumber(string value)
    {
        _value = value;
        _validator = new RomanNumberValidator();
    }

    public int ToDigit()
    {
        if (!_validator.Validate(_value));
        return SumOfNumbers(_value);
    }

    private int SumOfNumbers(string value)
    {
        if (string.IsNullOrEmpty(value)) return 0;
        return ToInt(value[0]) + SumOfNumbers(value[1..]);
    }

    private int ToInt(char character)
    {
        return _intEquivalences[character];
    }
}