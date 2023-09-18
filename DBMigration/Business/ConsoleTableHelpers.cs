using ConsoleTables;
using DBMigration.Entities;

using DBMigration.Resources;
namespace DBMigration.Business
{
  public static class ConsoleTableHelpers
  {
    public static void DrawConsoleTable(this List<RefContractor> list)
    {
      var table = new ConsoleTable(LocalizedStrings.TableColumnContractorName, LocalizedStrings.TableColumnAddress);
      foreach (var paramValues in list.Select(contractor => new object[] { contractor.Name, contractor.Address }))
      {
        table.AddRow(paramValues);
      }

      table.Write(ConsoleTables.Format.Default);
    }

    public static void DrawConsoleTable(this List<DocCustomerContract> list)
    {
      var table = new ConsoleTable(LocalizedStrings.TableColumnContractName, LocalizedStrings.TableColumnInvoicesCount);
      foreach (var paramValues in list.Select(contract => new object[] { contract.Subject, contract.Invoces.Count }))
      {
        table.AddRow(paramValues);
      };
      table.Write(ConsoleTables.Format.Default);
    }

    public static void DrawConsoleTable(this List<RefCustomer> list)
    {
      var table = new ConsoleTable(LocalizedStrings.TableColumnEmployeeName);
      foreach (var contract in list)
      {
        table.AddRow(contract.Name);
      };
      table.Write(ConsoleTables.Format.Default);
    }

    public static void DrawConsoleTable(this List<RefEmployee> list)
    {
      ConsoleTable table = new(LocalizedStrings.TableColumnEmployeeId, LocalizedStrings.TableColumnEmployeeName, LocalizedStrings.TableColumnEmployeeAge);
      foreach (var paramValues in list.Select(employee => new object[] { employee.Id, employee.Name, employee.Age?.ToString() ?? LocalizedStrings.ValueAgeIsNotDefined }))
      {
        table.AddRow(paramValues);
      };
      table.Write(ConsoleTables.Format.Default);
    }
  }
}