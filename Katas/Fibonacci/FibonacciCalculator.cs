namespace Fibonacci;

public class FibonacciCalculator
{
    public static int Fibonacci(int input)
    {
        if (input > 1) return Fibonacci(input - 1) + Fibonacci(input - 2);
        return input;
    }
}