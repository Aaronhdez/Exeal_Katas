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
                    ExecuteTurnLeft();
                    break;
                case Order.R:
                    ExecuteTurnRight();
                    break;
                case Order.F:
                    ExecuteMoveForward();
                    break;
                case Order.B:
                    ExecuteMoveBackwards();
                    break;
            }
        }
    }

    private void ExecuteMoveBackwards()
    {
        _state.MoveBackwards();
    }

    private void ExecuteMoveForward()
    {
        _state.MoveForward();
    }

    private void ExecuteTurnRight()
    {
        _state = _state.TurnRight();
    }

    private void ExecuteTurnLeft()
    {
        _state = _state.TurnLeft();
    }
}