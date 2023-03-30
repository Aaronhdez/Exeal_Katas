using MarsRover.Model.Infra;

namespace MarsRover.Model.States;

public class East : IState
{
    private readonly Rover _rover;

    public Direction Direction => Direction.East;

    public East(Rover rover)
    {
        _rover = rover;
    }

    public void MoveForward()
    {
        _rover.Coordinates.IncreaseX();
    }

    public void MoveBackwards()
    {
        _rover.Coordinates.DecreaseX();
    }

    public IState TurnRight()
    {
        return new South(_rover);
    }

    public IState TurnLeft()
    {
        return new North(_rover);
    }
}