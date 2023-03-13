namespace Factorial;

public class FactorialCalculator
{
    public static int Factorial(int number)
    {
        if (number >= 0 && number < 1)
            return 1;
        return number * Factorial(number - 1);
    }
}