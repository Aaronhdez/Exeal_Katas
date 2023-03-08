namespace LeapYear;

public class LeapYearCalculator
{
    public static bool IsALeapYear(int year)
    {
        return year % 400 == 0 ? true :
            year % 4 == 0 && year % 100 != 0;
    }
}