using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Faellesspisning
{
    class Dato
    {
        // Denne klasse bruges til at hente uge nummeret
        public static int UgeNr(int uge)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = DateTime.Parse($"{DateTime.Now.AddDays(uge)}".Trim());
            Debug.Assert(dfi != null, "dfi != null");
            Calendar cal = dfi.Calendar;
            dfi.FirstDayOfWeek= DayOfWeek.Monday;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }
        public static int GetDenneUge()
        {
            return UgeNr(-7);
        }
        public static int GetNæsteUge()
        {
            return UgeNr(0);
        }
    }
}