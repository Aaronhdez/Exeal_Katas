using TicTacToe.Model;

namespace TicTacToe;

public class TicTacToeGame
{
    private string _currentPlayer;
    private Board _board;
    private const string DefaultStatus = "[][][]\n[][][]\n[][][]";
    private const string XPlayer = "X";
    private const string OPlayer = "O";

    public TicTacToeGame()
    {
        _board = new Board();
        _currentPlayer = XPlayer;
    }


    public void Write(Symbol symbol, Coordinates coordinates)
    {
        if (_board.TokenAt(coordinates) != "") 
            throw new Exception(message: "That cell is already taken!, try again");
        _board.WriteASymbol(symbol, coordinates);
        _currentPlayer = _currentPlayer.Equals(XPlayer) 
            ? OPlayer : XPlayer;
    }
    
    public string CurrentStatus()
    {
        return _board.IsEmpty() ? DefaultStatus :
            PlayerXHasWon() ? FormattedBoardStatus() + "\nX Wins!" :
            PlayerOHasWon() ? FormattedBoardStatus() + "\nO Wins!" :
            _board.IsFilled() ? FormattedBoardStatus() + "\n Draw" : 
            FormattedBoardStatus();
    }

    private bool PlayerXHasWon()
    {
        return _board.AColumnHasBeenFilledBy(XPlayer) || 
               _board.ARowHasBeenFilledBy(XPlayer) ||
               _board.ADiagonalRowHasBeenFilledBy(XPlayer);
    }

    private bool PlayerOHasWon()
    {
        return _board.AColumnHasBeenFilledBy(OPlayer) || 
               _board.ARowHasBeenFilledBy(OPlayer) ||
               _board.ADiagonalRowHasBeenFilledBy(OPlayer);
    }

    private string FormattedBoardStatus()
    {
        return
            $"[{_board.TokenAt(new Coordinates(0, 0))}][{_board.TokenAt(new Coordinates(0, 1))}][{_board.TokenAt(new Coordinates(0, 2))}]\n" +
            $"[{_board.TokenAt(new Coordinates(1, 0))}][{_board.TokenAt(new Coordinates(1, 1))}][{_board.TokenAt(new Coordinates(1, 2))}]\n" +
            $"[{_board.TokenAt(new Coordinates(2, 0))}][{_board.TokenAt(new Coordinates(2, 1))}][{_board.TokenAt(new Coordinates(2, 2))}]";
    }

    public string CurrentPlayer()
    {
        return _currentPlayer;
    }
}