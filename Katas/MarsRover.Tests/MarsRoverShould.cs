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
    public void ChangeDirectionWhileTuringLeftOnce()
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
    
    [Test]
    public void ChangeDirectionWhileTuringLeftThrice()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.TurnLeft();
        rover.TurnLeft();
        rover.TurnLeft();
        
        rover.Direction.Should().Be(Direction.East);
    }
    
    [Test]
    public void ChangeDirectionWhileTuringLeftFourTimes()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.TurnLeft();
        rover.TurnLeft();
        rover.TurnLeft();
        rover.TurnLeft();
        
        rover.Direction.Should().Be(Direction.North);
    }
    
    [Test]
    public void ChangeDirectionWhileTuringRightOnce()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.TurnRight();
        
        rover.Direction.Should().Be(Direction.East);
    }
    
    [Test]
    public void ChangeDirectionWhileTuringRightTwice()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.TurnRight();
        rover.TurnRight();
        
        rover.Direction.Should().Be(Direction.South);
    }
    
    [Test]
    public void ChangeDirectionWhileTuringRightThrice()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.TurnRight();
        rover.TurnRight();
        rover.TurnRight();
        
        rover.Direction.Should().Be(Direction.West);
    }
    
    [Test]
    public void ChangeDirectionWhileTuringRightFourTimes()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.TurnRight();
        rover.TurnRight();
        rover.TurnRight();
        rover.TurnRight();
        
        rover.Direction.Should().Be(Direction.North);
    }
    
    [Test]
    public void ChangeCoordinatesWhileMovingForwardOnce()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.MoveForward();
        
        rover.Coordinates.Should().Be(new Coordinates(1,2));
    }
    
    [Test]
    public void ChangeCoordinatesWhileMovingBackwardsOnce()
    {
        var rover = new Rover(new Coordinates(1, 1), Direction.North);
        
        rover.MoveBackwards();
        
        rover.Coordinates.Should().Be(new Coordinates(1,0));
    }
}