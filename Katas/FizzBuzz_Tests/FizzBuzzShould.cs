using FizzBuzz;

namespace FizzBuzz_Tests
{
    public class FizzBuzzShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Return_1_when_1_is_set_as_parameter()
        {
            var result = FizzBuzzGame.FizzBuzz("1");

            Assert.AreEqual(result, "1");
        }
    }
}