using MarsRover.Model;

namespace MarsRover.Control.Commands;

public class MoveForward : ICommand
{
    private readonly Rover _rover;

    public MoveForward(Rover rover)
    {
        _rover = rover;
    }

    public void Execute()
    {
        _rover.State.MoveForward();
    }
}