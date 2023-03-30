namespace MarsRover;

public class Rover
{
    private readonly State _state;
    public Direction Direction
    {
        get => _state.Direction;
        set => _state.Direction = value;
    }

    public Coordinates Coordinates { get; }

    public Rover(Coordinates coordinates, Direction direction)
    {
        Coordinates = coordinates;
        _state = new State(direction);
    }

    public void Move(Routine routine)
    {
        foreach (var order in routine.Orders)
        {
            switch (order)
            {
                case Order.L:
                    TurnLeft();
                    break;
                case Order.R:
                    TurnRight();
                    break;
                case Order.F:
                    MoveForward();
                    break;
                case Order.B:
                    MoveBackwards();
                    break;
            }
        }

    }

    private void MoveBackwards()
    {
        if (Direction == Direction.North)
        {
            Coordinates.DecreaseY();
        }

        if (Direction == Direction.South)
        {
            Coordinates.IncreaseY();
        }

        if (Direction == Direction.East)
        {
            Coordinates.DecreaseX();
        }

        if (Direction == Direction.West)
        {
            Coordinates.IncreaseX();
        }
    }

    private void MoveForward()
    {
        if (Direction == Direction.North)
        {
            Coordinates.IncreaseY();
        }

        if (Direction == Direction.South)
        {
            Coordinates.DecreaseY();
        }

        if (Direction == Direction.East)
        {
            Coordinates.IncreaseX();
        }

        if (Direction == Direction.West)
        {
            Coordinates.DecreaseX();
        }
    }

    private void TurnRight()
    {
        Direction = (Direction == Direction.North) ? Direction.East : Direction - 1;
    }

    private void TurnLeft()
    {
        Direction = (Direction == Direction.East) ? Direction.North : Direction + 1;
    }
}

public class State
{
    public Direction Direction { get; set; }

    public State(Direction direction)
    {
        Direction = direction;
    }
}