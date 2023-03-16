namespace StringCalculator;

public static class StringCalculatorMachine
{
    public static int Add(string input)
    {
        if (input.Contains(','))
        {
            return SumOfNumbersIn(input);
        }

        if (!string.IsNullOrEmpty(input)) return int.Parse(input);
        return 0;
    }

    private static int SumOfNumbersIn(string input)
    {
        var numbers = input.Split(",");
        return int.Parse(numbers[0]) + int.Parse(numbers[1]);
    }
}