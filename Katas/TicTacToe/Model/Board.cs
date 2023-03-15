namespace TicTacToe.Model;

public class Board
{
    private readonly Dictionary<string, string> _board;

    public Board()
    {
        _board = new Dictionary<string, string>();
    }

    public bool IsEmpty()
    {
        return _board.Count == 0;
    }

    public bool IsFilled()
    {
        return _board.Count == 9;
    }

    public void WriteASymbol(Symbol symbol, Coordinates coordinates)
    {
        if (!coordinates.AreValid()) throw new IndexOutOfRangeException();
        if (!_board.ContainsKey(coordinates.ToString()))
            _board.Add(coordinates.ToString(), symbol.Value);
    }

    public string TokenAt(Coordinates coordinates)
    {
        return _board.ContainsKey(coordinates.ToString()) ? 
            _board[coordinates.ToString()] : string.Empty;
    }
}