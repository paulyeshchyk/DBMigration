using DBMigration.Contexts;
using DBMigration.Entities;
using DBMigration.Resources;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class ContextManager
  {
    public static void PrepareData()
    {
      using AppDbContext appDbContext = new();

      RefEmployee employee1 = appDbContext.Employees.FindOrCreateEmployee("Kuzma A", null);
      RefEmployee employee2 = appDbContext.Employees.FindOrCreateEmployee("Rybakov S", null);
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

      DocCustomerContractInvoce invoce1 = appDbContext.CustomerContractInvoces.FindOrCreateCustomerContractInvoice(contract);
      invoce1.Price = 200;

      DocCustomerContract contract2 = appDbContext.CustomerContract.FindOrCreateCustomerContract(customerMTV, contractor, new List<RefEmployee> { employee1, employee2 });
      contract2.Subject = "Spunch Bob";

      DocCustomerContractInvoce invoce2 = appDbContext.CustomerContractInvoces.FindOrCreateCustomerContractInvoice(contract2);
      invoce2.Price = 100;

      appDbContext.SaveChanges();
    }

    public static void WipeData()
    {
      using AppDbContext appDbContext = new();

      var addendum = from a in appDbContext.EmployeeContractAddendum select a;
      Console.WriteLine(LocalizedStrings.DeletedRecordsForAddendumTemplate, addendum.Count());
      appDbContext.EmployeeContractAddendum.RemoveAll(appDbContext);

      var invoces = from i in appDbContext.CustomerContractInvoces select i;
      Console.WriteLine(LocalizedStrings.DeletedRecordsForInvocesTemplate, invoces.Count());
      appDbContext.CustomerContractInvoces.RemoveAll(appDbContext);

      var contracts = from c in appDbContext.EmployeeContract select c;
      Console.WriteLine(LocalizedStrings.DeletedRecordsFromContractsTemplate, contracts.Count());
      appDbContext.EmployeeContract.RemoveAll(appDbContext);

      var customerContracts = from c in appDbContext.CustomerContract select c;
      Console.WriteLine(LocalizedStrings.DeletedRecordsFromCustomerContractsTemplate, customerContracts.Count());
      appDbContext.CustomerContract.RemoveAll(appDbContext);

      var contractors = from c in appDbContext.Contractor select c;
      Console.WriteLine(LocalizedStrings.DeletedRecordsFromContractorsTemplate, contractors.Count());
      appDbContext.Contractor.RemoveAll(appDbContext);

      var customers = from c in appDbContext.Customer select c;
      Console.WriteLine(LocalizedStrings.DeletedRecordsFromCustomersTemplate, customers.Count());
      appDbContext.Customer.RemoveAll(appDbContext);

      var employees = from e in appDbContext.Employees select e;
      Console.WriteLine(string.Format(LocalizedStrings.DeletedRecordsFromEmployeesTemplate, 0), employees.Count());
      appDbContext.Employees.RemoveAll(appDbContext);

      appDbContext.SaveChanges();
    }

    public static void RemoveAll(this DbSet<RefEmployee> dbSet, DbContext context)
    {
      dbSet.ToList().ForEach(e => { _ = context.Remove(e); });
    }

    public static void RemoveAll(this DbSet<RefCustomer> dbSet, DbContext context)
    {
      dbSet.ToList().ForEach(e => { _ = context.Remove(e); });
    }

    public static void RemoveAll(this DbSet<RefContractor> dbSet, DbContext context)
    {
      dbSet.ToList().ForEach(e => { _ = context.Remove(e); });
    }

    public static void RemoveAll(this DbSet<DocCustomerContract> dbSet, DbContext context)
    {
      dbSet.ToList().ForEach(e => { _ = context.Remove(e); });
    }

    public static void RemoveAll(this DbSet<DocEmployeeContract> dbSet, DbContext context)
    {
      dbSet.ToList().ForEach(e => { _ = context.Remove(e); });
    }

    public static void RemoveAll(this DbSet<DocCustomerContractInvoce> dbSet, DbContext context)
    {
      dbSet.ToList().ForEach(e => { _ = context.Remove(e); });
    }

    public static void RemoveAll(this DbSet<DocEmployeeContractAddendum> dbSet, DbContext context)
    {
      dbSet.ToList().ForEach(e => { _ = context.Remove(e); });
    }
  }
}