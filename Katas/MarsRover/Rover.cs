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
        _state = new North(direction);
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
                    MoveForward(this);
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

    public static void MoveForward(Rover rover)
    {
        if (rover.Direction == Direction.North)
        {
            rover.Coordinates.IncreaseY();
        }

        if (rover.Direction == Direction.South)
        {
            rover.Coordinates.DecreaseY();
        }

        if (rover.Direction == Direction.East)
        {
            rover.Coordinates.IncreaseX();
        }

        if (rover.Direction == Direction.West)
        {
            rover.Coordinates.DecreaseX();
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

public abstract class State
{
    public Direction Direction { get; set; }

    public State(Direction direction)
    {
        Direction = direction;
    }
}

class North : State
{
    public North(Direction direction) : base(direction)
    {
    }
}

class East : State
{
    public East(Direction direction) : base(direction)
    {
    }
}
class South : State
{
    public South(Direction direction) : base(direction)
    {
    }
}

class West : State
{
    public West(Direction direction) : base(direction)
    {
    }
}

