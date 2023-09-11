using System;
namespace DBMigration.Entities
{
  public class User
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int? Age { get; set; }
    public List<Contract>? contracts { get; set; }

    public User()
    {
    }
  }
}

