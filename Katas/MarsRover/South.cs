namespace MarsRover;

public class South : IState
{
    private readonly Rover _rover;

    public Direction Direction => Direction.South;

    public South(Rover rover)
    {
        _rover = rover;
    }

    public void MoveForward()
    {
        _rover.Coordinates.DecreaseY();
    }

    public void MoveBackwards()
    {
        _rover.Coordinates.IncreaseY();
    }

    public IState TurnRight()
    {
        return new West(_rover);
    }

    public IState TurnLeft()
    {
        return new East(_rover);
    }
}