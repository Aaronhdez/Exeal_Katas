using Factorial;
using FluentAssertions;

namespace Factorial_Tests;
public class FactorialCalculatorShould
{
    [Test]
    public void Return_1_if_input_is_0()
    {
        var result = FactorialCalculator.Factorial(0);
        
        result.Should().Be(1);
    }
}