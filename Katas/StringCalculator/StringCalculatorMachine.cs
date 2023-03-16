﻿using System.Text.RegularExpressions;

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
        if (Regex.IsMatch(input, "^//*"))
        {
            input = input.Replace("//", string.Empty);
            separator = input[..1];
            input = input[1..];
        }

        return input;
    }

    private static int FormattedNumber(string input)
    {
        return int.Parse(input);
    }
}