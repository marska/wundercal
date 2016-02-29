using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Wundercal
{
  public class Settings
  {
    public static List<string> CalendarsAddresses =>
        ConfigurationManager.AppSettings["CalendarsAddresses"]
        .Split(new string[] {";", "; ", " ;", " ; " },StringSplitOptions.RemoveEmptyEntries).ToList();

    public static string WunderlistListName => ConfigurationManager.AppSettings["WunderlistListName"];

    public static string WunderlistAccessToken => ConfigurationManager.AppSettings["WunderlistAccessToken"];

    public static string WunderlistClientId => ConfigurationManager.AppSettings["WunderlistClientId"];
  }
}
