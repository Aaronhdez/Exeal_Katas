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
        State = direction switch
        {
            Direction.North => new North(this),
            Direction.East => new East(this),
            Direction.South => new South(this),
            Direction.West => new West(this)
        };
    }
}