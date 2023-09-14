using DBMigration.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBMigration
{
  public class DBMigrationContextFactory : IDesignTimeDbContextFactory<AppDbContext>
  {
    public AppDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
      optionsBuilder.UseSqlServer("TrustServerCertificate=True;Data Source=localhost;Initial Catalog=ankara;User ID=ankaraUser;Password=user123!");

      return new AppDbContext(optionsBuilder.Options);
    }
  }
}