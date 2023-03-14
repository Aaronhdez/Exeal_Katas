namespace TicTacToe.Test;

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