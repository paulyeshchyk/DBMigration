using DBMigration.Contexts;
using DBMigration.Entities;
using DBMigration.Resources;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class ContractManager
  {
    public static void DrawTable()
    {
      using AppDbContext appDbContext = new();
      var set = appDbContext.CustomerContract.Include(x => x.Invoces);
      set.ToList().DrawConsoleTable();
    }

    public static DocCustomerContract FindOrCreateCustomerContract(this DbSet<DocCustomerContract> dbSet, RefCustomer customer, RefContractor contractor, List<RefEmployee> users)
    {
      var set = dbSet.Where(c => c.Contractor == contractor && c.Customer == customer);
      if (set.Any())
      {
        Console.WriteLine(strings.FoundContractForOutsourcer, contractor.Name);
        return set.First();
      }

      var contract = new DocCustomerContract
      {
        Customer = customer,
        Contractor = contractor
      };

      contract.Resources.AddRange(users);
      dbSet.Add(contract);

      return contract;
    }

    public static DocCustomerContractInvoce FindOrCreateCustomerContractInvoice(this DbSet<DocCustomerContractInvoce> dbSet, DocCustomerContract contract)
    {
      var set = dbSet.Where(i => i.Contract == contract && i.IsClosed == false);
      if (set.Any())
      {

        var message = string.Format(strings.FoundInvoceForCustomerTemplate, contract.Customer.Name);
        Console.WriteLine(message);
        return set.First();
      }

      var invoice = new DocCustomerContractInvoce { Contract = contract };
      contract.Invoces.Add(invoice);
      dbSet.Add(invoice);
      return invoice;
    }
  }
}