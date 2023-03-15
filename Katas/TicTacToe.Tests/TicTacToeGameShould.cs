namespace TicTacToe.Test;

public class TicTacToeGameShould
{
    private const string OSymbol = "O";
    private const string XSymbol = "X";
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
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(0, 0));

        var result = _ticTacToeGame.CurrentStatus();

        result.Should().Be("[X][][]\n[][][]\n[][][]");
    }

    [Test]
    public void WriteASymbolIfCoordinatesNotTaken()
    {
        var coordinates = new Coordinates(0, 0);
        _ticTacToeGame.Write(new Symbol(OSymbol), coordinates);

        var result = _ticTacToeGame.CurrentStatus();

        result.Should().Be("[O][][]\n[][][]\n[][][]");
    }

    [Test]
    public void NotWriteASymbolIfCoordinatesAreAlreadyTaken()
    {
        var coordinates = new Coordinates(0, 0);
        _ticTacToeGame.Write(new Symbol(XSymbol), coordinates);

        var result = _ticTacToeGame.CurrentStatus();

        result.Should().Be("[X][][]\n[][][]\n[][][]");
    }

    [Test]
    public void WriteASymbolAtAnyPlaceOfTheBoard()
    {
        var firstCoordinates = new Coordinates(0, 0);
        var secondCoordinates = new Coordinates(2, 1);
        _ticTacToeGame.Write(new Symbol(OSymbol), firstCoordinates);
        _ticTacToeGame.Write(new Symbol(XSymbol), secondCoordinates);

        var result = _ticTacToeGame.CurrentStatus();

        result.Should().Be("[O][][]\n[][][]\n[][X][]");
    }

    [TestCase(0, -1)]
    [TestCase(0, 3)]
    [TestCase(-1, -0)]
    [TestCase(3, 0)]
    public void ThrowExceptionIfAPlayerTriesToWriteOutsideBounds(int x, int y)
    {
        var result = () => _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(x, y));

        result.Should().Throw<IndexOutOfRangeException>();
    }

    [Test]
    public void DisplayWinningMessageIfXPlayerFillsFirstColumn()
    {
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(0,0));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(0,2));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(1,0));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(1,1));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(2,0));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(2,2));

        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[X][][O]\n[X][O][]\n[X][][O]\nX Wins!");
    }
    
    [Test]
    public void DisplayWinningMessageIfOPlayerFillsFirstColumn()
    {
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(0,0));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(0,2));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(1,0));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(1,1));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(2,0));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(2,2));

        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[O][][X]\n[O][X][]\n[O][][X]\nO Wins!");
    }
    
    [Test]
    public void DisplayWinningMessageIfXPlayerFillsSecondColumn()
    {
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(0,1));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(0,2));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(1,1));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(1,0));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(2,1));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(2,2));

        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[][X][O]\n[O][X][]\n[][X][O]\nX Wins!");
    }
    
    [Test]
    public void DisplayWinningMessageIfOPlayerFillsSecondColumn()
    {
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(0,1));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(0,2));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(1,1));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(1,0));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(2,1));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(2,2));

        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[][O][X]\n[X][O][]\n[][O][X]\nO Wins!");
    }
    
    [Test]
    public void DisplayWinningMessageIfXPlayerFillsThirdColumn()
    {
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(0,2));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(0,0));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(1,2));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(1,0));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(2,2));

        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[O][][X]\n[O][][X]\n[][][X]\nX Wins!");
    }
    
    [Test]
    public void DisplayWinningMessageIfOPlayerFillsThirdColumn()
    {
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(0,2));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(0,0));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(1,2));
        _ticTacToeGame.Write(new Symbol(XSymbol), new Coordinates(1,0));
        _ticTacToeGame.Write(new Symbol(OSymbol), new Coordinates(2,2));

        var result = _ticTacToeGame.CurrentStatus();
        
        result.Should().Be("[X][][O]\n[X][][O]\n[][][O]\nO Wins!");
    }
}