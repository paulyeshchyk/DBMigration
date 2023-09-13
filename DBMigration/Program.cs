using DBMigration.Navigator;

public class Program
{

  private static readonly ITableDrawer tableDrawer = new TableDrawer();
  private static readonly Navigator navigator = new(tableDrawer);

  public static void Main(string[] args)
  {
    navigator.SetNodes(NavigatorNodeItems.LevelRootNodes);
    navigator.DrawMenuAndWait("Стэнд");
  }
}