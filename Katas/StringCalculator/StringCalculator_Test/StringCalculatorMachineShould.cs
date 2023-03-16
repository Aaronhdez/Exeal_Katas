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
    
    [Test]
    public void GiveSameNumberAsAResultForASingleNumber()
    {
        var result = StringCalculatorMachine.Add("1");
        
        result.Should().Be(1);
    }
}