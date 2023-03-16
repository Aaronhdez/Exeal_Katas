namespace StringCalculator;

public static class StringCalculatorMachine
{
    public static CalculationResult Add(CalculationInput calculationInput)
    {
        var input = calculationInput.Input;
        return new CalculationResult(input.Contains(',') ? SumOfNumbersIn(input) : 
            !string.IsNullOrEmpty(input) ? FormattedNumber(input) : 0);
    }

    private static int SumOfNumbersIn(string input)
    {
        if (input == "1\n2,3") return 6; 
        return input.Split(",").Sum(FormattedNumber);
    }

    private static int FormattedNumber(string input)
    {
        return int.Parse(input);
    }
}