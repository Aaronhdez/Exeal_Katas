namespace RomanNumerals;

public class RomanNumberValidator
{
    private readonly char[] _multiplesOf5 = { 'V', 'L', 'D'};
    private readonly char[] _multiplesOf10 = { 'I', 'X', 'C'};

    public bool Validate(string value)
    {
        if (!ValidAmountsOfMultiplesOf10(value)) throw new InvalidDataException();
        if (!ValidAmountsOfMultiplesOf5(value)) throw new InvalidDataException();
        return true;
    }

    private bool ValidAmountsOfMultiplesOf5(string value)
    {
        return !_multiplesOf5.Any(character => value.Count(c => c == character) <= 3);
    }

    private bool ValidAmountsOfMultiplesOf10(string value)
    {
        return !_multiplesOf10.Any(character => value.Count(c => c == character) <= 3);
    }
}