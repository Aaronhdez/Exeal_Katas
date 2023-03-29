namespace MarsRover;

public class Routine
{
    public Routine(Command[] commands)
    {
        Commands = commands;
    }

    public Command[] Commands { get; }
}