using System.Text.RegularExpressions;

namespace PasswordValidation;

public class PasswordValidator
{
    private const string PasswordMustBeAlLeastCharacters = "Password must be al least 8 characters";
    private const string PasswordMustContainAlLeastNumbers = "Password must contain al least 2 numbers";

    public bool Validate(string passwordToValidate, out string validationResults)
    {
        validationResults = string.Empty;
        HasValidLength(passwordToValidate, ref validationResults);
        HasAtLeastTwoNumbers(passwordToValidate, ref validationResults);
        return validationResults.Length <= 0;
    }

    private static void HasAtLeastTwoNumbers(string passwordToValidate, ref string validationResults)
    {
        var numbersInPassword = Regex.Replace(passwordToValidate, @"[^\d]", string.Empty);
        if (numbersInPassword.Length < 2)
            validationResults += (validationResults.Length == 0)
                ? PasswordMustContainAlLeastNumbers
                : $"\n{PasswordMustContainAlLeastNumbers}";
    }

    private static void HasValidLength(string passwordToValidate, ref string validationResults)
    {
        if (passwordToValidate.Length < 8)
            validationResults += PasswordMustBeAlLeastCharacters;
    }
}