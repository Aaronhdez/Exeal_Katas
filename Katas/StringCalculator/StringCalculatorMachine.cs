namespace StringCalculator;

public static class StringCalculatorMachine
{
    public static int Add(string input)
    {
        if (!string.IsNullOrEmpty(input)) return int.Parse(input);
        return 0;
    }
}