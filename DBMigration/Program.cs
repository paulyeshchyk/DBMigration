using System.Linq;
using System.Threading.Tasks.Dataflow;
using DBMigration.Contexts;
using DBMigration.Entities;
using DBMigration.Business;

public class Program
{
  private static void InitData()
  {

    using (ContractContext theContext = new ContractContext())
    {
      RefEmployee user1 = theContext.Employees.FindOrCreateEmployee("Kuzma A");
      RefEmployee user2 = theContext.Employees.FindOrCreateEmployee("Rybakov S");
      RefContractor contractor = theContext.Contractor.FindOrCreateContractor("Senla");

      DocEmployeeContract employeeContract1 = theContext.EmployeeContract.FindOrCreateEmployeeContract(user1, contractor);
      employeeContract1.Subject = "Kuzma subj";

      DocEmployeeContract employeeContract2 = theContext.EmployeeContract.FindOrCreateEmployeeContract(user2, contractor);
      employeeContract2.Subject = "Rubakov subj";

      RefCustomer customerThomson = theContext.Customer.FindOrCreateCustomer("Thomson Reuters");
      RefCustomer customerMTV = theContext.Customer.FindOrCreateCustomer("MTV Co");

      DocCustomerContract contract = theContext.CustomerContract.FindOrCreateCustomerContract(customerThomson, contractor, new List<RefEmployee> { user1 });
      contract.Subject = "Eikon";

      DocCustomerContract contract2 = theContext.CustomerContract.FindOrCreateCustomerContract(customerMTV, contractor, new List<RefEmployee> { user1, user2 });
      contract2.Subject = "Spunch Bob";

      theContext.SaveChanges();

      //contractContext.Employees.Remove(user1);
      //contractContext.SaveChanges();

      Console.WriteLine("Объекты успешно сохранены");

      var users = theContext.Employees.ToList();
      Console.WriteLine("Список объектов:");
      foreach (RefEmployee u in users)
      {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Surname ?? "unknown"}");
      
      }
    }
    Console.Read();
  }

  public static void Main(string[] args)
  {
    InitData();
  }
}