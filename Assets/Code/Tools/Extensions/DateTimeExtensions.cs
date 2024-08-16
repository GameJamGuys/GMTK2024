using System;
using UnityEngine;

public static class DateTimeExtensions
{
    public static DateTime ToDateTime(this string dateString)
    {
        string[] formats = { "yyyy-MM-dd HH:mm:ss", "MM/dd/yyyy HH:mm:ss", "dd.MM.yyyy H:mm:ss", "dd.MM.yyyy HH:mm:ss" };

        if (DateTime.TryParseExact(dateString, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out var dateTime))
            return dateTime;

        throw new InvalidTimeZoneException(dateString);
    }
}