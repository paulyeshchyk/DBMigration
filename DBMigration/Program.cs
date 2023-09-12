using DBMigration.Navigator;

public class Program
{

  private static readonly RootNavigator navigator = new();

  public static void Main(string[] args)
  {
    navigator.DrawNodes(NavigatorNodeFactory.Level0Nodes);
    navigator.Loop();
  }
}