using System.Configuration;

namespace Wundercal
{
  public class Settings
  {
    public static string CalendarAddress => ConfigurationManager.AppSettings["CalendarAddress"];

    public static string WunderlistListName => ConfigurationManager.AppSettings["WunderlistListName"];

    public static string WunderlistAccessToken => ConfigurationManager.AppSettings["WunderlistAccessToken"];

    public static string WunderlistClientId => ConfigurationManager.AppSettings["WunderlistClientId"];
  }
}
