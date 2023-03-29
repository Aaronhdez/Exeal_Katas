﻿namespace MarsRover;

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