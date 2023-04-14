namespace RomanNumerals;

public class RomanNumberValidator
{
    private readonly char[] _multiplesOf5 = { 'V', 'L', 'D' };
    private readonly char[] _multiplesOf10 = { 'I', 'X', 'C' };

    public bool Validate(string value)
    {
        return ValidAmountsOfMultiplesOf5(value) && ValidAmountsOfMultiplesOf10(value);
    }

    private bool ValidAmountsOfMultiplesOf5(string value)
    {
        return _multiplesOf5.Where(value.Contains)
            .All(character => value.Count(c => c == character) <= 1);
    }

    private bool ValidAmountsOfMultiplesOf10(string value)
    {
        return _multiplesOf10.Where(value.Contains)
            .All(character => value.Count(c => c == character) <= 3);
    }
}