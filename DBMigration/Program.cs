using System.Linq;
using DBMigration.Contexts;
using DBMigration.Entities;

public class Program
{


  private static User FindOrCreateUserByName(string name, Microsoft.EntityFrameworkCore.DbSet<User> dbSet)
  {
    IQueryable<User> set = dbSet.Where(u => name.Equals(u.Name));
    if (set.Count() == 1)
    {
      return set.First();
    }
    Console.WriteLine($"Adding user by name: {name}");

    User result = new User { Name = name };
    dbSet.Add(result);
    return result;
  }

  private static Outsourcer FindOrCreateOutsourcerByName(string name, Microsoft.EntityFrameworkCore.DbSet<Outsourcer> dbSet)
  {
    IQueryable<Outsourcer> set = dbSet.Where(o => name.Equals(o.Name));
    if (set.Count() == 1)
    {
      return set.First();
    }

    Console.WriteLine($"Adding outsourcer by name: {name}");
    Outsourcer result = new Outsourcer { Name = name };
    dbSet.Add(result);
    return result;
  }

  private static Company FindOrCreateCompanyByName(string name, Microsoft.EntityFrameworkCore.DbSet<Company> dbSet)
  {
    IQueryable<Company> set = dbSet.Where(c => name.Equals(c.Name));
    if (set.Count() == 1)
    {
      return set.First();
    }

    Console.WriteLine($"Adding company by name: {name}");
    Company result = new Company { Name = name };
    dbSet.Add(result);
    return result;
  }

  private static void InitData()
  {
    using (ApplicationDbContext db = new ApplicationDbContext())
    {

      User user1 = FindOrCreateUserByName("Tom21", db.Users);
      User user2 = FindOrCreateUserByName("Alice1", db.Users);

      Outsourcer outsourcer = FindOrCreateOutsourcerByName("Outsourcer1", db.Outsourcers);
      //user1.employers.Add(outsourcer);
      //user2.employers.Add(outsourcer);
      //outsourcer.employees.Add(user1);
      //outsourcer.employees.Add(user2);

      Company company1 = FindOrCreateCompanyByName("Company1", db.Companies);
      company1.Outsourcer = outsourcer;

      Company company2 = FindOrCreateCompanyByName("Company2", db.Companies);
      company2.Outsourcer = outsourcer;

      user1.Companies?.Add(company1);
      user2.Companies?.Add(company2);

      db.SaveChanges();

      //db.Entry(outsourcer).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
      //Outsourcer objectToRemove = db.Outsourcers.Where(o => o.Id == outsourcer.Id).First();
      //db.Outsourcers.Remove(objectToRemove);
      //db.SaveChanges();



      Console.WriteLine("Объекты успешно сохранены");

      // получаем объекты из бд и выводим на консоль
      var users = db.Users.ToList();
      Console.WriteLine("Список объектов:");
      foreach (User u in users)
      {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname ?? "unknown"}");
      }
    }
    Console.Read();
  }

  public static void Main(string[] args)
  {
    InitData();

    using (ApplicationDbContext db = new ApplicationDbContext())
    {



      //IEnumerable<Company> companies = db.Companies.Where(
      //  c => c.Name.Contains("Company1")
      //  );

      //var q =
      //    db.Outsourcers.Join(db.Users,
      //    user => user,
      //    outs => outs.Companies,
      //    (p1, p2) => new { A = p1.Name }
      //    );

      //var query =
      //  from Outsourcer in db.Outsourcers
      //  join User in db.Users on companies equals User.Companies
      //  select new
      //  {
      //    A = User.Name,
      //    O = Outsourcer.Name
      //  };
      //foreach (var s in query)
      //{
      //  Console.WriteLine($"{s.A}");
      //}
    }
  }
}