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

    [Test]
    public void MoveForwardOneStepWhilePointingAtNorth()
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);

        rover.Move(new[] { Command.F });
        
        rover.Direction.Should().Be(Direction.North);
        rover.Coordinates.Should().Be(new Coordinates(1, 2));
    }
    
    [Test]
    public void MoveForwardTwoStepsWhilePointingAtNorth()
    {
        var rover = new Rover(new Coordinates(1,1), Direction.North);

        rover.Move(new[] { Command.F, Command.F });
        
        rover.Direction.Should().Be(Direction.North);
        rover.Coordinates.Should().Be(new Coordinates(1, 3));
    }
}