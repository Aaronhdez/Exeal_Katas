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
        var ticTacToeGame = new TicTacToeGame();
        var result = ticTacToeGame.BoardIsEmpty();
        
        result.Should().BeTrue();
    }

    [Test]
    public void NotBeEmptyIfASymbolIsInserted()
    {
        var ticTacToeGame = new TicTacToeGame();
        ticTacToeGame.WriteASymbol("X", new Coordinates(0, 0));
        
        var result = ticTacToeGame.BoardIsEmpty();
        
        result.Should().BeFalse();
    }

    [Test]
    public void WriteASymbolIfCoordinatesAreAlreadyTaken()
    {
        var ticTacToeGame = new TicTacToeGame();
        var coordinates = new Coordinates(0,0);
        ticTacToeGame.WriteASymbol("Y", coordinates);

        var result = ticTacToeGame.SymbolAt(coordinates); 
        
        result.Should().Be("Y");
    }
}