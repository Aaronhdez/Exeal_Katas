namespace FizzBuzz
{
    public class FizzBuzzGame
    {
        public static string FizzBuzz(int number)
        {
            return IsDivisibleBy3(number) && IsDivisibleBy5(number) ? "fizz buzz" :
                IsDivisibleBy3(number) ? "fizz" :
                IsDivisibleBy5(number) ? "buzz" :
                number.ToString();
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
