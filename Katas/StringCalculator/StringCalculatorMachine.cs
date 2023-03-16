using System.Text.RegularExpressions;

namespace StringCalculator;

public static partial class StringCalculatorMachine
{
    public static CalculationResult Add(CalculationInput calculationInput)
    {
        var input = calculationInput.Input;
        return new CalculationResult(!string.IsNullOrEmpty(input) ? SumOfNumbersIn(input) : 0);
    }

    private static int SumOfNumbersIn(string input)
    {
        return FormattedInput(input).Sum(FormattedNumber);
    }

    private static IEnumerable<string> FormattedInput(string input)
    {
        input = GetSeparator(input, out var separator);
        input = input.Replace("\n", separator);
        return input.Split(separator);
    }

    private static string GetSeparator(string input, out string separator)
    {
        separator = ",";
        
        if (!MyRegex().IsMatch(input)) return input;
        input = input.Replace("//", string.Empty);
        separator = input[..1];
        input = input[1..];

        return input;
    }

    private static int FormattedNumber(string input)
    {
        var candidate = int.Parse(input);
        if (candidate < 0) throw new NotSupportedException("Negatives not supported");
        return candidate;
    }

    [GeneratedRegex("^//*")]
    private static partial Regex MyRegex();
}