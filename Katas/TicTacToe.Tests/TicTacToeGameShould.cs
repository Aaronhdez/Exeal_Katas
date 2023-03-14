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
}