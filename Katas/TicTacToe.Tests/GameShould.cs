using TicTacToe.Model;

namespace TicTacToe.Test;

public class GameShould
{
    private const string OSymbol = "O";
    private const string XSymbol = "X";
    private Game _game;

    [SetUp]
    public void Setup()
    {
        _game = new Game();
    }

    [Test]
    public void BeEmptyAtTheBeginningOfTheGame()
    {
        var result = _game.GetResult();

        result.Should().Be("[][][]\n[][][]\n[][][]");
    }

    [Test]
    public void NotBeEmptyIfASymbolIsInserted()
    {
        _game.Write(new Token(XSymbol), new Coordinates(0, 0));

        var result = _game.GetResult();

        result.Should().Be("[X][][]\n[][][]\n[][][]");
    }

    [Test]
    public void WriteASymbolIfCoordinatesNotTaken()
    {
        var coordinates = new Coordinates(0, 0);
        _game.Write(new Token(OSymbol), coordinates);

        var result = _game.GetResult();

        result.Should().Be("[O][][]\n[][][]\n[][][]");
    }

    [Test]
    public void NotWriteASymbolIfCoordinatesAreAlreadyTaken()
    {
        var coordinates = new Coordinates(0, 0);
        _game.Write(new Token(XSymbol), coordinates);

        var result = _game.GetResult();

        result.Should().Be("[X][][]\n[][][]\n[][][]");
    }

    [Test]
    public void WriteASymbolAtAnyPlaceOfTheBoard()
    {
        var firstCoordinates = new Coordinates(0, 0);
        var secondCoordinates = new Coordinates(2, 1);
        _game.Write(new Token(OSymbol), firstCoordinates);
        _game.Write(new Token(XSymbol), secondCoordinates);

        var result = _game.GetResult();

        result.Should().Be("[O][][]\n[][][]\n[][X][]");
    }

    [TestCase(0, -1)]
    [TestCase(0, 3)]
    [TestCase(-1, -0)]
    [TestCase(3, 0)]
    public void ThrowExceptionIfAPlayerTriesToWriteOutsideBounds(int x, int y)
    {
        var result = () => _game.Write(new Token(XSymbol), new Coordinates(x, y));

        result.Should().Throw<IndexOutOfRangeException>();
    }

    [TestFixture]
    public class WhenPlayerXHasWon : GameShould
    {
        [Test]
        public void DisplayWinningMessageIfXPlayerFillsFirstColumn()
        {
            _game.Write(new Token(XSymbol), new Coordinates(0, 0));
            _game.Write(new Token(OSymbol), new Coordinates(0, 2));
            _game.Write(new Token(XSymbol), new Coordinates(1, 0));
            _game.Write(new Token(OSymbol), new Coordinates(1, 1));
            _game.Write(new Token(XSymbol), new Coordinates(2, 0));
            _game.Write(new Token(OSymbol), new Coordinates(2, 2));

            var result = _game.GetResult();

            result.Should().Be("[X][][O]\n[X][O][]\n[X][][O]\nX Wins!");
        }

        [Test]
        public void DisplayWinningMessageIfXPlayerFillsSecondColumn()
        {
            _game.Write(new Token(XSymbol), new Coordinates(0, 1));
            _game.Write(new Token(OSymbol), new Coordinates(0, 2));
            _game.Write(new Token(XSymbol), new Coordinates(1, 1));
            _game.Write(new Token(OSymbol), new Coordinates(1, 0));
            _game.Write(new Token(XSymbol), new Coordinates(2, 1));
            _game.Write(new Token(OSymbol), new Coordinates(2, 2));

            var result = _game.GetResult();

            result.Should().Be("[][X][O]\n[O][X][]\n[][X][O]\nX Wins!");
        }

        [Test]
        public void DisplayWinningMessageIfXPlayerFillsThirdColumn()
        {
            _game.Write(new Token(XSymbol), new Coordinates(0, 2));
            _game.Write(new Token(OSymbol), new Coordinates(0, 0));
            _game.Write(new Token(XSymbol), new Coordinates(1, 2));
            _game.Write(new Token(OSymbol), new Coordinates(1, 0));
            _game.Write(new Token(XSymbol), new Coordinates(2, 2));

            var result = _game.GetResult();

            result.Should().Be("[O][][X]\n[O][][X]\n[][][X]\nX Wins!");
        }

        [Test]
        public void DisplayWinningMessageIfXPlayerFillsFirstRow()
        {
            _game.Write(new Token(XSymbol), new Coordinates(0,0));
            _game.Write(new Token(OSymbol), new Coordinates(1,2));
            _game.Write(new Token(XSymbol), new Coordinates(0,1));
            _game.Write(new Token(OSymbol), new Coordinates(2,1));
            _game.Write(new Token(XSymbol), new Coordinates(0,2));
            _game.Write(new Token(OSymbol), new Coordinates(2,2));

            var result = _game.GetResult();
        
            result.Should().Be("[X][X][X]\n[][][O]\n[][O][O]\nX Wins!");
        }
    
        [Test]
        public void DisplayWinningMessageIfXPlayerFillsSecondRow()
        {
            _game.Write(new Token(XSymbol), new Coordinates(1,0));
            _game.Write(new Token(OSymbol), new Coordinates(0,2));
            _game.Write(new Token(XSymbol), new Coordinates(1,1));
            _game.Write(new Token(OSymbol), new Coordinates(2,1));
            _game.Write(new Token(XSymbol), new Coordinates(1,2));
            _game.Write(new Token(OSymbol), new Coordinates(2,2));

            var result = _game.GetResult();
        
            result.Should().Be("[][][O]\n[X][X][X]\n[][O][O]\nX Wins!");
        }
    
        [Test]
        public void DisplayWinningMessageIfXPlayerFillsThirdRow()
        {
            _game.Write(new Token(XSymbol), new Coordinates(2,0));
            _game.Write(new Token(OSymbol), new Coordinates(0,2));
            _game.Write(new Token(XSymbol), new Coordinates(2,1));
            _game.Write(new Token(OSymbol), new Coordinates(1,1));
            _game.Write(new Token(XSymbol), new Coordinates(2,2));
            _game.Write(new Token(OSymbol), new Coordinates(1,2));

            var result = _game.GetResult();
        
            result.Should().Be("[][][O]\n[][O][O]\n[X][X][X]\nX Wins!");
        }
        
        [Test]
        public void DisplayWinningMessageIfXPlayerFillsFirstDiagonal()
        {
            _game.Write(new Token(XSymbol), new Coordinates(0,0));
            _game.Write(new Token(OSymbol), new Coordinates(0,2));
            _game.Write(new Token(XSymbol), new Coordinates(1,1));
            _game.Write(new Token(OSymbol), new Coordinates(1,2));
            _game.Write(new Token(XSymbol), new Coordinates(2,2));

            var result = _game.GetResult();
        
            result.Should().Be("[X][][O]\n[][X][O]\n[][][X]\nX Wins!");
        }
        
        [Test]
        public void DisplayWinningMessageIfXPlayerFillsSecondDiagonal()
        {
            _game.Write(new Token(XSymbol), new Coordinates(0,2));
            _game.Write(new Token(OSymbol), new Coordinates(0,0));
            _game.Write(new Token(XSymbol), new Coordinates(1,1));
            _game.Write(new Token(OSymbol), new Coordinates(1,2));
            _game.Write(new Token(XSymbol), new Coordinates(2,0));

            var result = _game.GetResult();
        
            result.Should().Be("[O][][X]\n[][X][O]\n[X][][]\nX Wins!");
        }
    }

    [TestFixture]
    public class WhenPlayerOHasWon : GameShould
    {
        [Test]
        public void DisplayWinningMessageIfOPlayerFillsFirstColumn()
        {
            _game.Write(new Token(OSymbol), new Coordinates(0, 0));
            _game.Write(new Token(XSymbol), new Coordinates(0, 2));
            _game.Write(new Token(OSymbol), new Coordinates(1, 0));
            _game.Write(new Token(XSymbol), new Coordinates(1, 1));
            _game.Write(new Token(OSymbol), new Coordinates(2, 0));
            _game.Write(new Token(XSymbol), new Coordinates(2, 2));

            var result = _game.GetResult();

            result.Should().Be("[O][][X]\n[O][X][]\n[O][][X]\nO Wins!");
        }

        [Test]
        public void DisplayWinningMessageIfOPlayerFillsSecondColumn()
        {
            _game.Write(new Token(OSymbol), new Coordinates(0, 1));
            _game.Write(new Token(XSymbol), new Coordinates(0, 2));
            _game.Write(new Token(OSymbol), new Coordinates(1, 1));
            _game.Write(new Token(XSymbol), new Coordinates(1, 0));
            _game.Write(new Token(OSymbol), new Coordinates(2, 1));
            _game.Write(new Token(XSymbol), new Coordinates(2, 2));

            var result = _game.GetResult();

            result.Should().Be("[][O][X]\n[X][O][]\n[][O][X]\nO Wins!");
        }

        [Test]
        public void DisplayWinningMessageIfOPlayerFillsThirdColumn()
        {
            _game.Write(new Token(OSymbol), new Coordinates(0, 2));
            _game.Write(new Token(XSymbol), new Coordinates(0, 0));
            _game.Write(new Token(OSymbol), new Coordinates(1, 2));
            _game.Write(new Token(XSymbol), new Coordinates(1, 0));
            _game.Write(new Token(OSymbol), new Coordinates(2, 2));

            var result = _game.GetResult();

            result.Should().Be("[X][][O]\n[X][][O]\n[][][O]\nO Wins!");
        }

        [Test]
        public void DisplayWinningMessageIfOPlayerFillsFirstRow()
        {
            _game.Write(new Token(OSymbol), new Coordinates(0,0));
            _game.Write(new Token(XSymbol), new Coordinates(1,2));
            _game.Write(new Token(OSymbol), new Coordinates(0,1));
            _game.Write(new Token(XSymbol), new Coordinates(2,1));
            _game.Write(new Token(OSymbol), new Coordinates(0,2));
            _game.Write(new Token(XSymbol), new Coordinates(2,2));

            var result = _game.GetResult();
        
            result.Should().Be("[O][O][O]\n[][][X]\n[][X][X]\nO Wins!");
        }
    
        [Test]
        public void DisplayWinningMessageIfOPlayerFillsSecondRow()
        {
            _game.Write(new Token(OSymbol), new Coordinates(1,0));
            _game.Write(new Token(XSymbol), new Coordinates(0,2));
            _game.Write(new Token(OSymbol), new Coordinates(1,1));
            _game.Write(new Token(XSymbol), new Coordinates(2,1));
            _game.Write(new Token(OSymbol), new Coordinates(1,2));
            _game.Write(new Token(XSymbol), new Coordinates(2,2));

            var result = _game.GetResult();
        
            result.Should().Be("[][][X]\n[O][O][O]\n[][X][X]\nO Wins!");
        }
    
        [Test]
        public void DisplayWinningMessageIfOPlayerFillsThirdRow()
        {
            _game.Write(new Token(OSymbol), new Coordinates(2,0));
            _game.Write(new Token(XSymbol), new Coordinates(0,2));
            _game.Write(new Token(OSymbol), new Coordinates(2,1));
            _game.Write(new Token(XSymbol), new Coordinates(1,1));
            _game.Write(new Token(OSymbol), new Coordinates(2,2));
            _game.Write(new Token(XSymbol), new Coordinates(1,2));

            var result = _game.GetResult();
        
            result.Should().Be("[][][X]\n[][X][X]\n[O][O][O]\nO Wins!");
        }
        
        [Test]
        public void DisplayWinningMessageIfOPlayerFillsFirstDiagonal()
        {
            _game.Write(new Token(OSymbol), new Coordinates(0,0));
            _game.Write(new Token(XSymbol), new Coordinates(0,2));
            _game.Write(new Token(OSymbol), new Coordinates(1,1));
            _game.Write(new Token(XSymbol), new Coordinates(1,2));
            _game.Write(new Token(OSymbol), new Coordinates(2,2));
            
            var result = _game.GetResult();
        
            result.Should().Be("[O][][X]\n[][O][X]\n[][][O]\nO Wins!");
        }
        
        [Test]
        public void DisplayWinningMessageIfOPlayerFillsSecondDiagonal()
        {
            _game.Write(new Token(OSymbol), new Coordinates(0,2));
            _game.Write(new Token(XSymbol), new Coordinates(0,0));
            _game.Write(new Token(OSymbol), new Coordinates(1,1));
            _game.Write(new Token(XSymbol), new Coordinates(1,2));
            _game.Write(new Token(OSymbol), new Coordinates(2,0));
            
            var result = _game.GetResult();
        
            result.Should().Be("[X][][O]\n[][O][X]\n[O][][]\nO Wins!");
        }
    }

    [Test]
    public void DisplayDrawMessageIfNoOneHasWonAndTheBoardIsFull()
    {
        _game.Write(new Token(XSymbol), new Coordinates(0, 1));
        _game.Write(new Token(OSymbol), new Coordinates(0, 0));
        _game.Write(new Token(XSymbol), new Coordinates(1, 0));
        _game.Write(new Token(OSymbol), new Coordinates(0, 2));
        _game.Write(new Token(XSymbol), new Coordinates(1, 1));
        _game.Write(new Token(OSymbol), new Coordinates(2, 1));
        _game.Write(new Token(XSymbol), new Coordinates(2, 0));
        _game.Write(new Token(OSymbol), new Coordinates(1, 2));
        _game.Write(new Token(XSymbol), new Coordinates(2, 2));
        
        var result = _game.GetResult();
        
        result.Should().Be("[O][X][O]\n[X][X][O]\n[X][O][X]\n Draw");
    }

    [Test]
    public void ShowXPlayerTurnAtTheBeginning()
    {
        var result = _game.CurrentPlayer();
        
        result.Should().Be("X");
    }

    [Test]
    public void ShowOPlayerTurnAfterPlayerXWritesALetter()
    {
        var coordinates = new Coordinates(0, 0);
        _game.Write(new Token("X"), coordinates);
        
        var result = _game.CurrentPlayer();
        
        result.Should().Be("O");
    }
    
    [Test]
    public void SwitchTurnToPlayerXAfterPlayerOWritesALetter()
    {
        var coordinates = new Coordinates(0, 0);
        var coordinates2 = new Coordinates(1, 0);
        _game.Write(new Token("X"), coordinates);
        _game.Write(new Token("O"), coordinates2);
        
        var result = _game.CurrentPlayer();
        
        result.Should().Be("X");
    }
}