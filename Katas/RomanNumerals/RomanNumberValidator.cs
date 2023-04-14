namespace RomanNumerals;

public class RomanNumberValidator
{
    public bool Validate(string value)
    {
        if (!ValidAmountsOfMultiplesOf10(value)) throw new InvalidDataException();
        if (!ValidAmountsOfMultiplesOf5(value)) throw new InvalidDataException();
        return true;
    }

    private bool ValidAmountsOfMultiplesOf5(string value)
    {
        var multiplesOf5 = new[] { 'I', 'X', 'C'};
        return !multiplesOf5.Any(character => value.Count(c => c == character) <= 3);
    }

    private bool ValidAmountsOfMultiplesOf10(string value)
    {
        var multiplesOf10 = new[] { 'I', 'X', 'C'};
        return !multiplesOf10.Any(character => value.Count(c => c == character) <= 3);
    }
}