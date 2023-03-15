namespace TicTacToe;

public class TicTacToeGame
{
    private readonly string _defaultStatus = "[][][]\n[][][]\n[][][]";

    public TicTacToeGame()
    {
        Board = new Board();
    }

    public Board Board { get; }

    public string CurrentStatus()
    {
        if (Board.IsEmpty()) return _defaultStatus;
        if (PlayerXHasWon()) return FormattedBoardStatus() + "\nX Wins!";
        if (PlayerOHasWon()) return FormattedBoardStatus() + "\nO Wins!";
        return FormattedBoardStatus();
    }

    private bool PlayerXHasWon()
    {
        if (Board.AColumnIsFilledBy("X")) return true;
        if (Board.PlayerXHasFilledFirstRow()) return true;
        if (Board.PlayerXHasFilledSecondRow()) return true;
        if (Board.PlayerXHasFilledThirdRow()) return true;

        return false;
    }

    private bool PlayerOHasWon()
    {
        if (Board.AColumnIsFilledBy("O")) return true;

        return false;
    }

    public void Write(Symbol symbol, Coordinates coordinates)
    {
        try
        {
            Board.WriteASymbol(symbol, coordinates);
        }
        catch (Exception e)
        {
            throw new IndexOutOfRangeException();
        }
    }

    private string FormattedBoardStatus()
    {
        return
            $"[{Board.SymbolAt(new Coordinates(0, 0))}][{Board.SymbolAt(new Coordinates(0, 1))}][{Board.SymbolAt(new Coordinates(0, 2))}]\n" +
            $"[{Board.SymbolAt(new Coordinates(1, 0))}][{Board.SymbolAt(new Coordinates(1, 1))}][{Board.SymbolAt(new Coordinates(1, 2))}]\n" +
            $"[{Board.SymbolAt(new Coordinates(2, 0))}][{Board.SymbolAt(new Coordinates(2, 1))}][{Board.SymbolAt(new Coordinates(2, 2))}]";
    }
}