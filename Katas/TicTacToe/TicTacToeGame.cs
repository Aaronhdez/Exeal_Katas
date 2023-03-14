namespace TicTacToe;

public class TicTacToeGame
{
    public TicTacToeGame()
    {
        Board = new Board();
    }

    public Board Board { get; }

    public string CurrentStatus()
    {
        if (Board.BoardIsEmpty()) return "[][][]\n[][][]\n[][][]";
        return BoardStatus();
    }

    private string BoardStatus()
    {
        var boardStatus = string.Empty;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                boardStatus += "[" + Board.SymbolAt(new Coordinates(i, j)) + "]";
            }

            boardStatus += " ";
        }
        return boardStatus.Trim().Replace(" ", "\n");
    }
}