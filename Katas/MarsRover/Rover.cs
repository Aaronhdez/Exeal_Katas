﻿namespace MarsRover;

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
                    _state = _state.TurnLeft(this);
                    break;
                case Order.R:
                    _state = _state.TurnRight(this);
                    break;
                case Order.F:
                    _state.MoveForward(this);
                    break;
                case Order.B:
                    _state.MoveBackwards(this);
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

    public abstract void MoveForward(Rover rover);

    public abstract void MoveBackwards(Rover rover);

    public abstract State TurnRight(Rover rover);

    public virtual State TurnLeft(Rover rover)
    {
        rover.Direction = (rover.Direction == Direction.East) ? Direction.North : rover.Direction + 1;
        return null;
    }
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

    public override void MoveBackwards(Rover rover)
    {
        rover.Coordinates.DecreaseY();
    }

    public override State TurnRight(Rover rover)
    {
        return new East(rover);
    }

    public override State TurnLeft(Rover rover)
    {
        return new West(rover);
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

    public override void MoveBackwards(Rover rover)
    {
        rover.Coordinates.DecreaseX();
    }

    public override State TurnRight(Rover rover)
    {
        return new South(rover);
    }

    public override State TurnLeft(Rover rover)
    {
        return new North(rover);
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

    public override void MoveBackwards(Rover rover)
    {
        rover.Coordinates.IncreaseY();
    }

    public override State TurnRight(Rover rover)
    {
        return new West(rover);
    }

    public override State TurnLeft(Rover rover)
    {
        return new East(rover);
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

    public override void MoveBackwards(Rover rover)
    {
        rover.Coordinates.IncreaseX();
    }

    public override State TurnRight(Rover rover)
    {
        return new North(rover);
    }

    public override State TurnLeft(Rover rover)
    {
        return new South(rover);
    }
}