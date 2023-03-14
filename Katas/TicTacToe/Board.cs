namespace TicTacToe;

public class Board
{
    private readonly Dictionary<string, string> _board;

    public Board()
    {
        _board = new Dictionary<string, string>();
    }

    public bool BoardIsEmpty()
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

    public bool FirstColumnIsFilledWithX()
    {
        return SymbolAt(new Coordinates(0, 0)) == "X" 
               && SymbolAt(new Coordinates(0, 0)) ==
               SymbolAt(new Coordinates(1, 0)) 
               && SymbolAt(new Coordinates(1, 0)) ==
               SymbolAt(new Coordinates(2, 0));
    }

    public bool FirstColumnIsFilledWithO()
    {
        return SymbolAt(new Coordinates(0, 0)) == "O" 
               && SymbolAt(new Coordinates(0, 0)) ==
               SymbolAt(new Coordinates(1, 0)) 
               && SymbolAt(new Coordinates(1, 0)) ==
               SymbolAt(new Coordinates(2, 0));
    }

    public bool SecondColumnIsFilledWithX()
    {
        return SymbolAt(new Coordinates(0, 1)) == "X" 
               && SymbolAt(new Coordinates(0, 1)) ==
               SymbolAt(new Coordinates(1, 1)) 
               && SymbolAt(new Coordinates(1, 1)) ==
               SymbolAt(new Coordinates(2, 1));
    }
}