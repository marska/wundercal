using System;

namespace Wundercal.Services.Dto
{
  internal class CalendarEvent
  {
    public string Summary { get; set; }

    public DateTime StartDate { get; set; }

    public CalendarEvent(string summary, DateTime startDate)
    {
      Summary = summary;
      StartDate = startDate;
    }
  }
}