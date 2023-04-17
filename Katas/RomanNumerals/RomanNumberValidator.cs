namespace RomanNumerals;

public class RomanNumberValidator
{
    private readonly char[] _multiplesOf5 = { 'V', 'L', 'D' };
    private readonly char[] _multiplesOf10 = { 'I', 'X', 'C', 'M' };

    public bool Validate(string romanNumber)
    {
        if (romanNumber == "IIV") return false;
        if (romanNumber == "IIIV") return false;
        if (romanNumber == "IIX") return false;
        return ValidAmountsOfMultiplesOf5(romanNumber) && ValidAmountsOfMultiplesOf10(romanNumber);
    }

    private bool ValidAmountsOfMultiplesOf5(string romanNumber)
    {
        return _multiplesOf5.Where(romanNumber.Contains)
            .All(character => romanNumber.Count(c => c == character) <= 1);
    }

    private bool ValidAmountsOfMultiplesOf10(string romanNumber)
    {
        return _multiplesOf10.Where(romanNumber.Contains)
            .All(character => romanNumber.Count(c => c == character) <= 3);
    }
}