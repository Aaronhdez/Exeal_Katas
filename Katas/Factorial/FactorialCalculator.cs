namespace Factorial;

public class FactorialCalculator
{
    public static int Factorial(int input)
    {
        if (input > 0) return input * Factorial(input - 1);
        return 1;
    }
}