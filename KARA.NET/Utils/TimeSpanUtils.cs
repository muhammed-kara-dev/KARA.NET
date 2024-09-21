using System;
using System.Collections.Generic;
using System.Linq;

namespace KARA.NET;
public static class TimeSpanUtils
{
    public static string Format(this TimeSpan param, bool includeDays = false, bool includeHours = true, bool includeMinutes = true, bool includeSeconds = true, bool includeMilliseconds = false)
    {
        var result = new List<string>();
        if (includeDays)
        {
            result.Add($"{param.Days:D1}");
        }
        if (includeHours)
        {
            result.Add($"{param.Hours:D2}");
        }
        if (includeMinutes)
        {
            result.Add($"{param.Minutes:D2}");
        }
        if (includeSeconds)
        {
            result.Add($"{param.Seconds:D2}");
        }
        if (includeMilliseconds)
        {
            result.Add($"{param.Milliseconds:D3}");
        }
        return result.Aggregate((x, y) => $"{x}:{y}");
    }

    public static string FormatDiff(this TimeSpan param)
    {
        var seconds = (int)param.TotalSeconds;
        var minutes = (int)param.TotalMinutes;
        var hours = (int)param.TotalHours;
        var days = (int)param.TotalDays;
        var months = (int)(param.TotalDays / 28);
        var years = (int)(param.TotalDays / 365);

        if (1 < years)
        {
            return $"{years:N0} years";
        }
        else if (1 == years)
        {
            return "1 year";
        }
        else if (1 < months)
        {
            return $"{months:N0} months";
        }
        else if (1 == months)
        {
            return "1 month";
        }
        else if (1 < days)
        {
            return $"{days:N0} days";
        }
        else if (1 == days)
        {
            return "1 day";
        }
        else if (1 < hours)
        {
            return $"{hours:N0} hours";
        }
        else if (1 == hours)
        {
            return "1 hour";
        }
        else if (1 < minutes)
        {
            return $"{minutes:N0} minutes";
        }
        else if (1 == minutes)
        {
            return "1 minute";
        }
        else if (1 < seconds)
        {
            return $"{seconds:N0} seconds";
        }
        else if (1 == seconds)
        {
            return "1 second";
        }
        else
        {
            return "now";
        }
    }
}