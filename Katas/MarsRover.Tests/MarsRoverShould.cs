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

public class Rover
{
    public int X { get; }
    public int Y { get; }

    public Rover(int x, int y)
    {
    }
}