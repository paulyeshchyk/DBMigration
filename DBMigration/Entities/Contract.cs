using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMigration.Entities
{
  public class Contract
  {
    public int Id { get; set; }
    public Outsourcer? Outsourcer { get; set; }
    public Company? Company { get; set; }
    public List<User> Users { get; set; }

    public Contract()
    {
      Users = new List<User>();
    }
  }
}
