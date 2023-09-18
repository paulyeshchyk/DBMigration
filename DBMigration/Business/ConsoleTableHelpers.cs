using ConsoleTables;
using DBMigration.Entities;

namespace DBMigration.Business
{
  public static class ConsoleTableHelpers
  {
    public static void DrawConsoleTable(this List<RefContractor> list)
    {
      var table = new ConsoleTable("Name", "Address");
      foreach (var contractor in list)
      {
        table.AddRow(contractor.Name, contractor.Address);
      };
      table.Write(ConsoleTables.Format.Default);
    }

    public static void DrawConsoleTable(this List<DocCustomerContract> list)
    {
      var table = new ConsoleTable("Name", "К-во счетов");
      foreach (var contract in list)
      {
        table.AddRow(contract.Subject, contract.Invoces.Count);
      };
      table.Write(ConsoleTables.Format.Default);
    }

    public static void DrawConsoleTable(this List<RefCustomer> list)
    {
      var table = new ConsoleTable("Name");
      foreach (var contract in list)
      {
        table.AddRow(contract.Name);
      };
      table.Write(ConsoleTables.Format.Default);
    }

    public static void DrawConsoleTable(this List<RefEmployee> list)
    {
      ConsoleTable table = new("Id", "Name", "Age");
      foreach (var employee in list)
      {
        table.AddRow(employee.Id, employee.Name, employee.Age);
      };
      table.Write(ConsoleTables.Format.Default);
    }
  }
}