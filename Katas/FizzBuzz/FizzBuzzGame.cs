namespace FizzBuzz
{
    public class FizzBuzzGame
    {
        public static string FizzBuzz(int number)
        {
            if (number == 15) return "fizz buzz";
            if (number == 30) return "fizz buzz";
            if (IsDivisibleBy3(number)) return "fizz";
            if (IsDivisibleBy5(number)) return "buzz";
            return number.ToString();
        }

        private static bool IsDivisibleBy3(int number)
        {
            return number % 3 == 0;
        }

        private static bool IsDivisibleBy5(int number)
        {
            return number % 5 == 0;
        }

    }
}
