using TicTacToe.Model;

namespace TicTacToe;

public static class Program
{
    public static void Main(string[] args)
    {
        var ticTacToeGame = new TicTacToeGame();
        Console.WriteLine("TicTacToe!");
        while (true)
        {
            if (Play(ticTacToeGame)) break;
        }
        
    }

    private static bool Play(TicTacToeGame ticTacToeGame)
    {
        if (GameIsOver(ticTacToeGame))
        {
            Console.WriteLine(ticTacToeGame.CurrentStatus());
            return true;
        }

        PlayTurn(ticTacToeGame);
        Console.Clear();
        return false;
    }

    private static void PlayTurn(TicTacToeGame ticTacToeGame)
    {
        Console.WriteLine(ticTacToeGame.CurrentStatus());
        Console.WriteLine($"{ticTacToeGame.CurrentPlayer()} Goes...");
        Console.WriteLine("Coordinate X");
        var coordinateX = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Coordinate Y");
        var coordinateY = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine();
        try
        {
            ticTacToeGame.Write(
                new Symbol(ticTacToeGame.CurrentPlayer()),
                new Coordinates(coordinateX, coordinateY));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            Console.ReadLine();
        }
    }

    private static bool GameIsOver(TicTacToeGame ticTacToeGame)
    {
        return ticTacToeGame.CurrentStatus().Contains("Wins") || ticTacToeGame.CurrentStatus().Contains("Draw");
    }
}