using MarsRover.Model;

namespace MarsRover.Control.Commands;

public class TurnLeft : ICommand
{
    private readonly Rover _rover;

    public TurnLeft(Rover rover)
    {
        _rover = rover;
    }

    public void Execute()
    {
        _rover.TurnLeft();
    }
}