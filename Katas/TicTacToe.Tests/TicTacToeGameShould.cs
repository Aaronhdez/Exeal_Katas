namespace TicTacToe.Test;

public class TicTacToeGameShould
{
    private readonly string _ySymbol = "Y";
    private readonly string _xSymbol = "X";

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
        ticTacToeGame.WriteASymbol(new Symbol(_xSymbol), new Coordinates(0, 0));
        
        var result = ticTacToeGame.BoardIsEmpty();
        
        result.Should().BeFalse();
    }

    [Test]
    public void WriteASymbolIfCoordinatesAreAlreadyTaken()
    {
        var ticTacToeGame = new TicTacToeGame();
        var coordinates = new Coordinates(0,0);
        ticTacToeGame.WriteASymbol(new Symbol(_ySymbol), coordinates);

        var result = ticTacToeGame.SymbolAt(coordinates); 
        
        result.Should().Be(_ySymbol);
    }
    
    [Test]
    public void NotWriteASymbolIfCoordinatesAreAlreadyTaken()
    {
        var ticTacToeGame = new TicTacToeGame();
        var coordinates = new Coordinates(0,0);
        ticTacToeGame.WriteASymbol(new Symbol(_xSymbol), coordinates);
        ticTacToeGame.WriteASymbol(new Symbol(_ySymbol), coordinates);

        var result = ticTacToeGame.SymbolAt(coordinates); 
        
        result.Should().Be(_xSymbol);
    }
    
}