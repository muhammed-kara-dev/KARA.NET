namespace KARA.NET;
public static class DateTimeUtils
{
    public static bool CompareDateAndHours(DateTime dt1, DateTime dt2)
    {
        return dt1.Year == dt2.Year && dt1.Month == dt2.Month && dt1.Day == dt2.Day && dt1.Hour == dt2.Hour;
    }

    public static DateTime GetFirstDayOfWeek()
    {
        return DateTimeUtils.GetFirstDayOfWeek(DateTime.Now.Date);
    }

    public static DateTime GetFirstDayOfWeek(this DateTime dateTime)
    {
        var dayOfWeekDE = dateTime.GetFirstDayOfWeekDE();
        return DateTimeUtils.ToDateTime(dateTime, dayOfWeekDE);
    }

    public static DayOfWeekDE GetFirstDayOfWeekDE()
    {
        return DateTimeUtils.GetFirstDayOfWeekDE(DateTime.Now.Date);
    }

    public static DayOfWeekDE GetFirstDayOfWeekDE(this DateTime dateTime)
    {
        switch (dateTime.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return DayOfWeekDE.Monday;
            case DayOfWeek.Tuesday:
                return DayOfWeekDE.Tuesday;
            case DayOfWeek.Wednesday:
                return DayOfWeekDE.Wednesday;
            case DayOfWeek.Thursday:
                return DayOfWeekDE.Thursday;
            case DayOfWeek.Friday:
                return DayOfWeekDE.Friday;
            case DayOfWeek.Saturday:
                return DayOfWeekDE.Saturday;
            case DayOfWeek.Sunday:
                return DayOfWeekDE.Sunday;
            default:
                throw new Exception("date of week not found");
        }
    }

    public static DateTime GetLastDayOfWeekDE(this DateTime dateTime, DayOfWeekDE dayOfWeek)
    {
        var dayOfWeekCurrent = DateTimeUtils.GetFirstDayOfWeekDE(dateTime);

        switch (dayOfWeekCurrent)
        {
            case var x when dayOfWeek < x:
                return dateTime.Date.AddDays(dayOfWeek - x);
            case var x when x == dayOfWeek:
                return dateTime.Date;
            case var x when x < dayOfWeek:
                return dateTime.Date.AddDays(dayOfWeek - x - 7);
            default:
                throw new Exception("date of week not found");
        }
    }

    public static DateTime ToDateTime(DateTime dateTime, DayOfWeekDE dayOfWeek)
    {
        return dateTime.AddDays(-(int)dayOfWeek);
    }

    public static string ToShortDE(this DayOfWeekDE dayOfWeek)
    {
        switch (dayOfWeek)
        {
            case DayOfWeekDE.Monday:
                return "MO";
            case DayOfWeekDE.Tuesday:
                return "DI";
            case DayOfWeekDE.Wednesday:
                return "MI";
            case DayOfWeekDE.Thursday:
                return "DO";
            case DayOfWeekDE.Friday:
                return "FR";
            case DayOfWeekDE.Saturday:
                return "SA";
            case DayOfWeekDE.Sunday:
                return "SO";
            default:
                throw new Exception("date of week not found");
        }
    }

    public static DateTime Clamp(this DateTime dateTime, DateTime min, DateTime max)
    {
        var ticks = dateTime.Ticks;
        var ticksMin = min.Ticks;
        var ticksMax = max.Ticks;
        ticks = MathUtils.Clamp(ticks, ticksMin, ticksMax);
        return new DateTime(ticks);
    }
}