using Fibonacci;
using FluentAssertions;

namespace Fibonacci_Tests;

public class FibonacciCalculatorShould
{
    [Test]
    public void Return_0_if_input_is_0()
    {
        var result = FibonacciCalculator.Fibonacci(0);
        
        result.Should().Be(0);
    }
}