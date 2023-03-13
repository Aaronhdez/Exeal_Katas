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
    
    [Test]
    public void Return_1_if_input_is_1()
    {
        var result = FibonacciCalculator.Fibonacci(1);
        
        result.Should().Be(1);
    }
    
    [Test]
    public void Return_1_if_input_is_2()
    {
        var result = FibonacciCalculator.Fibonacci(2);
        
        result.Should().Be(1);
    }
    
    [Test]
    public void Return_2_if_input_is_3()
    {
        var result = FibonacciCalculator.Fibonacci(3);
        
        result.Should().Be(2);
    }
    
    [Test]
    public void Return_3_if_input_is_4()
    {
        var result = FibonacciCalculator.Fibonacci(4);
        
        result.Should().Be(3);
    }
    
    [Test]
    public void Return_5_if_input_is_5()
    {
        var result = FibonacciCalculator.Fibonacci(5);
        
        result.Should().Be(5);
    }
}