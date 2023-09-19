using DBMigration.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBMigration.Tests
{
  [TestClass()]
  public class DBMigrationContextFactoryTests
  {
    [TestMethod()]
    public void CreateDbContextTest()
    {
      var factory = new DBMigrationContextFactory();
      using (var context = factory.CreateDbContext(Array.Empty<string>()))
      {
        var g = Guid.NewGuid();
        var employee = new RefEmployee() { Name = $"{g}" };
        context.Employees.Add(employee);
        context.SaveChanges();

        context.Employees.Remove(employee);
        context.SaveChanges();

        Assert.IsFalse(context.Employees.Any(e => e.Name.Equals(g.ToString())));
      }
    }
  }
}