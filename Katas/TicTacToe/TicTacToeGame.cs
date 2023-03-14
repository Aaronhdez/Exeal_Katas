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
        if (!Board.BoardIsEmpty()) return "[x][][]\n[][][]\n[][][]";
        return "[][][]\n[][][]\n[][][]";
    }
}