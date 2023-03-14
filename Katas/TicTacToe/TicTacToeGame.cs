namespace TicTacToe.Test;

public class Coordinates
{
    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
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
        board.Add($"{coordinates.X},{coordinates.Y}", symbol);
    }
}