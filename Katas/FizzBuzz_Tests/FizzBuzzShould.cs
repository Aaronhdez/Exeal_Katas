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
        public void Return_a_number_itself_when_is_not_divisible_neither_by_3_or_5(int number, string expectedResult)
        {
            var result = FizzBuzzGame.FizzBuzz(number);

            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void Return_fizz_when_3_is_set_as_parameter()
        {
            var result = FizzBuzzGame.FizzBuzz(3);

            Assert.AreEqual(result, "fizz");
        }

        [Test]
        public void Return_buzz_when_5_is_set_as_parameter()
        {
            var result = FizzBuzzGame.FizzBuzz(5);

            Assert.AreEqual(result, "buzz");
        }

        [Test]
        public void Return_fizz_when_6_is_set_as_parameter()
        {
            var result = FizzBuzzGame.FizzBuzz(6);

            Assert.AreEqual(result, "fizz");
        }

        [Test]
        public void Return_fizz_when_9_is_set_as_parameter()
        {
            var result = FizzBuzzGame.FizzBuzz(9);

            Assert.AreEqual(result, "fizz");
        }
    }
}