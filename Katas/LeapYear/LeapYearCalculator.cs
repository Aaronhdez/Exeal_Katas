namespace LeapYear;

public class LeapYearCalculator
{
    public static bool IsALeapYear(int year)
    {
        return year % 400 == 0;
    }
}