namespace TicTacToe;

public class TicTacToeGame
{
    private Dictionary<string, string> board;

    public TicTacToeGame()
    {
        board = new Dictionary<string, string>();
    }

    public bool BoardIsEmpty()
    {
        return board.Count == 0;
    }

    public void WriteASymbol(string symbol, Coordinates coordinates)
    {
        board.Add(coordinates.ToString(), symbol);
    }
}