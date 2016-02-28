using System;
using System.Collections.Generic;
using Wundercal.Services.Dto;

namespace Wundercal.Services
{
  internal interface ICalendarService
  {
    List<CalendarEvent> GetCalendarEvents(DateTime date);
  }
}