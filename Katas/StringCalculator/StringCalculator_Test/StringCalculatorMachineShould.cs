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
}