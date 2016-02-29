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
      _calendar = iCalendar.LoadFromUri(uri )[0];
    }

    public List<CalendarEvent> GetCalendarEvents(DateTime startDate)
    {
      Console.WriteLine("Geting calendar events ...");

      var events = _calendar.Events.Where(item => item.Start.Date.Date == startDate.Date);
      
      var calendarEvents = events.Select(item => new CalendarEvent(item.Summary, DateUtil.GetSimpleDateTimeData(item.Start))).ToList();

      return calendarEvents;
    }
  }
}
