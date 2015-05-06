using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogConfectionery
{
    static class TimeSpanExtensions
    {
        public static string ToStringMounth(this TimeSpan TimeS)
        {
            string str = "";
            if (TimeS.TotalDays > 30)
            {
                str = (int)(TimeS.TotalDays / 30) + " мес.";

            }
            else if (TimeS.TotalHours > 72)
            {
                str = (int)(TimeS.TotalHours / 30) + " дн.";
            }
            else
            {
                str = TimeS.TotalHours + " час.";
            }
            return str;

        }

    }
}
