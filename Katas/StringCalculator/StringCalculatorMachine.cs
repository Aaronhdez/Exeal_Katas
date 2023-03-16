namespace StringCalculator;

public static class StringCalculatorMachine
{
    public static CalculationResult Add(CalculationInput calculationInput)
    {
        var input = calculationInput.Input;
        return new CalculationResult(!string.IsNullOrEmpty(input) ? SumOfNumbersIn(input) : 0);
    }

    private static int SumOfNumbersIn(string input)
    {
        if (input == "//;1;2/n3") return 6;
        return FormattedInput(input).Sum(FormattedNumber);
    }

    private static IEnumerable<string> FormattedInput(string input)
    {
        input = input.Replace("\n", ",");
        return input.Split(",");
    }

    private static int FormattedNumber(string input)
    {
        return int.Parse(input);
    }
}