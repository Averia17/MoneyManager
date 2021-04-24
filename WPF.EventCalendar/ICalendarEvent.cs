using System;
using System.Windows.Media;

namespace WPF.EventCalendar
{
    public interface ICalendarEvent
    {
        DateTime? DateFrom { get; set; }
        DateTime? DateTo { get; set; }
        string Label { get; set; }
        string Color { get; set; }
        bool IsRepeat { get; set; }
    }
}
