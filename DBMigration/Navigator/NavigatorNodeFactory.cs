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

    private static void Level1EmployeeBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(LevelEmployeeNodes);
    }

    private static void Level1EmployeeListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Employees");

      EmployeeManager.DrawList();
      navigator.AnyKeyBlock();
    }

    private static void Level1EmployeeAddBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Employees");

      //
      navigator.AnyKeyBlock();
    }
    private static void Level1EmployeeEditBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Employees");

      //
      navigator.AnyKeyBlock();
    }
    private static void Level1EmployeeDeleteBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Employees");

      //
      navigator.AnyKeyBlock();
    }

    private static void Level0ExitBlock(RootNavigator navigator)
    {
      Environment.Exit(0);
    }
    private static void Level0GotoReferencesBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(LevelRefsNodes);
    }

    private static void Level0GotoDocBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(Level2DocsNodes);
    }
    private static void Level1LevelUpBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(LevelRootNodes);
    }

    public static List<NavigatorNode> LevelRootNodes = new()
    {
      new NavigatorNode("Exit", Level0ExitBlock),
      new NavigatorNode("Подготовить контекст", Level0ContextPreareBlock),
      new NavigatorNode("Справочники", Level0GotoReferencesBlock),
      new NavigatorNode("Документы", Level0GotoDocBlock)
    };

    private static readonly List<NavigatorNode> LevelRefsNodes = new()
    {
      new NavigatorNode("Exit", Level1LevelUpBlock),
      new NavigatorNode("Работники", Level1EmployeeBlock),
      new NavigatorNode("Подрядчики",Level1ContractorsListBlock),
      new NavigatorNode("Заказчики", Level1CustomerListBlock)
    };

    private static readonly List<NavigatorNode> LevelEmployeeNodes = new()
    {
      new NavigatorNode("Exit", Level1LevelUpBlock),
      new NavigatorNode("Список", Level1EmployeeListBlock),
      new NavigatorNode("Добавить",Level1EmployeeAddBlock),
      new NavigatorNode("Изменить",Level1EmployeeEditBlock),
      new NavigatorNode("Удалить", Level1EmployeeDeleteBlock)
    };


    private static readonly List<NavigatorNode> Level2DocsNodes = new()
    {
      new NavigatorNode("Exit", Level1LevelUpBlock),
      new NavigatorNode("Контракты", Level1ContractListBlock)
    };
  }
}
