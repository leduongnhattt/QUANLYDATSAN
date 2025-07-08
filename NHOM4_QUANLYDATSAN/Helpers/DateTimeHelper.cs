using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace NHOM4_QUANLYDATSAN.Helpers
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Converts a DateTime to a string in the format "dd/MM/yyyy HH:mm:ss".
        /// </summary>
        /// <param name="dateTime">The DateTime to convert.</param>
        /// <returns>A string representation of the DateTime.</returns>
        public static string ToFormattedString(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm:ss");
        }
        
        /// <summary>
        /// Lấy số tuần trong năm của một ngày
        /// </summary>
        public static int GetWeekOfYear(this DateTime date)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Calendar calendar = cultureInfo.Calendar;
            
            // CalendarWeekRule.FirstDay: Tuần đầu tiên của năm là tuần đầu tiên có ít nhất một ngày trong năm
            // DayOfWeek.Monday: Tuần bắt đầu từ thứ Hai
            return calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
        
        /// <summary>
        /// Lấy ngày đầu tiên của tuần (thứ Hai)
        /// </summary>
        public static DateTime GetFirstDayOfWeek(this DateTime date)
        {
            var culture = CultureInfo.CurrentCulture;
            var diff = date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            
            if (diff < 0)
                diff += 7;
                
            return date.AddDays(-diff).Date;
        }
        
        /// <summary>
        /// Lấy ngày cuối cùng của tuần (Chủ Nhật)
        /// </summary>
        public static DateTime GetLastDayOfWeek(this DateTime date)
        {
            return GetFirstDayOfWeek(date).AddDays(6);
        }
        
        /// <summary>
        /// Lấy ngày đầu tiên của tuần cho một tuần cụ thể trong năm
        /// </summary>
        public static DateTime GetFirstDayOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            
            DateTime firstMonday = jan1.AddDays(daysOffset);
            
            if (firstMonday.Year < year)
                firstMonday = firstMonday.AddDays(7);
                
            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                firstMonday, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                
            var result = firstMonday.AddDays(7 * (weekOfYear - firstWeek));
            return result;
        }

        /// <summary>
        /// Parses a string in the format "dd/MM/yyyy HH:mm:ss" to a DateTime.
        /// </summary>
        /// <param name="dateTimeString">The string to parse.</param>
        /// <returns>A DateTime object.</returns>
        public static DateTime ParseFromString(string dateTimeString)
        {
            return DateTime.ParseExact(dateTimeString, "dd/MM/yyyy HH:mm:ss", null);
        }
    }
}
