using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMigration.Business
{
  public static class ConsoleLocalization
  {
    public static void SetLocalization(string localization)
    {
      var culture = new CultureInfo(localization);

      /*
      CultureInfo.CurrentCulture = culture;
      CultureInfo.DefaultThreadCurrentCulture = culture;
      CultureInfo.DefaultThreadCurrentUICulture = culture;
      */

      Thread.CurrentThread.CurrentUICulture = culture;
      Thread.CurrentThread.CurrentCulture = culture;

    }
  }
}
