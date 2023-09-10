using System;
namespace DBMigration.Entities
{
  public class Outsourcer
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<User> employees { get; set; }

    public Outsourcer()
    {
      employees = new List<User>();
    }
  }
}

