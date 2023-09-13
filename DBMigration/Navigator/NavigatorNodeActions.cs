using DBMigration.Business;

namespace DBMigration.Navigator
{
  public static class NavigatorNodeActionsContractor
  {
    public static void Level1ContractorsListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Contractors");

      ContractorManager.DrawList();
      navigator.AnyKeyBlock();
    }
    public static void Level1ContractListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Contracts");

      ContractManager.DrawList();
      navigator.AnyKeyBlock();
    }
  }

  public static class NavigatorNodeActionsContext
  {
    public static void Level0GotoContextBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(NavigatorNodeItems.LevelContextNodes);
    }
    public static void LevelContextWipeDataBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Wipe data");

      ContextManager.WipeData();
      navigator.AnyKeyBlock();
    }
    public static void LevelContextAddDataBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Init data");

      ContextManager.PrepareData();
      navigator.AnyKeyBlock();
    }
  }
  public static class NavigatorNodeActionsEmployee
  {
    public static void Level1EmployeeBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(NavigatorNodeItems.LevelEmployeeNodes);
    }
    public static void Level1EmployeeListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Employees");

      EmployeeManager.DrawList();
      navigator.AnyKeyBlock();
    }
    public static void Level1EmployeeAddBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("New Employee");

      Console.Write("Имя: ");
      var employeeName = Console.ReadLine();
      if (String.IsNullOrEmpty(employeeName))
      {
        Console.WriteLine("Неправильное значение имени");
        navigator.AnyKeyBlock();
        return;
      }

      Console.Write("Возраст: ");
      var employeeAge = Console.ReadLine();
      if (!int.TryParse(employeeAge, out int age))
      {
        Console.WriteLine("Неправильное значение возраста");
        navigator.AnyKeyBlock();
        return;
      }

      EmployeeManager.AddEmployee(employeeName, age);
      navigator.AnyKeyBlock();
    }
    public static void Level1EmployeeEditBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Employees");

      Console.Write("Идентификатор: ");
      var employeeid = Console.ReadLine();

      if (!int.TryParse(employeeid, out int id))
      {
        Console.WriteLine("Неправильный идентификатор");
        navigator.AnyKeyBlock();
        return;
      }

      Console.Write("Имя: ");
      var employeeName = Console.ReadLine();
      if (String.IsNullOrEmpty(employeeName))
      {
        Console.WriteLine("Неправильное значение имени");
        navigator.AnyKeyBlock();
        return;
      }

      Console.Write("Возраст: ");
      var employeeAge = Console.ReadLine();
      if (!int.TryParse(employeeAge, out int age))
      {
        Console.WriteLine("Неправильное значение возраста");
        navigator.AnyKeyBlock();
        return;
      }

      EmployeeManager.EditEmployee(id, employeeName, age);

      //
      navigator.AnyKeyBlock();
    }
    public static void Level1EmployeeDeleteBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Удаление элемента Employees");

      Console.Write("Идентификатор: ");
      var employeeid = Console.ReadLine();

      if (!int.TryParse(employeeid, out int ident))
      {
        Console.WriteLine("Неправильное значение возраста");
        navigator.AnyKeyBlock();
        return;
      }

      EmployeeManager.RemoveEmployee(ident);
      //
      navigator.AnyKeyBlock();
    }
  }
  public static class NavigatorNodeActionsCustomer
  {
    public static void Level1CustomerListBlock(RootNavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Customers");

      CustomerManager.DrawList();
      navigator.AnyKeyBlock();
    }
  }
  public static class NavigatorNodeActionsRefs
  {
    public static void Level0GotoReferencesBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(NavigatorNodeItems.LevelRefsNodes);
    }
  }
  public static class NavigatorNodeActionsDocs
  {
    public static void Level0GotoDocBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(NavigatorNodeItems.Level2DocsNodes);
    }
  }
  public static class NavigatorNodeActions
  {
    public static void Level0ExitBlock(RootNavigator navigator)
    {
      Environment.Exit(0);
    }
    public static void Level1LevelUpBlock(RootNavigator navigator)
    {
      navigator.DrawNodes(NavigatorNodeItems.LevelRootNodes);
    }
  }

  public static class NavigatorNodeItems
  {
    public static List<NavigatorNode> LevelRootNodes = new()
    {
      new NavigatorNode("Стэнд", "Exit", NavigatorNodeActions.Level0ExitBlock),
      new NavigatorNode("Стэнд","Подготовить контекст", NavigatorNodeActionsContext.Level0GotoContextBlock),
      new NavigatorNode("Стэнд","Справочники", NavigatorNodeActionsRefs.Level0GotoReferencesBlock),
      new NavigatorNode("Стэнд","Документы", NavigatorNodeActionsDocs.Level0GotoDocBlock)
    };
    public static List<NavigatorNode> LevelContextNodes = new()
    {
      new NavigatorNode("Контекст", "Exit", NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode("Контекст","Заполнить таблицы тестовыми данными", NavigatorNodeActionsContext.LevelContextAddDataBlock),
      new NavigatorNode("Контекст","Очистить таблицы", NavigatorNodeActionsContext.LevelContextWipeDataBlock),
    };
    public static readonly List<NavigatorNode> LevelRefsNodes = new()
    {
      new NavigatorNode("Справочники", "Exit", NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode("Справочники","Работники", NavigatorNodeActionsEmployee.Level1EmployeeBlock),
      new NavigatorNode("Справочники","Подрядчики",NavigatorNodeActionsContractor.Level1ContractorsListBlock),
      new NavigatorNode("Справочники","Заказчики", NavigatorNodeActionsCustomer.Level1CustomerListBlock)
    };
    public static readonly List<NavigatorNode> LevelEmployeeNodes = new()
    {
      new NavigatorNode("Работники", "Exit", NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode("Работники","Список", NavigatorNodeActionsEmployee.Level1EmployeeListBlock),
      new NavigatorNode("Работники","Добавить",NavigatorNodeActionsEmployee.Level1EmployeeAddBlock),
      new NavigatorNode("Работники","Изменить",NavigatorNodeActionsEmployee.Level1EmployeeEditBlock),
      new NavigatorNode("Работники","Удалить", NavigatorNodeActionsEmployee.Level1EmployeeDeleteBlock)
    };
    public static readonly List<NavigatorNode> Level2DocsNodes = new()
    {
      new NavigatorNode("Документы", "Exit", NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode("Документы", "Контракты", NavigatorNodeActionsContractor.Level1ContractListBlock)
    };
  }
}


