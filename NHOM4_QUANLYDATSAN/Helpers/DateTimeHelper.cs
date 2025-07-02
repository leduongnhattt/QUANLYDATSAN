using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHOM4_QUANLYDATSAN.Helpers
{
    public class DateTimeHelper
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
