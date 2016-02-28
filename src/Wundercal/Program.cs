using System;
using Wundercal.Services;

namespace Wundercal
{
  class Program
  {
    static void Main()
    {
      try
      {
        var calendarService = new CalendarService(new Uri(Settings.CalendarAddress));

        var wunderlistService = new WunderlistService(Settings.WunderlistAccessToken, Settings.WunderlistClientId);

        var processor = new CalendarProcessor(calendarService, wunderlistService);
        processor.Execute();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
      }
    }
  }
}
