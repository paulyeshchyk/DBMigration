using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class FindEntity
  {
    public static RefEmployee FindOrCreateEmployee(this DbSet<RefEmployee> dbSet, string employeeName)
    {
      IQueryable<RefEmployee> set = dbSet.Where(u => employeeName.Equals(u.Name));
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found user by name: {employeeName}");
        return set.First();
      }
      Console.WriteLine($"Adding user by name: {employeeName}");

      var result = new RefEmployee { Name = employeeName };
      dbSet.Add(result);
      return result;
    }

    public static RefContractor FindOrCreateContractor(this DbSet<RefContractor> dbSet, string name)
    {
      IQueryable<RefContractor> set = dbSet.Where(o => name.Equals(o.Name));
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found outsourcer by name: {name}");
        return set.First();
      }

      Console.WriteLine($"Adding outsourcer by name: {name}");
      var result = new RefContractor { Name = name };
      dbSet.Add(result);
      return result;
    }

    public static DocEmployeeContract FindOrCreateEmployeeContract(this DbSet<DocEmployeeContract> dbSet, RefEmployee employee, RefContractor contractor)
    {
      IQueryable<DocEmployeeContract> set = dbSet.Where(c => c.Employee == employee & c.Contractor == contractor);
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found employee contract by name: {employee.Name}");
        return set.First();
      }

      Console.WriteLine($"Adding contract for: {employee.Name}");
      var result = new DocEmployeeContract();
      result.Employee = employee;
      result.Contractor = contractor;
      dbSet.Add(result);
      return result;
    }

    public static DocCustomerContract FindOrCreateCustomerContract(this DbSet<DocCustomerContract> dbSet, RefCustomer customer, RefContractor contractor, List<RefEmployee> users)
    {

      IQueryable<DocCustomerContract> set = dbSet.Where(c => c.contractor == contractor && c.customer == customer);
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found contract for outsourcer: {contractor.Name}");
        return set.First();
      }

      var contract = new DocCustomerContract();
      contract.customer = customer;
      contract.contractor = contractor;

      foreach (RefEmployee user in users)
      {
        contract.resources.Add(user);
      }
      dbSet.Add(contract);

      return contract;
    }

    public static RefCustomer FindOrCreateCustomer(this DbSet<RefCustomer> dbSet, string customerName)
    {
      IQueryable<RefCustomer> set = dbSet.Where(c => customerName.Equals(c.Name));
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found company by name: {customerName}");
        return set.First();
      }

      Console.WriteLine($"Adding company by name: {customerName}");
      var result = new RefCustomer { Name = customerName };
      dbSet.Add(result);
      return result;
    }

  }
}
