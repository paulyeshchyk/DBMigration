﻿using DBMigration.Resources;
using System.Globalization;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace DBMigration.Business
{
  public static class NavigatorNodeActionsContractor
  {
    public static void Level1ContractorsListBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine(strings.TitleContractors);

      ContractorManager.DrawTable();
      navigator.WaitForAnykeyPress();
    }

    public static void Level1ContractListBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine(strings.TitleContracts);

      ContractManager.DrawTable();
      navigator.WaitForAnykeyPress();
    }
  }

  public static class NavigatorNodeTranslationsContext
  {
    public static void LevelGotoTranslationsDefaultBlock(DBMigration.Navigator.INavigator navigator)
    {
      ConsoleLocalization.SetLocalization("en-en");
    }
    public static void LevelGotoTranslationsRuRuBlock(DBMigration.Navigator.INavigator navigator)
    {
      ConsoleLocalization.SetLocalization("ru-RU");
    }
  }

  public static class NavigatorNodeActionsContext
  {
    public static void Level0GotoContextBlock(DBMigration.Navigator.INavigator navigator)
    {
      navigator.SetNodes(NavigatorNodeItems.LevelContextNodes);
    }

    public static void LevelContextWipeDataBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine(strings.TitleWipeData);

      ContextManager.WipeData();
      navigator.WaitForAnykeyPress();
    }

    public static void LevelContextAddDataBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine(strings.TitleInitData);

      ContextManager.PrepareData();
      navigator.WaitForAnykeyPress();
    }
  }

  public static class NavigatorNodeActionsEmployee
  {
    public static void Level1EmployeeBlock(DBMigration.Navigator.INavigator navigator)
    {
      navigator.SetNodes(NavigatorNodeItems.LevelEmployeeNodes);
    }

    public static void Level1EmployeeListBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine(strings.TitleEmployees);

      EmployeeManager.DrawTable();
      navigator.WaitForAnykeyPress();
    }

    public static void Level1EmployeeAddBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("New Employee");

      Console.Write("Имя: ");
      var employeeName = Console.ReadLine();
      if (string.IsNullOrEmpty(employeeName))
      {
        Console.WriteLine("Неправильное значение имени");
        navigator.WaitForAnykeyPress();
        return;
      }

      Console.Write("Возраст: ");
      var employeeAge = Console.ReadLine();
      if (!int.TryParse(employeeAge, out int age))
      {
        Console.WriteLine("Неправильное значение возраста");
        navigator.WaitForAnykeyPress();
        return;
      }

      EmployeeManager.AddEmployee(employeeName, age);
      navigator.WaitForAnykeyPress();
    }

    public static void Level1EmployeeEditBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Employees");

      Console.Write("Идентификатор: ");
      var employeeid = Console.ReadLine();

      if (!int.TryParse(employeeid, out int id))
      {
        Console.WriteLine("Неправильный идентификатор");
        navigator.WaitForAnykeyPress();
        return;
      }

      Console.Write("Имя: ");
      var employeeName = Console.ReadLine();
      if (string.IsNullOrEmpty(employeeName))
      {
        Console.WriteLine("Неправильное значение имени");
        navigator.WaitForAnykeyPress();
        return;
      }

      Console.Write("Возраст: ");
      var employeeAge = Console.ReadLine();
      if (!int.TryParse(employeeAge, out int age))
      {
        Console.WriteLine("Неправильное значение возраста");
        navigator.WaitForAnykeyPress();
        return;
      }

      EmployeeManager.EditEmployee(id, e => { e.Name = employeeName; e.Age = age; });

      //
      navigator.WaitForAnykeyPress();
    }

    public static void Level1EmployeeDeleteBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine("Удаление элемента Employees");

      Console.Write("Идентификатор: ");
      var employeeid = Console.ReadLine();

      if (!int.TryParse(employeeid, out int ident))
      {
        Console.WriteLine("Неправильное значение возраста");
        navigator.WaitForAnykeyPress();
        return;
      }

      EmployeeManager.RemoveEmployee(ident);
      //
      navigator.WaitForAnykeyPress();
    }
  }

  public static class NavigatorNodeActionsCustomer
  {
    public static void Level1CustomerListBlock(DBMigration.Navigator.INavigator navigator)
    {
      Console.Clear();
      Console.WriteLine(strings.TitleCustomers);

      CustomerManager.DrawTable();
      navigator.WaitForAnykeyPress();
    }
  }

  public static class NavigatorNodeActionsRefs
  {
    public static void Level0GotoReferencesBlock(DBMigration.Navigator.INavigator navigator)
    {
      navigator.SetNodes(NavigatorNodeItems.LevelRefsNodes);
    }
  }

  public static class NavigatorNodeActionsDocs
  {
    public static void Level0GotoDocBlock(DBMigration.Navigator.INavigator navigator)
    {
      navigator.SetNodes(NavigatorNodeItems.Level2DocsNodes);
    }
  }

  public static class NavigatorNodeActions
  {
    public static void Level0ExitBlock(DBMigration.Navigator.INavigator navigator)
    {
      Environment.Exit(0);
    }

    public static void Level0TranslationsBlock(DBMigration.Navigator.INavigator navigator)
    {
      navigator.SetNodes(NavigatorNodeItems.LevelTranslationNodes);
    }

    public static void Level1LevelUpBlock(DBMigration.Navigator.INavigator navigator)
    {
      navigator.SetNodes(NavigatorNodeItems.LevelRootNodes);
    }
  }
}