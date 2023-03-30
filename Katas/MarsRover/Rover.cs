namespace MarsRover;

public class Rover
{
    public IState State;
    private readonly Dictionary<Order, Action> _commands;

    public Direction Direction => State.Direction;

    public Coordinates Coordinates { get; }

    public Rover(Coordinates coordinates, Direction direction)
    {
        Coordinates = coordinates;
        State = direction switch
        {
            Direction.North => new North(this),
            Direction.East => new East(this),
            Direction.South => new South(this),
            Direction.West => new West(this)
        };
        _commands = new Dictionary<Order, Action>
        {
            {Order.B, new MoveBackwardsCommand(this).Execute},
            {Order.F, new MoveForwardCommand(this).Execute},
            {Order.R, new TurnRightCommand(this).Execute},
            {Order.L, new TurnLeftCommand(this).Execute},
        };
    }

    public void Execute(Routine routine)
    {
        foreach (var order in routine.Orders)
        {
            _commands[order]();
        }
    }
}