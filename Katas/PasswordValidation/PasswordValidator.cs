﻿using System.Text.RegularExpressions;

namespace PasswordValidation;

public partial class PasswordValidator
{
    private const string NotEnoughCharactersError = "Password must be at least 8 characters";
    private const string NotEnoughNumbersError = "Password must contain at least 2 numbers";
    private const string NotEnoughCapitalsError = "Password must contain al least one capital letter";
    [GeneratedRegex("[^\\d]")] private static partial Regex DigitRegex();
    [GeneratedRegex("[A-Z]")] private static partial Regex UpperCaseRegex();

    public bool Validate(string passwordToValidate, out string validationResults)
    {
        validationResults = string.Empty;
        HasValidLength(passwordToValidate, ref validationResults);
        HasAtLeastTwoNumbers(passwordToValidate, ref validationResults);
        HasAtLeastACapitalLetter(passwordToValidate, ref validationResults);
        return IsValidPassword(ref validationResults);
    }

    private static void HasValidLength(string passwordToValidate, ref string validationResults)
    {
        if (passwordToValidate.Length < 8)
            validationResults += NotEnoughCharactersError;
    }

    private static void HasAtLeastTwoNumbers(string passwordToValidate, ref string validationResults)
    {
        var numbersInPassword = DigitRegex()
            .Replace(passwordToValidate, string.Empty);
        if (numbersInPassword.Length < 2)
            validationResults += validationResults.Length == 0
                ? NotEnoughNumbersError
                : $"\n{NotEnoughNumbersError}";
    }

    private static void HasAtLeastACapitalLetter(string passwordToValidate, ref string validationResults)
    {
        var upperCasesInPassword = UpperCaseRegex()
            .Replace(passwordToValidate, string.Empty);
        if (upperCasesInPassword.Length == passwordToValidate.Length)
            validationResults += validationResults.Length == 0 
                ? NotEnoughCapitalsError
                : $"\n{NotEnoughCapitalsError}";
    }

    private static bool IsValidPassword(ref string validationResults)
    {
        if (validationResults.Length != 0) return false;
        validationResults = "Valid Password";
        return true;
    }
}