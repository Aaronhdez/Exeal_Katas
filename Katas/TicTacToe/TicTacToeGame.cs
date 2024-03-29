﻿using TicTacToe.Model;

namespace TicTacToe;

public class TicTacToeGame
{
    private string _currentPlayer;
    private const string DefaultStatus = "[][][]\n[][][]\n[][][]";
    private const string XPlayer = "X";
    private const string OPlayer = "O";

    public TicTacToeGame()
    {
        Board = new Board();
        _currentPlayer = XPlayer;
    }

    private Board Board { get; }


    public void Write(Symbol symbol, Coordinates coordinates)
    {
        if (Board.SymbolAt(coordinates) != "") 
            throw new Exception(message: "That cell is already taken!, try again");
        Board.WriteASymbol(symbol, coordinates);
        _currentPlayer = _currentPlayer.Equals(XPlayer) 
            ? OPlayer : XPlayer;
    }
    
    public string CurrentStatus()
    {
        if (Board.IsEmpty()) return DefaultStatus;
        if (PlayerXHasWon()) return FormattedBoardStatus() + "\nX Wins!";
        if (PlayerOHasWon()) return FormattedBoardStatus() + "\nO Wins!";
        if (Board.IsFilled()) return FormattedBoardStatus() + "\n Draw";
        return FormattedBoardStatus();
    }

    private bool PlayerXHasWon()
    {
        if (Board.AColumnHasBeenFilledBy(XPlayer)) return true;
        if (Board.ARowHasBeenFilledBy(XPlayer)) return true;
        if (Board.ADiagonalRowHasBeenFilledBy(XPlayer)) return true;
        return false;
    }

    private bool PlayerOHasWon()
    {
        if (Board.AColumnHasBeenFilledBy(OPlayer)) return true;
        if (Board.ARowHasBeenFilledBy(OPlayer)) return true;
        if (Board.ADiagonalRowHasBeenFilledBy(OPlayer)) return true;
        return false;
    }

    private string FormattedBoardStatus()
    {
        return
            $"[{Board.SymbolAt(new Coordinates(0, 0))}][{Board.SymbolAt(new Coordinates(0, 1))}][{Board.SymbolAt(new Coordinates(0, 2))}]\n" +
            $"[{Board.SymbolAt(new Coordinates(1, 0))}][{Board.SymbolAt(new Coordinates(1, 1))}][{Board.SymbolAt(new Coordinates(1, 2))}]\n" +
            $"[{Board.SymbolAt(new Coordinates(2, 0))}][{Board.SymbolAt(new Coordinates(2, 1))}][{Board.SymbolAt(new Coordinates(2, 2))}]";
    }

    public string CurrentPlayer()
    {
        return _currentPlayer;
    }
}