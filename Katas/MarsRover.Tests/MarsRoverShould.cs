using FluentAssertions;
using MarsRover.Control;
using MarsRover.Model;
using MarsRover.Model.Infra;

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
        var rover = new Rover(new Coordinates(1, 1), Direction.North);

        var result = rover.Coordinates;
        
        result.Should().Be(new Coordinates(1, 1));
    }
    
    [Test]
    public void PointingAnSpecificDirectionOnLanding()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);

        rover.Direction.Should().Be(Direction.North);
    }

    [Test]
    public void ChangeDirectionWhileTuringLeft()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.TurnLeft();
        
        rover.Direction.Should().Be(Direction.West);
    }
    
    [Test]
    public void ChangeDirectionWhileTuringLeftTwice()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.TurnLeft();
        rover.TurnLeft();
        
        rover.Direction.Should().Be(Direction.South);
    }
}