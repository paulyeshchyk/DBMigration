using DBMigration.Business;
using DBMigration.Navigator;
using DBMigration.Resources;
using System.Globalization;
using System;

public class Program
{
  private static readonly ITableDrawer TableDrawer = new TableDrawer();
  private static readonly INavigator Navigator = new ConsoleNavigator(TableDrawer);

  public static void Main(string[] args)
  {

    //ConsoleLocalization.SetLocalization("en-US");
    Navigator.SetNodes(NavigatorNodeItems.LevelRootNodes);
    Navigator.DrawMenuAndWait(strings.StringStand);
  }
 
}