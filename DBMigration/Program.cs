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
      Console.WriteLine($"Found user by name: {name}");
      return set.First();
    }
    Console.WriteLine($"Adding user by name: {name}");

    User result = new User { Name = name };
    dbSet.Add(result);
    return result;
  }

  private static Contract FindOrCreateContract(Company company, Outsourcer outsorser, List<User> users, Microsoft.EntityFrameworkCore.DbSet<Contract> dbSet)
  {

    IQueryable<Contract> set = dbSet.Where(c => c.Outsourcer == outsorser && c.Company == company);
    if (set.Count() == 1)
    {
      Console.WriteLine($"Found contract for outsourcer: {outsorser.Name}");
      return set.First();
    }

    Contract contract = new Contract();
    contract.Company = company;
    contract.Outsourcer = outsorser;
    
    foreach (User user in users) {
      contract.Users.Add(user);
    }
    dbSet.Add(contract);
    
    return contract;
  }

  private static Outsourcer FindOrCreateOutsourcerByName(string name, Microsoft.EntityFrameworkCore.DbSet<Outsourcer> dbSet)
  {
    IQueryable<Outsourcer> set = dbSet.Where(o => name.Equals(o.Name));
    if (set.Count() == 1)
    {
      Console.WriteLine($"Found outsourcer by name: {name}");
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
      Console.WriteLine($"Found company by name: {name}");
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
      Company company1 = FindOrCreateCompanyByName("Company1", db.Companies);
      Company company2 = FindOrCreateCompanyByName("Company2", db.Companies);

      Contract contract = FindOrCreateContract(company1, outsourcer, new List<User> { user1 }, db.Contracts);

      Contract contract2 = FindOrCreateContract(company2, outsourcer, new List<User> { user1, user2 }, db.Contracts);


      //db.Entry(contract2).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;



      db.SaveChanges();


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