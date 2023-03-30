namespace MarsRover;

public class Rover
{
    public IState _state;
    private readonly MoveBackwardsCommand _moveBackwardsCommand;
    private readonly MoveForwardCommand _moveForwardCommand;
    private readonly TurnRightCommand _turnRightCommand;
    private readonly TurnLeftCommand _turnLeftCommand;

    public Direction Direction => _state.Direction;

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
        _moveBackwardsCommand = new MoveBackwardsCommand(this);
        _moveForwardCommand = new MoveForwardCommand(this);
        _turnRightCommand = new TurnRightCommand(this);
        _turnLeftCommand = new TurnLeftCommand(this);
    }

    public void Move(Routine routine)
    {
        foreach (var order in routine.Orders)
        {
            switch (order)
            {
                case Order.L:
                    _turnLeftCommand.Execute();
                    break;
                case Order.R:
                    _turnRightCommand.Execute();
                    break;
                case Order.F:
                    _moveForwardCommand.Execute();
                    break;
                case Order.B:
                    _moveBackwardsCommand.Execute();
                    break;
            }
        }
    }
}