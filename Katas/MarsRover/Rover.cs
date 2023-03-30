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
                    TurnLeft();
                    break;
                case Order.R:
                    TurnRight();
                    break;
                case Order.F:
                    _state.MoveForward(this);
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
    protected readonly Rover Rover;
    public Direction Direction { get; set; }

    protected State(Direction direction, Rover rover)
    {
        Direction = direction;
        Rover = rover;
    }

    public abstract void MoveForward(Rover rover);
}

public class North : State
{
    public North(Rover rover) : base(Direction.North, rover)
    {
    }

    public override void MoveForward(Rover rover)
    {
        Rover.Coordinates.IncreaseY();
    }
}

public class East : State
{
    public East(Rover rover) : base(Direction.East, rover)
    {
    }

    public override void MoveForward(Rover rover)
    {
        rover.Coordinates.IncreaseX();
    }
}

public class South : State
{
    public South(Rover rover) : base(Direction.South, rover)
    {
    }

    public override void MoveForward(Rover rover)
    {
        rover.Coordinates.DecreaseY();
    }
}

public class West : State
{
    public West(Rover rover) : base(Direction.West, rover)
    {
    }

    public override void MoveForward(Rover rover)
    {
        rover.Coordinates.DecreaseX();
    }
}