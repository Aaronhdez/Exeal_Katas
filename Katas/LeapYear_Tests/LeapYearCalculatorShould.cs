using LeapYear;

namespace LeapYear_Tests
{
    public class LeapYearCalculatorShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Return_true_if_the_year_is_divisible_by_400()
        {
            var result = LeapYearCalculator.IsALeapYear(2000);

            Assert.IsTrue(result);
        }

        [Test]
        public void Return_true_if_the_year_is_not_divisible_by_400()
        {
            var result = LeapYearCalculator.IsALeapYear(2001);

            Assert.IsFalse(result);
        }
    }
}