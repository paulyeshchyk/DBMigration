using ConsoleTables;
using DBMigration.Business;
using DBMigration.Contexts;
using DBMigration.Entities;
using DBMigration.Navigator;
using Microsoft.EntityFrameworkCore;

public class Program
{

  private static RootNavigator navigator = new RootNavigator();

  public delegate void TheBlock();


  private static Dictionary<string, TheBlock> dict = new Dictionary<string, TheBlock>();

  private static void Loop()
  {
    Agenda();
    Console.Write("Select command: ");
    var readKeyResult = Console.ReadLine();
    if (readKeyResult == null)
    {
      Loop();
      return;
    }

    TheBlock? block;
    dict.TryGetValue(readKeyResult, out block);
    if (block == null)
    {
      Loop();
      return;
    }
    block();
    //
    Loop();
  }

  private static void CallbackExit()
  {
    Environment.Exit(0);
  }

  private static void CallbackInitData()
  {
    Console.Clear();
    Console.WriteLine("Init data");
    using (AppDbContext appDbContext = new AppDbContext())
    {
      RefEmployee employee1 = appDbContext.Employees.FindOrCreateEmployee("Kuzma A");
      RefEmployee employee2 = appDbContext.Employees.FindOrCreateEmployee("Rybakov S");
      RefContractor contractor = appDbContext.Contractor.FindOrCreateContractor("Senla");

      DocEmployeeContract employeeContract1 = appDbContext.EmployeeContract.FindOrCreateEmployeeContract(employee1, contractor);
      employeeContract1.Subject = "Kuzma subj";

      var addendum1 = appDbContext.EmployeeContractAddendum.FindOrCreateValidAddendum(employeeContract1);
      addendum1.Addendum = "addendum1";

      DocEmployeeContract employeeContract2 = appDbContext.EmployeeContract.FindOrCreateEmployeeContract(employee2, contractor);
      employeeContract2.Subject = "Rubakov subj";

      RefCustomer customerThomson = appDbContext.Customer.FindOrCreateCustomer("Thomson Reuters");
      RefCustomer customerMTV = appDbContext.Customer.FindOrCreateCustomer("MTV Co");

      DocCustomerContract contract = appDbContext.CustomerContract.FindOrCreateCustomerContract(customerThomson, contractor, new List<RefEmployee> { employee1 });
      contract.Subject = "Eikon";

      DocCustomerContractInvoce invoce1 = appDbContext.CustomerContractInvoces.FindOrCreateCustomerContractInvoce(contract);
      invoce1.Price = 200;

      DocCustomerContract contract2 = appDbContext.CustomerContract.FindOrCreateCustomerContract(customerMTV, contractor, new List<RefEmployee> { employee1, employee2 });
      contract2.Subject = "Spunch Bob";

      DocCustomerContractInvoce invoce2 = appDbContext.CustomerContractInvoces.FindOrCreateCustomerContractInvoce(contract2);
      invoce2.Price = 100;

      appDbContext.SaveChanges();

      //contractContext.Employees.Remove(user1);
      //contractContext.SaveChanges();

      Console.WriteLine("Объекты успешно сохранены");

      var users = appDbContext.Employees.ToList();
      Console.WriteLine("Список объектов:");
      foreach (RefEmployee u in users)
      {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname ?? "unknown"}");

      }
    }
    AnyKeyBlock();
  }

  private static void CallbackContractorsList()
  {
    Console.Clear();
    Console.WriteLine("Contractors");

    using (AppDbContext appDbContext = new AppDbContext())
    {
      var table = new ConsoleTable("Name", "Address");
      var result = (from list
                   in appDbContext.Contractor
                    select list).ToList();
      foreach (var contractor in result)
      {
        table.AddRow(contractor.Name, contractor.Address);
      };
      table.Write(ConsoleTables.Format.Default);
    }
    AnyKeyBlock();
  }

  private static void CallbackContractsList()
  {
    Console.Clear();
    Console.WriteLine("Contracts");

    using (AppDbContext appDbContext = new AppDbContext())
    {
      var table = new ConsoleTable("Name", "К-во счетов");
      var set = appDbContext.CustomerContract
        .Include(x => x.Invoces);

      foreach (var contract in set.ToList())
      {
        table.AddRow(contract.Subject, contract.Invoces.Count);
      };
      table.Write(ConsoleTables.Format.Default);
    }
    AnyKeyBlock();
  }

  private static void CallbackCustomersList()
  {
    Console.Clear();
    Console.WriteLine("Customers");

    using (AppDbContext appDbContext = new AppDbContext())
    {
      var table = new ConsoleTable("Name");
      var result = (from list
                   in appDbContext.Customer
                    select list).ToList();
      foreach (var customer in result)
      {
        table.AddRow(customer.Name);
      };
      table.Write(ConsoleTables.Format.Default);
    }
    AnyKeyBlock();
  }
  private static void CallbackEmployeesList()
  {
    Console.Clear();
    Console.WriteLine("Employees");

    using (AppDbContext appDbContext = new AppDbContext())
    {
      var table = new ConsoleTable("Name", "Age");
      var result = (from list
                   in appDbContext.Employees
                    select list).ToList();
      foreach (var employee in result)
      {
        table.AddRow(employee.Name, employee.Age);
      };
      table.Write(ConsoleTables.Format.Default);
    }
    AnyKeyBlock();
  }

  private static void Agenda()
  {
    Console.Clear();
    var table = new ConsoleTable("Command");
    table.AddRow("0 - Выход")
         .AddRow("")
         .AddRow("1 - Init data")
         .AddRow("2 - Список подрядчиков")
         .AddRow("3 - Список работников")
         .AddRow("4 - Список заказчиков")
         .AddRow("5 - Список контрактов");
    table.Write(ConsoleTables.Format.Minimal);
  }

  private static void AnyKeyBlock()
  {
    Console.WriteLine();
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
  }

  public static void Main(string[] args)
  {
    navigator.AddNode(new ExitNode());
    


    dict["0"] = CallbackExit;
    dict["1"] = CallbackInitData;
    dict["2"] = CallbackContractorsList;
    dict["3"] = CallbackEmployeesList;
    dict["4"] = CallbackCustomersList;
    dict["5"] = CallbackContractsList;

    Loop();
  }
}