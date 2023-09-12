using ConsoleTables;
using DBMigration.Contexts;
using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class EmployeeManager
  {
    public static DocEmployeeContractAddendum FindOrCreateValidAddendum(this DbSet<DocEmployeeContractAddendum> dbSet, DocEmployeeContract contract)
    {
      IQueryable<DocEmployeeContractAddendum> set = dbSet.Where(a => a.IsValid == true && a.Contract == contract);
      if (set.Count() != 0)
      {
        Console.WriteLine($"Found employee valid addendum");
        return set.First();
      }

      var result = new DocEmployeeContractAddendum
      {
        Contract = contract
      };
      contract.AddendumList.Add(result);
      dbSet.Add(result);
      return result;
    }
    public static DocEmployeeContract FindOrCreateEmployeeContract(this DbSet<DocEmployeeContract> dbSet, RefEmployee employee, RefContractor contractor)
    {
      IQueryable<DocEmployeeContract> set = dbSet.Where(c => c.Employee == employee & c.Contractor == contractor);
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found employee contract by name: {employee.Name}");
        return set.First();
      }

      Console.WriteLine($"Adding contract for: {employee.Name}");
      var result = new DocEmployeeContract
      {
        Employee = employee,
        Contractor = contractor
      };
      dbSet.Add(result);
      return result;
    }
    public static RefEmployee FindOrCreateEmployee(this DbSet<RefEmployee> dbSet, string employeeName)
    {
      IQueryable<RefEmployee> set = dbSet.Where(u => employeeName.Equals(u.Name));
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found user by name: {employeeName}");
        return set.First();
      }
      Console.WriteLine($"Adding user by name: {employeeName}");

      var result = new RefEmployee { Name = employeeName };
      dbSet.Add(result);
      return result;
    }

    public static void DrawList()
    {
      using AppDbContext appDbContext = new();
      var table = new ConsoleTable("Id","Name", "Age");
      var result = (from list
                   in appDbContext.Employees
                    select list).ToList();
      foreach (var employee in result)
      {
        table.AddRow(employee.Id, employee.Name, employee.Age);
      };
      table.Write(ConsoleTables.Format.Default);
    }
  }
}
