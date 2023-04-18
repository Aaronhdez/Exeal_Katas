// See https://aka.ms/new-console-template for more information

namespace RomanNumerals.Example;

public static class Demo
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Write A to convert from Roman to Integer");
            Console.WriteLine("Write B to convert from Integer to Roman ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "A":
                    ToDigit();
                    break;
                case "B":
                    ToRoman();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    private static void ToDigit()
    {
        Console.WriteLine("Provide a Number");
        var input = Console.ReadLine();
        try
        {
            var number = new RomanNumber(input ?? "").ToDigit();
            Console.WriteLine($"Value of '{input}' is {number}\n");
        }
        catch (InvalidDataException exception)
        {
            Console.WriteLine($"{exception}: '{input}' is not a valid roman numeral\n");
        }
    }
    
    private static void ToRoman()
    {
        Console.WriteLine("Provide a Number");
        var input = Console.ReadLine();
        try
        {
            var digitalNumber = new DigitalNumber(int.Parse(input ?? "")).ToRomanNumeral();
            Console.WriteLine($"Value of '{input}' is {digitalNumber}\n");
        }
        catch (InvalidDataException exception)
        {
            Console.WriteLine($"{exception}: '{input}' is not a valid digital numeral\n");
        }
    }
}