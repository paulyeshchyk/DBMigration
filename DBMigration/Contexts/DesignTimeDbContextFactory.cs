using DBMigration.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBMigration
{
  public class DBMigrationContextFactory : IDesignTimeDbContextFactory<ContractContext>
  {
    public ContractContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<ContractContext>();
      optionsBuilder.UseSqlServer("TrustServerCertificate=True;Data Source=localhost;Initial Catalog=ankara;User ID=ankaraUser;Password=user123!");

      return new ContractContext(optionsBuilder.Options);
    }
  }
}

