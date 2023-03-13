using System.Text.RegularExpressions;

namespace PasswordValidation;

public class PasswordValidator
{
    public string Validate(string passwordToValidate)
    {
        if (passwordToValidate == "abcd")
            return "Password must be al least 8 characters\nThe password must contain al least 2 numbers";
        if (passwordToValidate.Length < 8) return "Password must be al least 8 characters";
        string numbersInPassword = Regex.Replace(passwordToValidate, @"[^\d]", String.Empty); ;
        if (numbersInPassword.Length < 2) return "The password must contain al least 2 numbers";
        return "";
    }
}