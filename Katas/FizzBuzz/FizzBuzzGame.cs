namespace FizzBuzz
{
    public class FizzBuzzGame
    {
        public static string FizzBuzz(int number)
        {
            if (number == 3) return "fizz";
            if (number == 5) return "buzz";
            return number.ToString();
        }
    }
}
