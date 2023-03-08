using FizzBuzz;

namespace FizzBuzz_Tests
{
    public class FizzBuzzShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(4, "4")]
        [TestCase(7, "7")]
        [TestCase(8, "8")]
        [TestCase(11, "11")]
        [TestCase(13, "13")]
        [TestCase(14, "14")]
        [TestCase(16, "16")]
        [TestCase(17, "17")]
        [TestCase(19, "19")]
        [TestCase(22, "22")]
        [TestCase(23, "23")]
        [TestCase(26, "26")]
        [TestCase(28, "28")]
        [TestCase(29, "29")]
        public void Return_a_number_itself_when_is_not_divisible_neither_by_3_or_5(int number, string expectedResult)
        {
            var result = FizzBuzzGame.FizzBuzz(number);

            Assert.AreEqual(result, expectedResult);
        }

        [TestCase(3, "fizz")]
        [TestCase(6, "fizz")]
        [TestCase(9, "fizz")]
        [TestCase(12, "fizz")]
        [TestCase(18, "fizz")]
        [TestCase(21, "fizz")]
        [TestCase(24, "fizz")]
        [TestCase(27, "fizz")]
        public void Return_fizz_when_a_number_is_divisible_by_3(int number, string expectedResult)
        {
            var result = FizzBuzzGame.FizzBuzz(number);

            Assert.AreEqual(result, expectedResult);
        }

        [TestCase(5, "buzz")]
        [TestCase(10, "buzz")]
        [TestCase(20, "buzz")]
        [TestCase(25, "buzz")]
        public void Return_buzz_when_a_number_is_divisible_by_5(int number, string expectedResult)
        {
            var result = FizzBuzzGame.FizzBuzz(number);

            Assert.AreEqual(result, expectedResult);
        }

        [TestCase(15, "fizz buzz")]
        [TestCase(30, "fizz buzz")]
        [TestCase(45, "fizz buzz")]
        public void Return_fizz_buzz_when_a_number_is_divisible_both_by_5_and_3(int number, string expectedResult)
        {
            var result = FizzBuzzGame.FizzBuzz(number);

            Assert.AreEqual(result, expectedResult);
        }

    }
}