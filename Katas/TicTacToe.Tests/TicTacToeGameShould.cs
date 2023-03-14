namespace TicTacToe.Test;

public class TicTacToeGameShould
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BeEmptyAtTheBeginningOfTheGame()
    {
        var result = TicTacToeGame.BoardIsEmpty();
        
        result.Should().BeTrue();
    }


    [Test]
    public void NotBeEmptyIfASymbolIsInserted()
    {
        TicTacToeGame.WriteASymbol("X", new Coordinates(0, 0));
        
        var result = TicTacToeGame.BoardIsEmpty();
        
        result.Should().BeFalse();
        
    }
}