using FluentAssertions;
using MarsRover.Model;

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

        var result = rover.Coordinates;

        result.Should().Be(new Coordinates(1, 1));
        rover.Direction.Should().Be(Direction.North);
    }

    [TestCase(new[] {Order.L}, Direction.West)]
    [TestCase(new[] {Order.L, Order.L}, Direction.South)]
    [TestCase(new[] {Order.L, Order.L, Order.L}, Direction.East)]
    [TestCase(new[] {Order.L, Order.L, Order.L, Order.L}, Direction.North)]
    public void ChangeDirectionWhileTuringLeft(Order[] commands, Direction expectedDirection)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(expectedDirection);
        rover.Coordinates.Should().Be(new Coordinates(1, 1));
    }

    [TestCase(new[] {Order.R}, Direction.East)]
    [TestCase(new[] {Order.R, Order.R}, Direction.South)]
    [TestCase(new[] {Order.R, Order.R, Order.R}, Direction.West)]
    [TestCase(new[] {Order.R, Order.R, Order.R, Order.R}, Direction.North)]
    public void ChangeDirectionWhileTuringRight(Order[] commands, Direction expectedDirection)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(expectedDirection);
        rover.Coordinates.Should().Be(new Coordinates(1, 1));
    }

    [TestCase(new[] {Order.F }, 1, 2)]
    [TestCase(new[] {Order.F, Order.F},1, 3)]
    [TestCase(new[] {Order.F, Order.F, Order.F}, 1, 4)]
    public void MoveForwardWhilePointingNorth(Order[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(Direction.North);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    
    [TestCase(new[] {Order.F }, 1, 0)]
    [TestCase(new[] {Order.F, Order.F},1, -1)]
    [TestCase(new[] {Order.F, Order.F, Order.F}, 1, -2)]
    public void MoveForwardWhilePointingSouth(Order[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.South);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(Direction.South);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Order.F }, 2, 1)]
    [TestCase(new[] {Order.F, Order.F},3, 1)]
    [TestCase(new[] {Order.F, Order.F, Order.F}, 4, 1)]
    public void MoveForwardWhilePointingEast(Order[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.East);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(Direction.East);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Order.F }, 0, 1)]
    [TestCase(new[] {Order.F, Order.F},-1, 1)]
    [TestCase(new[] {Order.F, Order.F, Order.F}, -2, 1)]
    public void MoveForwardWhilePointingWest(Order[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.West);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(Direction.West);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Order.B }, 1, 0)]
    [TestCase(new[] {Order.B, Order.B},1, -1)]
    [TestCase(new[] {Order.B, Order.B, Order.B}, 1, -2)]
    public void MoveBackwardsWhilePointingNorth(Order[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(Direction.North);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Order.B }, 1, 2)]
    [TestCase(new[] {Order.B, Order.B},1, 3)]
    [TestCase(new[] {Order.B, Order.B, Order.B}, 1, 4)]
    public void MoveBackwardsWhilePointingSouth(Order[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.South);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(Direction.South);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Order.B }, 0, 1)]
    [TestCase(new[] {Order.B, Order.B},-1, 1)]
    [TestCase(new[] {Order.B, Order.B, Order.B}, -2, 1)]
    public void MoveBackwardsWhilePointingEast(Order[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.East);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(Direction.East);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Order.B }, 2, 1)]
    [TestCase(new[] {Order.B, Order.B},3, 1)]
    [TestCase(new[] {Order.B, Order.B, Order.B}, 4, 1)]
    public void MoveBackwardsWhilePointingWest(Order[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.West);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Execute(new Routine(commands));
        
        rover.Direction.Should().Be(Direction.West);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
}