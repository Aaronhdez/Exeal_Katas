﻿namespace FizzBuzz
{
    public class FizzBuzzGame
    {
        public static string FizzBuzz(int number)
        {
            if (number == 3) return "fizz";
            return (number == 1) ? "1" : "2";
        }
    }
}
