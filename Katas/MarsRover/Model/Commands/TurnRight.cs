namespace MarsRover.Model.Commands;

public class TurnRight : ICommand
{
    private readonly Rover _rover;

    public TurnRight(Rover rover)
    {
        _rover = rover;
    }

    public void Execute()
    {
        _rover.State = _rover.State.TurnRight();
    }
}