namespace TicTacToe.Test;

public class Coordinates
{
    private readonly int _x;
    private readonly int _y;
    
    public Coordinates(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public override string ToString()
    {
        return _x + "," + _y;
    }
}