using DBMigration.Business;
using DBMigration.Navigator;

public class Program
{
  private static readonly ITableDrawer tableDrawer = new TableDrawer();
  private static readonly INavigator navigator = new ConsoleNavigator(tableDrawer);

  public static void Main(string[] args)
  {

    navigator.SetNodes(NavigatorNodeItems.LevelRootNodes);
    navigator.DrawMenuAndWait("Стэнд");
  }
}