namespace MarsRover;

public class Rover
{
    public Direction Direction { get; private set; }
    public Coordinates Coordinates { get; }

    public Rover(Coordinates coordinates, Direction direction)
    {
        Direction = direction;
        Coordinates = coordinates;
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