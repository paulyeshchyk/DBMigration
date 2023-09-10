using System;
namespace DBMigration.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int? Age { get; set; }
    public List<Company> Companies { get; set; }

    public List<Outsourcer> employers { get; set; }

    public User()
    {
      Companies = new List<Company>();
      employers = new List<Outsourcer>();
    }
  }
}

