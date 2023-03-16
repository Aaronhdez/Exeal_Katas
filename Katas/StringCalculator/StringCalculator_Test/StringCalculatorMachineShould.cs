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
        var result = StringCalculatorMachine.Add("");
        
        result.Should().Be(0);
    }
    
    [TestCase("1", 1)]
    [TestCase("2", 2)]
    [TestCase("12", 12)]
    [TestCase("121", 121)]
    public void GiveSameNumberAsAResultForASingleNumber(string input, int expectedResult)
    {
        var result = StringCalculatorMachine.Add(input);
        
        result.Should().Be(expectedResult);
    }

    [TestCase("1,2", 3)]
    [TestCase("2,2", 4)]
    [TestCase("2,3", 5)]
    [TestCase("3,3", 6)]
    public void GiveTotalResultForAnyPairOfNumbers(string input, int expectedResult)
    {
        var result = StringCalculatorMachine.Add(input);
        
        result.Should().Be(expectedResult);
    }
}