namespace TicTacToe;

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

    public void WriteASymbol(Symbol symbol, Coordinates coordinates)
    {
        if (!coordinates.AreValid()) throw new Exception();
        if (!_board.ContainsKey(coordinates.ToString()))
            _board.Add(coordinates.ToString(), symbol.Value);
    }

    public string SymbolAt(Coordinates coordinates)
    {
        if (_board.ContainsKey(coordinates.ToString()))
            return _board[coordinates.ToString()];
        return string.Empty;
    }

    public bool AColumnIsFilledBy(string player)
    {
        for (var y = 0; y < 3; y++)
        {
            if (SymbolAt(new Coordinates(0, y)) == player
                && SymbolAt(new Coordinates(0, y)) ==
                SymbolAt(new Coordinates(1, y))
                && SymbolAt(new Coordinates(1, y)) ==
                SymbolAt(new Coordinates(2, y)))
                return true;
        }

        return false;
    }

    public bool PlayerXHasFilledARow()
    {
        for (var x = 0; x < 3; x++)
        {
            if (SymbolAt(new Coordinates(x, 2)) == "X"
                && SymbolAt(new Coordinates(x, 2)) ==
                SymbolAt(new Coordinates(x, 1))
                && SymbolAt(new Coordinates(x, 1)) ==
                SymbolAt(new Coordinates(x, 0)))
                return true;
        }

        return false;
    }

    public bool PlayerOHasFilledFirstRow()
    {
        return SymbolAt(new Coordinates(0, 2)) == "O"
               && SymbolAt(new Coordinates(0, 2)) ==
               SymbolAt(new Coordinates(0, 1))
               && SymbolAt(new Coordinates(0, 1)) ==
               SymbolAt(new Coordinates(0, 0));
    }
}