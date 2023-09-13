using ConsoleTables;
using DBMigration.Contexts;
using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBMigration.Business
{
  public static class EmployeeManager
  {

    public static RefEmployee AddEmployee(string? name, int? age)
    {
      using AppDbContext appDbContext = new();
      RefEmployee result = appDbContext.Employees.FindOrCreateEmployee(name, age);
      appDbContext.SaveChanges();
      return result;
    }

    public static void EditEmployee(int ident, Action<RefEmployee> action)
    {
      using AppDbContext appDbContext = new();
      appDbContext.Employees
        .Where(e => e.Id == ident)
        .ToList()
        .ForEach(action);
      appDbContext.SaveChanges();
    }

    public static void RemoveEmployee(int ident)
    {
      using AppDbContext appDbContext = new();
      appDbContext.Employees
        .Where(e => e.Id == ident)
        .ToList()
        .ForEach(e => { appDbContext.Remove(e); });
      appDbContext.SaveChanges();
    }

    public static RefEmployee NewEmployee(this DbSet<RefEmployee> dbSet, string? employeeName, int? age)
    {
      RefEmployee result = new() { Name = employeeName ?? string.Empty, Age = age };
      dbSet.Add(result);
      return result;
    }

    public static RefEmployee FindOrCreateEmployee(this DbSet<RefEmployee> dbSet, string? employeeName, int? age)
    {
      IQueryable<RefEmployee> set = dbSet.Where(u => u.Name.Equals(employeeName));
      if (set.Any()) { return set.First(); }

      return dbSet.NewEmployee(employeeName, age);
    }

    public static void DrawTable()
    {
      using AppDbContext appDbContext = new();
      ConsoleTable table = new("Id", "Name", "Age");
      var result = (from list
                   in appDbContext.Employees
                    select list).ToList();
      foreach (var employee in result)
      {
        table.AddRow(employee.Id, employee.Name, employee.Age);
      };
      table.Write(ConsoleTables.Format.Default);
    }

    public static void DrawList(this DbSet<RefEmployee> dbSet)
    {
      var users = dbSet.ToList();
      Console.WriteLine("Список объектов:");
      foreach (RefEmployee u in users)
      {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname ?? "unknown"}");
      }
    }
  }
}
