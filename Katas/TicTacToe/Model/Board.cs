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

    public bool AColumnHasBeenFilledBy(string player)
    {
        for (var y = 0; y < 3; y++)
        {
            if (TokenAt(new Coordinates(0, y)) == player
                && TokenAt(new Coordinates(0, y)) ==
                TokenAt(new Coordinates(1, y))
                && TokenAt(new Coordinates(1, y)) ==
                TokenAt(new Coordinates(2, y)))
                return true;
        }
        return false;
    }

    public bool ARowHasBeenFilledBy(string player)
    {
        for (var x = 0; x < 3; x++)
        {
            if (TokenAt(new Coordinates(x, 2)) == player
                && TokenAt(new Coordinates(x, 2)) ==
                TokenAt(new Coordinates(x, 1))
                && TokenAt(new Coordinates(x, 1)) ==
                TokenAt(new Coordinates(x, 0)))
                return true;
        }
        return false;
    }

    public bool ADiagonalRowHasBeenFilledBy(string player)
    {
        if (TokenAt(new Coordinates(2, 2)) == player
            && TokenAt(new Coordinates(2, 2)) ==
            TokenAt(new Coordinates(1, 1))
            && TokenAt(new Coordinates(1, 1)) ==
            TokenAt(new Coordinates(0, 0)))
            return true;
        if (TokenAt(new Coordinates(0, 2)) == player
            && TokenAt(new Coordinates(0, 2)) ==
            TokenAt(new Coordinates(1, 1))
            && TokenAt(new Coordinates(1, 1)) ==
            TokenAt(new Coordinates(2, 0)))
            return true;
        return false;
    }
}