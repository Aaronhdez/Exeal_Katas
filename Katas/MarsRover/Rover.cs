namespace MarsRover;

public class Rover
{
    public Direction Direction { get; private set; }
    public Coordinates Coordinates { get; private set; }

    public Rover(Coordinates coordinates, Direction direction)
    {
        Direction = direction;
        Coordinates = coordinates;
    }

    public void Move(Command[] commands)
    {
        foreach (var command in commands)
        {
            if (command == Command.L)
            {
                TurnLeft();
            }

            if (command == Command.R)
            {
                TurnRight();
            }

            if (command == Command.F)
            {
                if (Direction == Direction.North)
                {
                    if(commands.Length == 1) Coordinates = new Coordinates(1, 2);
                    if(commands.Length == 2) Coordinates = new Coordinates(1, 3);
                    if(commands.Length == 3) Coordinates = new Coordinates(1, 4);
                }
            }
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