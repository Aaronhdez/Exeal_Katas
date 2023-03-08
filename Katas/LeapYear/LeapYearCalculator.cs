namespace LeapYear;

public class LeapYearCalculator
{
    public static bool IsALeapYear(int year)
    {
        return IsDivisibleBy400(year) || IsDivisibleBy4(year) && !IsDivisibleBy100(year);
    }

    private static bool IsDivisibleBy400(int year)
    {
        return year % 400 == 0;
    }

    private static bool IsDivisibleBy100(int year)
    {
        return year % 100 == 0;
    }

    private static bool IsDivisibleBy4(int year)
    {
        return year % 4 == 0;
    }
}