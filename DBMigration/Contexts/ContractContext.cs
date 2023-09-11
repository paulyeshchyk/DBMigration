using System;
using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace DBMigration.Contexts
{
  public class ContractContext : DbContext
  {
    public DbSet<RefEmployee> Employees { get; set; }
    public DbSet<RefCustomer> Customer { get; set; }
    public DbSet<RefContractor> Contractor { get; set; }
    public DbSet<DocCustomerContract> CustomerContract { get; set; }
    public DbSet<DocEmployeeContract> EmployeeContract { get; set; }
    public ContractContext()
    {
      //Database.EnsureCreated();
    }
    public ContractContext(DbContextOptions<ContractContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      string connectionString = "TrustServerCertificate=True;Data Source=localhost;Initial Catalog=ankara;User ID=ankaraUser;Password=user123!";
      if (!optionsBuilder.IsConfigured)
      {
        if (null != connectionString)
        {
          optionsBuilder
            .EnableSensitiveDataLogging()
            .UseSqlServer(connectionString);
            //.LogTo(Console.WriteLine);
        }
      }
    }
  }
}
