using Factorial;
using FluentAssertions;

namespace Factorial_Tests;
public class FactorialCalculatorShould
{
    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 6)]
    [TestCase(4, 24)]
    public void Return_factorial_of_a_number_when_input_is_that_number(int input, int expectedResult)
    {
        var result = FactorialCalculator.Factorial(input);
        
        result.Should().Be(expectedResult);
    }

    [Test]
    public void Return_1_is_input_is_negative()
    {
        var result = FactorialCalculator.Factorial(-4);
        
        result.Should().Be(1);
    }
}