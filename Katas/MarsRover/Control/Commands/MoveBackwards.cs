using MarsRover.Model;

namespace MarsRover.Control.Commands;

public class MoveBackwards : ICommand
{
    private readonly Rover _rover;

    public MoveBackwards(Rover rover)
    {
        _rover = rover;
    }

    public void Execute()
    {
        _rover.MoveBackwards();
    }
}