namespace TicTacToe.Test;

public class TicTacToeGameShould
{
    private readonly string _oSymbol = "O";
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
        _ticTacToeGame.Write(new Symbol(_xSymbol), new Coordinates(0, 0));
        
        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[X][][]\n[][][]\n[][][]");
    }

    [Test]
    public void WriteASymbolIfCoordinatesNotTaken()
    {
        var coordinates = new Coordinates(0,0);
        _ticTacToeGame.Write(new Symbol(_oSymbol), coordinates);

        var result = _ticTacToeGame.CurrentStatus(); 
        
        result.Should().Be("[O][][]\n[][][]\n[][][]");
    }
    
    [Test]
    public void NotWriteASymbolIfCoordinatesAreAlreadyTaken()
    {
        var coordinates = new Coordinates(0,0);
        _ticTacToeGame.Write(new Symbol(_xSymbol), coordinates);

        var result = _ticTacToeGame.CurrentStatus();  
        
        result.Should().Be("[X][][]\n[][][]\n[][][]");
    }

    [Test]
    public void WriteASymbolAtAnyPlaceOfTheBoard()
    {
        var firstCoordinates = new Coordinates(0,0);
        var secondCoordinates = new Coordinates(2,1);
        _ticTacToeGame.Write(new Symbol(_oSymbol), firstCoordinates);
        _ticTacToeGame.Write(new Symbol(_xSymbol), secondCoordinates);
        
        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[O][][]\n[][][]\n[][X][]");
    }

    [Test]
    public void ThrowExceptionIfAPlayerTriesToWriteOutsideUpperBound()
    {
        var result = () => _ticTacToeGame.Write(new Symbol(_xSymbol), new Coordinates(0,-1));

        result.Should().Throw<IndexOutOfRangeException>();
    }
    
    [Test]
    public void ThrowExceptionIfAPlayerTriesToWriteOutsideLowerBound()
    {
        var result = () => _ticTacToeGame.Write(new Symbol(_xSymbol), new Coordinates(0,3));

        result.Should().Throw<IndexOutOfRangeException>();
    }
    
    [Test]
    public void ThrowExceptionIfAPlayerTriesToWriteOutsideLeftBound()
    {
        var result = () => _ticTacToeGame.Write(new Symbol(_xSymbol), new Coordinates(-1,0));

        result.Should().Throw<IndexOutOfRangeException>();
    }
    
}