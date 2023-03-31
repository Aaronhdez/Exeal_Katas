using MarsRover.Model.Infra;
using MarsRover.Model.States;

namespace MarsRover.Model;

public class Rover
{
    public IState State;
    public Direction Direction => State.Direction;
    public Coordinates Coordinates { get; }

    public Rover(Coordinates coordinates, Direction direction)
    {
        Coordinates = coordinates;
        var statesDictionary = new Dictionary<Direction, IState>
        {
            { Direction.North, new North(this) },
            { Direction.East, new East(this) },
            { Direction.South, new South(this) },
            { Direction.West, new West(this) }
        };
        State = statesDictionary[direction];
    }

    public void MoveBackwards()
    {
        State.MoveBackwards();
    }

    public void MoveForward()
    {
        State.MoveForward();
    }

    public void TurnLeft()
    {
        State = State.TurnLeft();
    }

    public void TurnRight()
    {
        State = State.TurnRight();
    }
}