using System;
using Wundercal.Services;

namespace Wundercal
{
  internal class CalendarProcessor : ICalendarProcessor
  {
    private readonly ICalendarService _calendarService;

    private readonly IWunderlistService _wunderlistService;

    public CalendarProcessor(ICalendarService calendarService, IWunderlistService wunderlistService)
    {
      _calendarService = calendarService;
      _wunderlistService = wunderlistService;
    }

    public void Execute()
    {
      Console.WriteLine("Executing processor ...");

      var events = _calendarService.GetCalendarEvents(DateTime.Today.AddDays(1));
      
      if (events.Count > 0)
      {
        var listId = string.IsNullOrEmpty(Settings.WunderlistListName)
          ? _wunderlistService.GetListId("inbox")
          : _wunderlistService.GetListId(Settings.WunderlistListName);

        events.ForEach(@event =>
        {
          Console.WriteLine("Adding task: " + @event.Summary);

          var taskId = _wunderlistService.CreateTask(listId, "#cal " + @event.Summary, @event.StartDate);
          _wunderlistService.CreateReminder(taskId, @event.StartDate);
          
        });
      }
    }
  }
}
