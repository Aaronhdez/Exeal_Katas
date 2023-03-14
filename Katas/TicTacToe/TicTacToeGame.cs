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
        return "The board is empty";
    }
}