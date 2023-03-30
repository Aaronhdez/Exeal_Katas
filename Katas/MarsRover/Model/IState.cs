namespace MarsRover.Model;

public interface IState
{
    Direction Direction { get; }
    void MoveForward();
    void MoveBackwards();
    IState TurnRight();
    IState TurnLeft();
}