using System;
using System.Collections.Generic;
using System.Linq;
using DDay.iCal;
using Wundercal.Services.Dto;

namespace Wundercal.Services
{
  internal class CalendarService : ICalendarService
  {
    private readonly IICalendar _calendar;

    internal CalendarService(Uri uri)
    {
      Console.WriteLine("Loading  calendar ...");
      _calendar = iCalendar.LoadFromUri(uri)[0];
    }

    public List<CalendarEvent> GetCalendarEvents(DateTime date)
    {
      Console.WriteLine("Geting calendar events ...");

      var occurrences = _calendar.GetOccurrences(new iCalDateTime(date));

      var calendarEvents = occurrences.Select(o => o.Source)
        .OfType<IRecurringComponent>()
        .Select(rc => new CalendarEvent(rc.Summary, DateUtil.GetSimpleDateTimeData(rc.Start)))
        .ToList();

      return calendarEvents;
    }
  }
}
