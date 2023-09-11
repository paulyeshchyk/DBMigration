using System;
using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DBMigration.Contexts
{
  public class ApplicationDbContext : DbContext
  {

    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Outsourcer> Outsourcers { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    public ApplicationDbContext()
    {
      //Database.EnsureCreated();
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //  //base.OnModelCreating(modelBuilder);
      //modelBuilder
      //  .Entity<Outsourcer>
      //  Has
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

      string connectionString = "TrustServerCertificate=True;Data Source=localhost;Initial Catalog=ankara;User ID=ankaraUser;Password=user123!";
      if (!optionsBuilder.IsConfigured)
      {

        if (null != connectionString)
        {
          optionsBuilder
            //.UseLoggerFactory(loggerFactory)
            .EnableSensitiveDataLogging()
            .UseSqlServer(connectionString)
            .LogTo(Console.WriteLine);
        }
      }

    }


  }
}

