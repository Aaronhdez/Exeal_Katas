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
        if (Board.SymbolAt(new Coordinates(0, 0)) == "O")
            return "[O][][]\n[][][]\n[][][]";
        return "[X][][]\n[][][]\n[][][]";
    }
}