using DBMigration.Business;

namespace DBMigration.Navigator
{
  public static class NavigatorNodeFactory
  {
    private static void Level1ContractorsListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Contractors");

      ContractorManager.DrawList();
      navigator.AnyKeyBlock();
    }

    private static void Level1ContractListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Contracts");

      ContractManager.DrawList();
      navigator.AnyKeyBlock();
    }
    private static void Level1CustomerListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Customers");

      CustomerManager.DrawList();
      navigator.AnyKeyBlock();
    }


    private static void Level0ContextPreareBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Init data");

      ContextManager.PrepareData();
      navigator.AnyKeyBlock();
    }
    private static void Level1EmployeeListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Employees");

      EmployeeManager.DrawList();
      navigator.AnyKeyBlock();
    }


    private static void Level0ExitBlock(RootNavigator navigator)
    {
      Environment.Exit(0);
    }
    private static void Level0GotoReferencesBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(Level1Nodes);
    }
    private static void Level1LevelUpBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(Level0Nodes);
    }

    public static List<NavigatorNode> Level0Nodes = new()
    {
      new NavigatorNode("Exit", Level0ExitBlock),
      new NavigatorNode("Подготовить контекст", Level0ContextPreareBlock),
      new NavigatorNode("Справочники", Level0GotoReferencesBlock)
    };

    private static readonly List<NavigatorNode> Level1Nodes = new()
    {
      new NavigatorNode("Exit", Level1LevelUpBlock),
      new NavigatorNode("Работники", Level1EmployeeListBlock),
      new NavigatorNode("Контракты", Level1ContractListBlock),
      new NavigatorNode("Подрядчики",Level1ContractorsListBlock),
      new NavigatorNode("Заказчики", Level1CustomerListBlock)
    };
  }
}
