using System;
namespace DBMigration.Entities
{
  public class Company
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Outsourcer? Outsourcer { get; set; }
    public Company()
    {
      Name = string.Empty;
    }
  }

}