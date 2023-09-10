using System;
using DBMigration.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DBMigration
{
  public class DBMigrationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
  {
    public ApplicationDbContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
      optionsBuilder.UseSqlServer("TrustServerCertificate=True;Data Source=localhost;Initial Catalog=ankara1;User ID=ankaraUser;Password=user123!");

      return new ApplicationDbContext(optionsBuilder.Options);
    }
  }
}

