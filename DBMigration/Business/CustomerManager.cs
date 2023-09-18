using DBMigration.Contexts;
using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class CustomerManager
  {
    public static void DrawTable()
    {
      using AppDbContext appDbContext = new();
      var result = (from list in appDbContext.Customer select list).ToList();
      result.DrawConsoleTable();
    }

    public static RefCustomer FindOrCreateCustomer(this DbSet<RefCustomer> dbSet, string customerName)
    {
      IQueryable<RefCustomer> set = dbSet.Where(c => customerName.Equals(c.Name));
      if (set.Any())
      {
        Console.WriteLine($"Found company by name: {customerName}");
        return set.First();
      }

      Console.WriteLine($"Adding company by name: {customerName}");
      var result = new RefCustomer { Name = customerName };
      dbSet.Add(result);
      return result;
    }
  }
}