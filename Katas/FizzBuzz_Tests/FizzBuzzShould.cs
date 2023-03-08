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
        public void Return_a_number_itself_when_is_not_divisible_neither_by_3_or_5(int number, string expectedResult)
        {
            var result = FizzBuzzGame.FizzBuzz(number);

            Assert.AreEqual(result, expectedResult);
        }

        [TestCase(3, "fizz")]
        [TestCase(6, "fizz")]
        [TestCase(9, "fizz")]
        [TestCase(12, "fizz")]
        public void Return_fizz_when_a_number_is_divisible_by_3(int number, string expectedResult)
        {
            var result = FizzBuzzGame.FizzBuzz(number);

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void Return_buzz_when_5_is_set_as_parameter()
        {
            var result = FizzBuzzGame.FizzBuzz(5);

            Assert.AreEqual(result, "buzz");
        }

        [Test]
        public void Return_buzz_when_10_is_set_as_parameter()
        {
            var result = FizzBuzzGame.FizzBuzz(10);

            Assert.AreEqual(result, "buzz");
        }

    }
}