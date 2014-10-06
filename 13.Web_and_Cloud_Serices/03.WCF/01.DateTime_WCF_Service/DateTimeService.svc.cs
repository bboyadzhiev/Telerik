using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _01.DateTime_WCF_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DateTimeService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DateTimeService.svc or DateTimeService.svc.cs at the Solution Explorer and start debugging.
    public class DateTimeService : IDateTimeService
    {

        public string GetDayOfWeek(DateTime dateTime)
        {
            var bulgaian = new CultureInfo("BG-bg");
            var info = bulgaian.DateTimeFormat;
            var day = dateTime.DayOfWeek;
            var result = info.GetDayName(day);
            return result;
        }
    }
}
