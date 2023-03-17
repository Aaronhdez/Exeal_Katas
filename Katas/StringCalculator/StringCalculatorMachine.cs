namespace StringCalculator;

public static class StringCalculatorMachine
{
    public static CalculationResult Add(CalculationInput calculationInput)
    {
        return new CalculationResult(!string.IsNullOrEmpty(calculationInput.Value) 
            ? SumOfNumbersIn(calculationInput) : 0);
    }

    private static int SumOfNumbersIn(CalculationInput calculationInput)
    {
        return CalculationInput.FormattedInput(calculationInput).Sum(FormattedNumber);
    }

    private static int FormattedNumber(string input)
    {
        var candidate = int.Parse(input);
        if (candidate < 0) throw new NotSupportedException("Negatives not supported");
        return candidate > 999 ? 0 : candidate;
    }
}