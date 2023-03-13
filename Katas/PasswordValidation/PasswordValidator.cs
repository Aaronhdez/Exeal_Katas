using System.Text.RegularExpressions;

namespace PasswordValidation;

public class PasswordValidator
{
    public bool Validate(string passwordToValidate, out string validationResults)
    {
        validationResults = string.Empty;
        if (passwordToValidate.Length < 8)
        {
            validationResults += "Password must be al least 8 characters";
        }
        var numbersInPassword = Regex.Replace(passwordToValidate, @"[^\d]", String.Empty); ;
        if (numbersInPassword.Length < 2)
        {
            validationResults += (validationResults.Length == 0) ? 
                "Password must contain al least 2 numbers":
                "\nPassword must contain al least 2 numbers";
        }

        if (validationResults.Length > 0) return false;
        return true;
    }
}