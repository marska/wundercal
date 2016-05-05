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

      var calendarEvents = occurrences
        .Select(o => new CalendarEvent(((IRecurringComponent)o.Source).Summary, o.Period.StartTime.UTC))
        .Where(ce => !string.IsNullOrEmpty(ce.Summary))
        .ToList();

      return calendarEvents;
    }
  }
}
