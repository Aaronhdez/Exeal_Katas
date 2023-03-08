namespace FizzBuzz
{
    public class FizzBuzzGame
    {
        public static string FizzBuzz(int number)
        {
            if (IsDivisibleBy3(number)) return "fizz";
            if (number == 5) return "buzz";
            return number.ToString();
        }

        private static bool IsDivisibleBy3(int number)
        {
            return number % 3 == 0;
        }
    }
}
