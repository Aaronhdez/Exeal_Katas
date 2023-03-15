using TicTacToe.Model;

namespace TicTacToe;

public static class Program
{
    public static void Main(string[] args)
    {
        var ticTacToeGame = new Game();
        Console.WriteLine("TicTacToe!");
        while (true)
        {
            if (Play(ticTacToeGame)) break;
        }
        
    }

    private static bool Play(Game game)
    {
        if (GameIsOver(game))
        {
            Console.WriteLine(game.CurrentStatus());
            return true;
        }

        PlayTurn(game);
        Console.Clear();
        return false;
    }

    private static void PlayTurn(Game game)
    {
        Console.WriteLine(game.CurrentStatus());
        Console.WriteLine($"{game.CurrentPlayer()} Goes...");
        Console.WriteLine("Coordinate X");
        var coordinateX = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Coordinate Y");
        var coordinateY = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine();
        try
        {
            game.Write(
                new Symbol(game.CurrentPlayer()),
                new Coordinates(coordinateX, coordinateY));
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            Console.ReadLine();
        }
    }

    private static bool GameIsOver(Game game)
    {
        return game.CurrentStatus().Contains("Wins") || game.CurrentStatus().Contains("Draw");
    }
}