namespace TicTacToe.Test;

public class TicTacToeGameShould
{
    private readonly string _ySymbol = "O";
    private readonly string _xSymbol = "X";
    private TicTacToeGame _ticTacToeGame;

    [SetUp]
    public void Setup()
    {
        _ticTacToeGame = new TicTacToeGame();
    }

    [Test]
    public void BeEmptyAtTheBeginningOfTheGame()
    {
        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[][][]\n[][][]\n[][][]");
    }

    [Test]
    public void NotBeEmptyIfASymbolIsInserted()
    {
        _ticTacToeGame.Board.WriteASymbol(new Symbol(_xSymbol), new Coordinates(0, 0));
        
        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[X][][]\n[][][]\n[][][]");
    }

    [Test]
    public void WriteASymbolIfCoordinatesNotTaken()
    {
        var coordinates = new Coordinates(0,0);
        _ticTacToeGame.Board.WriteASymbol(new Symbol(_ySymbol), coordinates);

        var result = _ticTacToeGame.CurrentStatus(); 
        
        result.Should().Be("[O][][]\n[][][]\n[][][]");
    }
    
    [Test]
    public void NotWriteASymbolIfCoordinatesAreAlreadyTaken()
    {
        var coordinates = new Coordinates(0,0);
        _ticTacToeGame.Board.WriteASymbol(new Symbol(_xSymbol), coordinates);
        _ticTacToeGame.Board.WriteASymbol(new Symbol(_ySymbol), coordinates);

        var result = _ticTacToeGame.Board.SymbolAt(coordinates); 
        
        result.Should().Be(_xSymbol);
    }
    
    
}