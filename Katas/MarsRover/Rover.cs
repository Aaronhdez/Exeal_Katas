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

    public void Move(Command[] commands)
    {
        foreach (var command in commands)
        {
            if (command == Command.L)
            {
                Direction = (Direction == Direction.East) ? Direction.North : Direction + 1;
            }

            if (command == Command.R)
            {
                if(commands.Length == 1) Direction = Direction.East;
                if(commands.Length == 2) Direction = Direction.South;
                if(commands.Length == 3) Direction = Direction.West;
            }
        }

    }
}