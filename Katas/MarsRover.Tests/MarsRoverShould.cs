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
        var rover = new Rover(new Coordinates(1, 1));

        var result = rover.Coordinates;
        
        result.X.Should().Be(1);
        result.Y.Should().Be(1);
    }
}