namespace MarsRover;

public class Rover
{
    private IState _state;

    public Direction Direction => _state.Direction;

    public Coordinates Coordinates { get; }

    public Rover(Coordinates coordinates, Direction direction)
    {
        Coordinates = coordinates;
        _state = direction switch
        {
            Direction.North => new North(this),
            Direction.East => new East(this),
            Direction.South => new South(this),
            Direction.West => new West(this)
        };
    }

    public void Move(Routine routine)
    {
        foreach (var order in routine.Orders)
        {
            switch (order)
            {
                case Order.L:
                    _state = _state.TurnLeft();
                    break;
                case Order.R:
                    _state = _state.TurnRight();
                    break;
                case Order.F:
                    _state.MoveForward();
                    break;
                case Order.B:
                    _state.MoveBackwards();
                    break;
            }
        }
    }
}