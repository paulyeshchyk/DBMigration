using DBMigration.Contexts;
using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class ContractorManager
  {
    public static void DrawTable()
    {
      using AppDbContext appDbContext = new();
      var result = (from list in appDbContext.Contractor select list).ToList();
      ConsoleTableHelpers.DrawConsoleTable(result);
    }

    public static RefContractor FindOrCreateContractor(this DbSet<RefContractor> dbSet, string name)
    {
      IQueryable<RefContractor> set = dbSet.Where(o => name.Equals(o.Name));
      if (set.Any())
      {
        Console.WriteLine($"Found outsourcer by name: {name}");
        return set.First();
      }

      Console.WriteLine($"Adding outsourcer by name: {name}");
      var result = new RefContractor { Name = name };
      dbSet.Add(result);
      return result;
    }
  }
}