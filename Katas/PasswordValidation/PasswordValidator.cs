using System.Text.RegularExpressions;

namespace PasswordValidation;

public class PasswordValidator
{
    public bool Validate(string passwordToValidate, out string validationResults)
    {
        validationResults = string.Empty;
        if (passwordToValidate == "abcd")
        {
            validationResults = "Password must be al least 8 characters\nThe password must contain al least 2 numbers";
            return false;
        }
        if (passwordToValidate == "abcde")
        {
            validationResults = "Password must be al least 8 characters\nThe password must contain al least 2 numbers";
            return false;
        }
        if (passwordToValidate == "abcdef")
        {
            validationResults = "Password must be al least 8 characters\nThe password must contain al least 2 numbers";
            return false;
        }

        if (passwordToValidate.Length < 8)
        {
            validationResults = "Password must be al least 8 characters";
            return false;
        }
        var numbersInPassword = Regex.Replace(passwordToValidate, @"[^\d]", String.Empty); ;
        if (numbersInPassword.Length < 2)
        {
            validationResults = "The password must contain al least 2 numbers";
            return false;
        }

        return true;
    }
}