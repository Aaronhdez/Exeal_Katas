namespace LeapYear;

public class LeapYearCalculator
{
    public static bool IsALeapYear(int year)
    {
        if (year <= 0) return false;
        return IsDivisibleBy(400, year) ||
               IsDivisibleBy(4, year) && !IsDivisibleBy(100, year);
    }

    private static bool IsDivisibleBy(int divisor, int year)
    {
        return year % divisor == 0;
    }
}