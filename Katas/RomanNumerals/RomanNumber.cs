namespace RomanNumerals;

public class RomanNumber
{
    private readonly string _value;
    private readonly RomanNumberValidator _validator;

    private readonly Dictionary<char, int> _intEquivalences = new()
    {
        { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 },
    };

    public RomanNumber(string value)
    {
        _validator = new RomanNumberValidator();
        if (!_validator.Validate(value)) throw new InvalidDataException();
        _value = value;
    }

    public int ToDigit()
    {
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