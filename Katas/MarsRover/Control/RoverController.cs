using MarsRover.Control.Commands;
using MarsRover.Model;
using MarsRover.Model.Infra;

namespace MarsRover.Control;


public class RoverController
{
    private readonly Dictionary<Order, Action> _commands;

    private Rover Rover { get; }

    public RoverController(Coordinates coordinates, Direction direction)
    {
        Rover = new Rover(coordinates, direction);
        _commands = new Dictionary<Order, Action>
        {
            { Order.B, new MoveBackwards(Rover).Execute },
            { Order.F, new MoveForward(Rover).Execute },
            { Order.R, new TurnRight(Rover).Execute },
            { Order.L, new TurnLeft(Rover).Execute },
        };
    }

    public void Execute(Routine routine)
    {
        routine.ListOfOrders().ForEach(order => _commands[order]());
    }

    public Direction Direction()
    {
        return Rover.Direction;
    }

    public Coordinates CurrentCoordinates()
    {
        return Rover.Coordinates;
    }
}