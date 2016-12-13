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


        public static int UgeNr(int uge)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            // DateTime date1 = new DateTime();
            //DateTime date1 = DateTime.Parse($"2017-01-02");
            DateTime date1 = DateTime.Parse($"{DateTime.Now.AddDays(uge)}".Trim());
            //date1 = DateTime.Now.AddDays(28);
            Debug.Assert(dfi != null, "dfi != null");
            Calendar cal = dfi.Calendar;
            dfi.FirstDayOfWeek= DayOfWeek.Monday;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
            
            
            //return int.Parse($"{cal}");
        }

        public static int GetDenneUge()
        {
            return UgeNr(-7);
        }

        public static int GetNextUge()
        {
            return UgeNr(0);
        }

        public static int GetLastUge()
        {
            return UgeNr(-14);
        }

    }
}