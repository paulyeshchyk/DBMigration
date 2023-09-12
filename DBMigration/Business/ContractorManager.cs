using ConsoleTables;
using DBMigration.Contexts;
using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class ContractorManager
  {
    public static RefContractor FindOrCreateContractor(this DbSet<RefContractor> dbSet, string name)
    {
      IQueryable<RefContractor> set = dbSet.Where(o => name.Equals(o.Name));
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found outsourcer by name: {name}");
        return set.First();
      }

      Console.WriteLine($"Adding outsourcer by name: {name}");
      var result = new RefContractor { Name = name };
      dbSet.Add(result);
      return result;
    }
    public static void DrawList()
    {
      using AppDbContext appDbContext = new();
      var table = new ConsoleTable("Name", "Address");
      var result = (from list
                   in appDbContext.Contractor
                    select list).ToList();
      foreach (var contractor in result)
      {
        table.AddRow(contractor.Name, contractor.Address);
      };
      table.Write(ConsoleTables.Format.Default);
    }
  }
}
