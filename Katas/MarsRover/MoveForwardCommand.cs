namespace MarsRover;

public class MoveForwardCommand : ICommand
{
    private readonly Rover _rover;

    public MoveForwardCommand(Rover rover)
    {
        _rover = rover;
    }

    public void Execute()
    {
        _rover.State.MoveForward();
    }
}