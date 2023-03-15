using TicTacToe.Model;

namespace TicTacToe;

public class Game
{
    private string _currentPlayer;
    private Board _board;
    private const string DefaultStatus = "[][][]\n[][][]\n[][][]";
    private const string XPlayer = "X";
    private const string OPlayer = "O";

    public Game()
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
    
    public string GetResult()
    {
        return _board.IsEmpty() ? DefaultStatus :
            PlayerXHasWon() ? FormattedBoardStatus() + "\nX Wins!" :
            PlayerOHasWon() ? FormattedBoardStatus() + "\nO Wins!" :
            _board.IsFilled() ? FormattedBoardStatus() + "\n Draw" : 
            FormattedBoardStatus();
    }

    private bool PlayerXHasWon()
    {
        return AColumnHasBeenFilledBy(XPlayer) || 
               ARowHasBeenFilledBy(XPlayer) ||
               ADiagonalRowHasBeenFilledBy(XPlayer);
    }

    private bool PlayerOHasWon()
    {
        return AColumnHasBeenFilledBy(OPlayer) || 
               ARowHasBeenFilledBy(OPlayer) ||
               ADiagonalRowHasBeenFilledBy(OPlayer);
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

    private bool AColumnHasBeenFilledBy(string player)
    {
        for (var y = 0; y < 3; y++)
        {
            if (_board.TokenAt(new Coordinates(0, y)) == player
                && _board.TokenAt(new Coordinates(0, y)) ==
                _board.TokenAt(new Coordinates(1, y))
                && _board.TokenAt(new Coordinates(1, y)) ==
                _board.TokenAt(new Coordinates(2, y)))
                return true;
        }
        return false;
    }

    private bool ARowHasBeenFilledBy(string player)
    {
        for (var x = 0; x < 3; x++)
        {
            if (_board.TokenAt(new Coordinates(x, 2)) == player
                && _board.TokenAt(new Coordinates(x, 2)) ==
                _board.TokenAt(new Coordinates(x, 1))
                && _board.TokenAt(new Coordinates(x, 1)) ==
                _board.TokenAt(new Coordinates(x, 0)))
                return true;
        }
        return false;
    }

    private bool ADiagonalRowHasBeenFilledBy(string player)
    {
        if (_board.TokenAt(new Coordinates(2, 2)) == player
            && _board.TokenAt(new Coordinates(2, 2)) ==
            _board.TokenAt(new Coordinates(1, 1))
            && _board.TokenAt(new Coordinates(1, 1)) ==
            _board.TokenAt(new Coordinates(0, 0)))
            return true;
        if (_board.TokenAt(new Coordinates(0, 2)) == player
            && _board.TokenAt(new Coordinates(0, 2)) ==
            _board.TokenAt(new Coordinates(1, 1))
            && _board.TokenAt(new Coordinates(1, 1)) ==
            _board.TokenAt(new Coordinates(2, 0)))
            return true;
        return false;
    }
}