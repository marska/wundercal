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
      Console.WriteLine("CalendarService - calendar loading  ...");
      _calendar = iCalendar.LoadFromUri(uri )[0];
      Console.WriteLine("CalendarService - calendar loaded.");
    }

    public List<CalendarEvent> GetCalendarEvents(DateTime startDate)
    {
      var events = _calendar.Events.Where(item => item.Start.Date.Date == startDate.Date);
      
      var calendarEvents = events.Select(item => new CalendarEvent(item.Summary, DateUtil.GetSimpleDateTimeData(item.Start))).ToList();

      return calendarEvents;
    }
  }
}
