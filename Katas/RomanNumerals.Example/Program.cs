// See https://aka.ms/new-console-template for more information

using RomanNumerals;

while (true)
{
    Console.WriteLine("Please, provide a roman numeral");
    var input = Console.ReadLine();
    try
    {
        var numberAsDigit = new RomanNumber(input ?? "").ToDigit();
        Console.WriteLine($"Value of '{input}' is {numberAsDigit}\n");
    }
    catch (InvalidDataException exception)
    {
        Console.WriteLine($"{exception}: '{input}' is not a valid roman numeral\n");
    }
}