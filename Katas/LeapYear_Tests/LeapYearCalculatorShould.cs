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

        [Test]
        public void Return_false_if_the_year_is_not_divisible_by_400_but_is_divisible_by_100()
        {
            var result = LeapYearCalculator.IsALeapYear(1900);

            Assert.IsFalse(result);
        }

        [Test]
        public void Return_true_if_the_year_is_divisible_by_4_but_is_not_divisible_by_100()
        {
            var result = LeapYearCalculator.IsALeapYear(2024);

            Assert.IsTrue(result);
        }

        [Test]
        public void Return_false_if_the_year_is_not_divisible_by_4()
        {
            var result = LeapYearCalculator.IsALeapYear(2021);

            Assert.IsFalse(result);
        }

        [TestCase(2008)]
        [TestCase(2012)]
        [TestCase(2016)]
        public void return_true_if_is_a_leap_year(int year)
        {
            var result = LeapYearCalculator.IsALeapYear(year);

            Assert.IsTrue(result);
        }

        [TestCase(2006)]
        [TestCase(2007)]
        [TestCase(2013)]
        [TestCase(2014)]
        [TestCase(2018)]
        [TestCase(2022)]
        public void return_false_if_is_not_a_leap_year(int year)
        {
            var result = LeapYearCalculator.IsALeapYear(year);

            Assert.IsFalse(result);
        }

        [Test]
        public void return_false_if_a_year_is_zero()
        {
            var result = LeapYearCalculator.IsALeapYear(0);

            Assert.IsFalse(result);
        }

        [Test]
        public void return_false_if_a_year_is_less_than_zero()
        {
            var result = LeapYearCalculator.IsALeapYear(-4);

            Assert.IsFalse(result);
        }
    }
}