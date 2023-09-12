﻿using ConsoleTables;
using DBMigration.Contexts;
using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class ContractManager
  {

    public static DocCustomerContractInvoce FindOrCreateCustomerContractInvoce(this DbSet<DocCustomerContractInvoce> dbSet, DocCustomerContract contract)
    {
      IQueryable<DocCustomerContractInvoce> set = dbSet.Where(i => i.Contract == contract && i.IsClosed == false);
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found invoce for customer: {contract.Customer.Name}");
        return set.First();
      }

      var invoce = new DocCustomerContractInvoce
      {
        Contract = contract
      };
      contract.Invoces.Add(invoce);
      dbSet.Add(invoce);
      return invoce;
    }
    public static DocCustomerContract FindOrCreateCustomerContract(this DbSet<DocCustomerContract> dbSet, RefCustomer customer, RefContractor contractor, List<RefEmployee> users)
    {

      IQueryable<DocCustomerContract> set = dbSet.Where(c => c.Contractor == contractor && c.Customer == customer);
      if (set.Count() == 1)
      {
        Console.WriteLine($"Found contract for outsourcer: {contractor.Name}");
        return set.First();
      }

      var contract = new DocCustomerContract
      {
        Customer = customer,
        Contractor = contractor
      };

      foreach (RefEmployee user in users)
      {
        contract.Resources.Add(user);
      }
      dbSet.Add(contract);

      return contract;
    }


    public static void DrawList()
    {
      using AppDbContext appDbContext = new();
      var table = new ConsoleTable("Name", "К-во счетов");
      var set = appDbContext.CustomerContract
        .Include(x => x.Invoces);

      foreach (var contract in set.ToList())
      {
        table.AddRow(contract.Subject, contract.Invoces.Count);
      };
      table.Write(ConsoleTables.Format.Default);
    }
  }
}