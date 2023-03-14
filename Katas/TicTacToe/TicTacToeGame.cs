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
        if (!board.ContainsKey(coordinates.ToString()))
            board.Add(coordinates.ToString(), symbol);
    }

    public string SymbolAt(Coordinates coordinates)
    {
        return "Y";
    }
}