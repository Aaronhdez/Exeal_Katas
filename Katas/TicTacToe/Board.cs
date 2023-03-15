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
        for (var i = 0; i < 3; i++)
        {
            if (SymbolAt(new Coordinates(0, i)) == player
                && SymbolAt(new Coordinates(0, i)) ==
                SymbolAt(new Coordinates(1, i))
                && SymbolAt(new Coordinates(1, i)) ==
                SymbolAt(new Coordinates(2, i)))
                return true;
        }

        return false;
    }

    public bool PlayerXHasFilledFirstRow()
    {
        return SymbolAt(new Coordinates(0, 2)) == "X" 
               && SymbolAt(new Coordinates(0, 2)) ==
               SymbolAt(new Coordinates(0, 1)) 
               && SymbolAt(new Coordinates(0, 1)) ==
               SymbolAt(new Coordinates(0, 0));
    }
}