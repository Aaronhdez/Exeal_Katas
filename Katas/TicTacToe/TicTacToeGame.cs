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

    public void WriteASymbol(Symbol symbol, Coordinates coordinates)
    {
        if (!board.ContainsKey(coordinates.ToString()))
            board.Add(coordinates.ToString(), symbol.Value);
    }

    public string SymbolAt(Coordinates coordinates)
    {
        if (board.ContainsKey(coordinates.ToString()))
            return board[coordinates.ToString()];
        return string.Empty;
    }
}