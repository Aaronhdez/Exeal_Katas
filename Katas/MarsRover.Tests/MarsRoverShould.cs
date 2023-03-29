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

    [TestCase(new[] {Command.L}, Direction.West)]
    [TestCase(new[] {Command.L, Command.L}, Direction.South)]
    [TestCase(new[] {Command.L, Command.L, Command.L}, Direction.East)]
    [TestCase(new[] {Command.L, Command.L, Command.L, Command.L}, Direction.North)]
    public void ChangeDirectionWhileTuringLeft(Command[] commands, Direction expectedDirection)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);

        rover.Move(commands);
        
        rover.Direction.Should().Be(expectedDirection);
        rover.Coordinates.Should().Be(new Coordinates(1, 1));
    }

    [TestCase(new[] {Command.R}, Direction.East)]
    [TestCase(new[] {Command.R, Command.R}, Direction.South)]
    [TestCase(new[] {Command.R, Command.R, Command.R}, Direction.West)]
    [TestCase(new[] {Command.R, Command.R, Command.R, Command.R}, Direction.North)]
    public void ChangeDirectionWhileTuringRight(Command[] commands, Direction expectedDirection)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);

        rover.Move(commands);
        
        rover.Direction.Should().Be(expectedDirection);
        rover.Coordinates.Should().Be(new Coordinates(1, 1));
    }

    [TestCase(new[] {Command.F }, 1, 2)]
    [TestCase(new[] {Command.F, Command.F},1, 3)]
    [TestCase(new[] {Command.F, Command.F, Command.F}, 1, 4)]
    public void MoveForwardWhilePointingNorth(Command[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Move(commands);
        
        rover.Direction.Should().Be(Direction.North);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    
    [TestCase(new[] {Command.F }, 1, 0)]
    [TestCase(new[] {Command.F, Command.F},1, -1)]
    [TestCase(new[] {Command.F, Command.F, Command.F}, 1, -2)]
    public void MoveForwardWhilePointingSouth(Command[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.South);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Move(commands);
        
        rover.Direction.Should().Be(Direction.South);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Command.F }, 2, 1)]
    [TestCase(new[] {Command.F, Command.F},3, 1)]
    [TestCase(new[] {Command.F, Command.F, Command.F}, 4, 1)]
    public void MoveForwardWhilePointingEast(Command[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.East);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Move(commands);
        
        rover.Direction.Should().Be(Direction.East);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Command.F }, 0, 1)]
    [TestCase(new[] {Command.F, Command.F},-1, 1)]
    [TestCase(new[] {Command.F, Command.F, Command.F}, -2, 1)]
    public void MoveForwardWhilePointingWest(Command[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.West);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Move(commands);
        
        rover.Direction.Should().Be(Direction.West);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Command.B }, 1, 0)]
    [TestCase(new[] {Command.B, Command.B},1, -1)]
    [TestCase(new[] {Command.B, Command.B, Command.B}, 1, -2)]
    public void MoveBackwardsWhilePointingNorth(Command[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Move(commands);
        
        rover.Direction.Should().Be(Direction.North);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Command.B }, 1, 2)]
    [TestCase(new[] {Command.B, Command.B},1, 3)]
    [TestCase(new[] {Command.B, Command.B, Command.B}, 1, 4)]
    public void MoveBackwardsWhilePointingSouth(Command[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.South);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Move(commands);
        
        rover.Direction.Should().Be(Direction.South);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Command.B }, 0, 1)]
    [TestCase(new[] {Command.B, Command.B},-1, 1)]
    [TestCase(new[] {Command.B, Command.B, Command.B}, -2, 1)]
    public void MoveBackwardsWhilePointingEast(Command[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.East);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Move(commands);
        
        rover.Direction.Should().Be(Direction.East);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
    
    [TestCase(new[] {Command.B }, 2, 1)]
    [TestCase(new[] {Command.B, Command.B},3, 1)]
    [TestCase(new[] {Command.B, Command.B, Command.B}, 4, 1)]
    public void MoveBackwardsWhilePointingWest(Command[] commands, int x, int y)
    {
        var rover = new Rover(new Coordinates(1,1), Direction.East);
        var expectedCoordinates = new Coordinates(x, y);

        rover.Move(commands);
        
        rover.Direction.Should().Be(Direction.East);
        rover.Coordinates.Should().Be(expectedCoordinates);
    }
}