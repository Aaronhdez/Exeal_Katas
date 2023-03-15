namespace TicTacToe;

public class Program
{
    public static void Main(string[] args)
    {
        var ticTacToeGame = new TicTacToeGame();
        Console.WriteLine("TicTacToe!");
        Console.Write($"{ticTacToeGame.CurrentPlayer()} Goes...");
        Console.WriteLine("Coordinate x");
        Console.ReadLine();
        Console.WriteLine("Coordinate Y");
        Console.WriteLine();
    }
}