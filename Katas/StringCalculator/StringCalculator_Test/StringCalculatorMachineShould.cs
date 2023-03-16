using StringCalculator;

namespace StringCalculator_Test;

public class StringCalculatorMachineShould
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GiveZeroAsAResultForAnEmptyString()
    {
        var result = StringCalculatorMachine.Add(new CalculationInput("")).Value;

        result.Should().Be(0);
    }

    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [TestCase("12", 12)]
    [TestCase("121", 121)]
    public void GiveSameNumberAsAResultForASingleNumber(string input, int expectedResult)
    {
        var result = StringCalculatorMachine.Add(new CalculationInput(input)).Value;

        result.Should().Be(expectedResult);
    }

    [TestCase("1,2", 3)]
    [TestCase("2,2", 4)]
    [TestCase("2,3", 5)]
    [TestCase("3,3", 6)]
    public void GiveTotalResultForAnyPairOfNumbers(string input, int expectedResult)
    {
        var result = StringCalculatorMachine.Add(new CalculationInput(input)).Value;

        result.Should().Be(expectedResult);
    }

    [TestCase("1,2,3", 6)]
    [TestCase("1,3,3", 7)]
    [TestCase("2,3,3", 8)]
    public void GiveTotalResultForAGroupOfNumbers(string input, int expectedResult)
    {
        var result = StringCalculatorMachine.Add(new CalculationInput(input)).Value;

        result.Should().Be(expectedResult);
    }

    [TestCase("1\n2,3", 6)]
    [TestCase("1\n2\n3", 6)]
    [TestCase("1,2\n3", 6)]
    public void GiveTotalResultForAGroupOfNumbersWithCr(string input, int expectedResult)
    {
        var result = StringCalculatorMachine.Add(new CalculationInput(input)).Value;

        result.Should().Be(expectedResult);
    }

    [TestCase("//;1;2\n3", 6)]
    [TestCase("//:1:2\n3", 6)]
    [TestCase("//@1@2\n3", 6)]
    public void GiveTotalResultForAGroupOfNumbersWithAnyDelimiter(string input, int expectedResult)
    {
        var result = StringCalculatorMachine.Add(new CalculationInput(input)).Value;

        result.Should().Be(expectedResult);
    }

    [Test]
    public void ThrowExceptionWhenNegativeNumbersAreInserted()
    {
        var result = () => StringCalculatorMachine.Add(new CalculationInput("1,-1"));

        result.Should().Throw<NotSupportedException>("Negatives not supported");
    }

    [TestCase("//;1;2\n1000", 3)]
    [TestCase("//:1\n2\n1000", 3)]
    [TestCase("//@1@2\n1000", 3)]
    [TestCase("//:1:2\n1000:1000", 3)]
    public void IgnoreNumbersHigherThanAThousand(string input, int expectedResult)
    {
        var result = StringCalculatorMachine.Add(new CalculationInput(input)).Value;

        result.Should().Be(expectedResult);
    }
}