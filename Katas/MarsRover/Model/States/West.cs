using MarsRover.Model.Infra;

namespace MarsRover.Model.States;

public class West : IState
{
    private readonly Rover _rover;

    public Direction Direction => Direction.West;
    
    public West(Rover rover)
    {
        _rover = rover;
    }

    public void MoveForward()
    {
        _rover.Coordinates.DecreaseX();
    }

    public void MoveBackwards()
    {
        _rover.Coordinates.IncreaseX();
    }

    public IState TurnRight()
    {
        return new North(_rover);
    }

    public IState TurnLeft()
    {
        return new South(_rover);
    }
}