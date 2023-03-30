namespace MarsRover;

public class MoveBackwardsCommand : ICommand
{
    private readonly Rover _rover;

    public MoveBackwardsCommand(Rover rover)
    {
        _rover = rover;
    }

    public void Execute()
    {
        _rover.State.MoveBackwards();
    }
}