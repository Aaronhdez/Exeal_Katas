using FluentAssertions;
using MarsRover.Control;
using MarsRover.Model.Infra;

namespace MarsRover.Tests;

public class MarsRoverControllerShould
{
    [TestCase(new[] {Order.L}, Direction.West)]
    [TestCase(new[] {Order.L, Order.L}, Direction.South)]
    [TestCase(new[] {Order.L, Order.L, Order.L}, Direction.East)]
    [TestCase(new[] {Order.L, Order.L, Order.L, Order.L}, Direction.North)]
    public void ChangeDirectionWhileExecutingTuringLeftRoutines(Order[] commands, Direction expectedDirection)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.North);

        roverController.Execute(new Routine(commands));
        
        roverController.Direction().Should().Be(expectedDirection);
    }

    [TestCase(new[] {Order.R}, Direction.East)]
    [TestCase(new[] {Order.R, Order.R}, Direction.South)]
    [TestCase(new[] {Order.R, Order.R, Order.R}, Direction.West)]
    [TestCase(new[] {Order.R, Order.R, Order.R, Order.R}, Direction.North)]
    public void ChangeDirectionWhileExecutingTuringRightRoutines(Order[] commands, Direction expectedDirection)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.North);

        roverController.Execute(new Routine(commands));
        
        roverController.Direction().Should().Be(expectedDirection);
    }

    [TestCase(new[] {Order.F }, 1, 2)]
    [TestCase(new[] {Order.F, Order.F},1, 3)]
    [TestCase(new[] {Order.F, Order.F, Order.F}, 1, 4)]
    public void MoveForwardExecutingMovingForwardRoutineWhilePointingNorth(Order[] commands, int x, int y)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.North);

        roverController.Execute(new Routine(commands));
        
        roverController.CurrentCoordinates().Should().Be(new Coordinates(x, y));
    }

    [TestCase(new[] {Order.F }, 1, 0)]
    [TestCase(new[] {Order.F, Order.F},1, -1)]
    [TestCase(new[] {Order.F, Order.F, Order.F}, 1, -2)]
    public void MoveForwardExecutingMovingForwardRoutineWhilePointingSouth(Order[] commands, int x, int y)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.South);

        roverController.Execute(new Routine(commands));
        
        roverController.CurrentCoordinates().Should().Be(new Coordinates(x, y));
    }

    [TestCase(new[] {Order.F }, 2, 1)]
    [TestCase(new[] {Order.F, Order.F},3, 1)]
    [TestCase(new[] {Order.F, Order.F, Order.F}, 4, 1)]
    public void MoveForwardExecutingMovingForwardRoutineWhilePointingEast(Order[] commands, int x, int y)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.East);

        roverController.Execute(new Routine(commands));
        
        roverController.CurrentCoordinates().Should().Be(new Coordinates(x, y));
    }

    [TestCase(new[] {Order.F }, 0, 1)]
    [TestCase(new[] {Order.F, Order.F},-1, 1)]
    [TestCase(new[] {Order.F, Order.F, Order.F}, -2, 1)]
    public void MoveForwardExecutingMovingForwardRoutineWhilePointingWest(Order[] commands, int x, int y)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.West);

        roverController.Execute(new Routine(commands));
        
        roverController.CurrentCoordinates().Should().Be(new Coordinates(x, y));
    }

    [TestCase(new[] {Order.B }, 1, 0)]
    [TestCase(new[] {Order.B, Order.B},1, -1)]
    [TestCase(new[] {Order.B, Order.B, Order.B}, 1, -2)]
    public void MoveBackwardsExecutingMovingBackwardsRoutineWhilePointingNorth(Order[] commands, int x, int y)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.North);

        roverController.Execute(new Routine(commands));
        
        roverController.CurrentCoordinates().Should().Be(new Coordinates(x, y));
    }

    [TestCase(new[] {Order.B }, 1, 2)]
    [TestCase(new[] {Order.B, Order.B},1, 3)]
    [TestCase(new[] {Order.B, Order.B, Order.B}, 1, 4)]
    public void MoveBackwardsExecutingMovingBackwardsRoutineWhilePointingSouth(Order[] commands, int x, int y)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.South);

        roverController.Execute(new Routine(commands));
        
        roverController.CurrentCoordinates().Should().Be(new Coordinates(x, y));
    }

    [TestCase(new[] {Order.B }, 0, 1)]
    [TestCase(new[] {Order.B, Order.B},-1, 1)]
    [TestCase(new[] {Order.B, Order.B, Order.B}, -2, 1)]
    public void MoveBackwardsExecutingMovingBackwardsRoutineWhilePointingEast(Order[] commands, int x, int y)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.East);

        roverController.Execute(new Routine(commands));
        
        roverController.CurrentCoordinates().Should().Be(new Coordinates(x, y));
    }

    [TestCase(new[] {Order.B }, 2, 1)]
    [TestCase(new[] {Order.B, Order.B},3, 1)]
    [TestCase(new[] {Order.B, Order.B, Order.B}, 4, 1)]
    public void MoveBackwardsExecutingMovingBackwardsRoutineWhilePointingWest(Order[] commands, int x, int y)
    {
        var roverController = new RoverController(new Coordinates(1,1), Direction.West);

        roverController.Execute(new Routine(commands));
        
        roverController.CurrentCoordinates().Should().Be(new Coordinates(x, y));
    }
}