using TicTacToe.Model;

namespace TicTacToe;

public class Program
{
    public static void Main(string[] args)
    {
        var ticTacToeGame = new TicTacToeGame();
        Console.WriteLine("TicTacToe!");
        while (true)
        {
            Console.Write($"{ticTacToeGame.CurrentPlayer()} Goes...");
            Console.WriteLine("Coordinate X");
            var coodinateX = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Coordinate Y");
            var coodinateY = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine();
            try
            {
                ticTacToeGame.Write(
                    new Symbol(ticTacToeGame.CurrentPlayer()), 
                    new Coordinates(coodinateX,coodinateY));
                Console.WriteLine(ticTacToeGame.CurrentStatus());
            }
            catch (Exception e)
            {
                Console.WriteLine("That cell is already taken!, try again");
                Console.ReadLine();
                throw;
            }
        }
        
    }
}