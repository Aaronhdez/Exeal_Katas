namespace MarsRover;

public class TurnLeftCommand : ICommand
{
    private readonly Rover _rover;

    public TurnLeftCommand(Rover rover)
    {
        _rover = rover;
    }

    public void Execute()
    {
        _rover._state = _rover._state.TurnLeft();
    }
}