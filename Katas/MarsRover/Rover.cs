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

    public void Move(char[] commands)
    {
        if(commands.Length == 1) Direction = Direction.West;
        if(commands.Length == 2) Direction = Direction.South;
    }
}