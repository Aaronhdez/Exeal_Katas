using FluentAssertions;

namespace MarsRover.Tests;

public class MarsRoverShould
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LandInSpecificCoordinates()
    {
        var rover = new Rover(1,1);

        var resultX = rover.X;
        var resultY = rover.Y;
        
        resultX.Should().Be(1);
        resultY.Should().Be(1);
    }
}