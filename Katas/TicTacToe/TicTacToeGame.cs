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
        if (Board.BoardIsEmpty()) return _defaultStatus;
        if (Board.AColumnIsFilledByPlayerX()) return FormattedBoardStatus()+"\nX Wins!";
        if (Board.SecondColumnIsFilledWithX()) return FormattedBoardStatus()+"\nX Wins!";
        if (Board.ThirdColumnIsFilledWithX()) return FormattedBoardStatus()+"\nX Wins!";
        if (Board.FirstColumnIsFilledWithO()) return FormattedBoardStatus()+"\nO Wins!";
        if (Board.SecondColumnIsFilledWithO()) return FormattedBoardStatus()+"\nO Wins!";
        if (Board.ThirdColumnIsFilledWithO()) return FormattedBoardStatus()+"\nO Wins!";
        return FormattedBoardStatus();
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