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
        if (Board.FirstColumnIsFilledWithX()) return "[X][][O]\n[X][O][O]\n[X][][O]\nX Wins!";
        if (Board.SecondColumnIsFilledWithX()) return "[][X][O]\n[O][X][]\n[][X][O]\nX Wins!";
        if (Board.ThirdColumnIsFilledWithX()) return "[O][][X]\n[O][][X]\n[][][X]\nX Wins!";
        if (Board.FirstColumnIsFilledWithO()) return "[O][][X]\n[O][X][X]\n[O][][X]\nO Wins!";
        if (Board.SecondColumnIsFilledWithO()) return "[][O][X]\n[X][O][]\n[][O][X]\nO Wins!";
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
        var boardStatus = string.Empty;
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                boardStatus += "[" + Board.SymbolAt(new Coordinates(i, j)) + "]";
            }

            boardStatus += " ";
        }

        return boardStatus.Trim().Replace(" ", "\n");
    }
}