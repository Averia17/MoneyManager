using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WPF.EventCalendar;

namespace MoneyManager.Main
{
   
    public class ScheduleCustomEvent : ICalendarEvent
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Label { get; set; }
        public string Color { get; set; }
    }
}
