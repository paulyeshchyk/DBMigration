using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;
namespace DBMigration.Contexts
{
  public class AppDbContext : DbContext
  {
    public DbSet<RefEmployee> Employees { get; set; }
    public DbSet<RefCustomer> Customer { get; set; }
    public DbSet<RefContractor> Contractor { get; set; }
    public DbSet<DocCustomerContract> CustomerContract { get; set; }
    public DbSet<DocEmployeeContract> EmployeeContract { get; set; }
    public DbSet<DocEmployeeContractAddendum> EmployeeContractAddendum { get; set; }
    public DbSet<DocCustomerContractInvoce> CustomerContractInvoces { get; set; }
    public AppDbContext()
    {
      //Database.EnsureCreated();
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
