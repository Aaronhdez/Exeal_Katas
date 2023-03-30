using MarsRover.Model.Infra;

namespace MarsRover.Model.States;

public class North : IState
{
    
    private readonly Rover _rover;
    
    public Direction Direction => Direction.North;

    public North(Rover rover)
    {
        _rover = rover;
    }

    public void MoveForward()
    {
        _rover.Coordinates.IncreaseY();
    }

    public void MoveBackwards()
    {
        _rover.Coordinates.DecreaseY();
    }

    public IState TurnRight()
    {
        return new East(_rover);
    }

    public IState TurnLeft()
    {
        return new West(_rover);
    }
}