﻿namespace Fibonacci;

public class FibonacciCalculator
{
    public static int Fibonacci(int input)
    {
        if (input > 1) return input - 1;
        return input;
    }
}