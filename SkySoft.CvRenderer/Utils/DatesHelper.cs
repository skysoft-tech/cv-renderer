using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.Utils
{
    internal static class DatesHelper
    {
        public const string YearDateFormat = "yyyy";
        public const string MonthDateFormat = "MM/yyyy";

        public static string ToYearString(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return "present";
            }

            return dateTime.Value.ToString(YearDateFormat);
        }

        public static string ToMonthString(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return "present";
            }

            return dateTime.Value.ToString(MonthDateFormat);
        }
    }
}
