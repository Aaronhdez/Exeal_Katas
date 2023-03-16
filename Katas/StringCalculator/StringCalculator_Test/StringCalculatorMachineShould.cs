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
        var result = StringCalculatorMachine.Add("inputResultValue");
        
        result.Should().Be(0);
    }
}