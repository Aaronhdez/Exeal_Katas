namespace TicTacToe.Test;

public class Coordinates
{
    public Coordinates(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public override string ToString()
    {
        return _x + "," + _y;
    }

    private readonly int _x;
    private readonly int _y;
}

public class TicTacToeGame
{
    private static readonly Dictionary<string,string> board = new Dictionary<string, string>();

    public static bool BoardIsEmpty()
    {
        return board.Count == 0;
    }

    public static void WriteASymbol(string symbol, Coordinates coordinates)
    {
        board.Add(coordinates.ToString(), symbol);
    }
}