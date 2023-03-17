using System.Text.RegularExpressions;

namespace StringCalculator;

public partial class CalculationInput
{
    private const string DefaultSeparator = ",";

    public CalculationInput(string value)
    {
        Value = value;
        GetSeparator();
    }

    public string Value { get; set; }
    private string Separator { get; set; }

    private void GetSeparator()
    {
        Separator = DefaultSeparator;
        if (!DelimiterRegex().IsMatch(Value)) return;
        Value = Value.Replace("//", string.Empty);
        Separator = Value[..1];
        Value = Value[1..];
    }

    public static IEnumerable<string> FormattedInput(CalculationInput calculationInput)
    {
        var input = calculationInput.Value;
        input = input.Replace("\n", calculationInput.Separator);
        return input.Split(calculationInput.Separator);
    }

    [GeneratedRegex("^//*")]
    private static partial Regex DelimiterRegex();
}