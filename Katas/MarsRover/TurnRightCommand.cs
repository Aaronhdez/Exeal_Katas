namespace MarsRover;

public class TurnRightCommand : ICommand
{
    private readonly Rover _rover;

    public TurnRightCommand(Rover rover)
    {
        _rover = rover;
    }

    public void Execute()
    {
        _rover._state = _rover._state.TurnRight();
    }
}