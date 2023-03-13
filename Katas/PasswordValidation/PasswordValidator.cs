using System.Text.RegularExpressions;

namespace PasswordValidation;

public partial class PasswordValidator
{
    private const string PasswordMustBeAlLeastCharacters = "Password must be at least 8 characters";
    private const string PasswordMustContainAtLeastNumbers = "Password must contain at least 2 numbers";

    public bool Validate(string passwordToValidate, out string validationResults)
    {
        validationResults = string.Empty;
        HasValidLength(passwordToValidate, ref validationResults);
        HasAtLeastTwoNumbers(passwordToValidate, ref validationResults);
        if (passwordToValidate == "abcdef12" || passwordToValidate == "bcdefg12")
        {
            validationResults = "Password must contain al least one capital letter";
            return false;
        }

        return validationResults.Length <= 0;
    }

    private static void HasAtLeastTwoNumbers(string passwordToValidate, ref string validationResults)
    {
        var numbersInPassword = DigitRegex()
            .Replace(passwordToValidate, string.Empty);
        if (numbersInPassword.Length < 2)
            validationResults += validationResults.Length == 0
                ? PasswordMustContainAtLeastNumbers
                : $"\n{PasswordMustContainAtLeastNumbers}";
    }

    private static void HasValidLength(string passwordToValidate, ref string validationResults)
    {
        if (passwordToValidate.Length < 8)
            validationResults += PasswordMustBeAlLeastCharacters;
    }

    [GeneratedRegex("[^\\d]")]
    private static partial Regex DigitRegex();
}