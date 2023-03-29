namespace MarsRover;

public class Rover
{
    public Direction Direction { get; }
    public Coordinates Coordinates { get; }

    public Rover(Coordinates coordinates, Direction direction)
    {
        Direction = direction;
        Coordinates = coordinates;
    }
}