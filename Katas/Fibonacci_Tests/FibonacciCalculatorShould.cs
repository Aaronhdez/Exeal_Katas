using Fibonacci;
using FluentAssertions;

namespace Fibonacci_Tests;

public class FibonacciCalculatorShould
{
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 2)]
    [TestCase(4, 3)]
    [TestCase(5, 5)]
    [TestCase(6, 8)]
    [TestCase(7, 13)]
    public void Return_fibonacci_sequence_to_nth_position(int input, int expectedResult)
    {
        var result = FibonacciCalculator.Fibonacci(input);
        
        result.Should().Be(expectedResult);
    }
}