namespace TicTacToe.Model;

public class Board
{
    private readonly Dictionary<string, string> _cells;

    public Board()
    {
        _cells = new Dictionary<string, string>();
    }

    public bool IsEmpty()
    {
        return _cells.Count == 0;
    }

    public bool IsFilled()
    {
        return _cells.Count == 9;
    }

    public void WriteASymbol(Symbol symbol, Coordinates coordinates)
    {
        if (!coordinates.AreValid()) throw new IndexOutOfRangeException();
        if (!_cells.ContainsKey(coordinates.ToString()))
            _cells.Add(coordinates.ToString(), symbol.Value);
    }

    public string TokenAt(Coordinates coordinates)
    {
        return _cells.ContainsKey(coordinates.ToString()) ? 
            _cells[coordinates.ToString()] : string.Empty;
    }
}