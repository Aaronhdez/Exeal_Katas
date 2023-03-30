namespace MarsRover;

public class Rover
{
    private State _state;

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

public abstract class State
{
    protected readonly Rover Rover;
    public Direction Direction { get; set; }

    protected State(Direction direction, Rover rover)
    {
        Direction = direction;
        Rover = rover;
    }

    public abstract void MoveForward();

    public abstract void MoveBackwards();

    public abstract State TurnRight();

    public abstract State TurnLeft();
}

public class North : State
{
    public North(Rover rover) : base(Direction.North, rover)
    {
    }

    public override void MoveForward()
    {
        Rover.Coordinates.IncreaseY();
    }

    public override void MoveBackwards()
    {
        Rover.Coordinates.DecreaseY();
    }

    public override State TurnRight()
    {
        return new East(Rover);
    }

    public override State TurnLeft()
    {
        return new West(Rover);
    }
}

public class East : State
{
    public East(Rover rover) : base(Direction.East, rover)
    {
    }

    public override void MoveForward()
    {
        Rover.Coordinates.IncreaseX();
    }

    public override void MoveBackwards()
    {
        Rover.Coordinates.DecreaseX();
    }

    public override State TurnRight()
    {
        return new South(Rover);
    }

    public override State TurnLeft()
    {
        return new North(Rover);
    }
}

public class South : State
{
    public South(Rover rover) : base(Direction.South, rover)
    {
    }

    public override void MoveForward()
    {
        Rover.Coordinates.DecreaseY();
    }

    public override void MoveBackwards()
    {
        Rover.Coordinates.IncreaseY();
    }

    public override State TurnRight()
    {
        return new West(Rover);
    }

    public override State TurnLeft()
    {
        return new East(Rover);
    }
}

public class West : State
{
    public West(Rover rover) : base(Direction.West, rover)
    {
    }

    public override void MoveForward()
    {
        Rover.Coordinates.DecreaseX();
    }

    public override void MoveBackwards()
    {
        Rover.Coordinates.IncreaseX();
    }

    public override State TurnRight()
    {
        return new North(Rover);
    }

    public override State TurnLeft()
    {
        return new South(Rover);
    }
}