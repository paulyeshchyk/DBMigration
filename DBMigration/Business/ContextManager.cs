﻿using DBMigration.Contexts;
using DBMigration.Entities;

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

      DocCustomerContractInvoce invoce1 = appDbContext.CustomerContractInvoces.FindOrCreateCustomerContractInvoce(contract);
      invoce1.Price = 200;

      DocCustomerContract contract2 = appDbContext.CustomerContract.FindOrCreateCustomerContract(customerMTV, contractor, new List<RefEmployee> { employee1, employee2 });
      contract2.Subject = "Spunch Bob";

      DocCustomerContractInvoce invoce2 = appDbContext.CustomerContractInvoces.FindOrCreateCustomerContractInvoce(contract2);
      invoce2.Price = 100;

      appDbContext.SaveChanges();

      Console.WriteLine("Объекты успешно сохранены");
      appDbContext.Employees.DrawList();
    }

    public static void WipeData()
    {
      using AppDbContext appDbContext = new();

      var addendum = from a in appDbContext.EmployeeContractAddendum select a;
      Console.WriteLine($"deleted {addendum.Count()} record(s) from addendum");
      appDbContext.EmployeeContractAddendum.RemoveAll(appDbContext);

      var invoces = from i in appDbContext.CustomerContractInvoces select i;
      Console.WriteLine($"deleted {invoces.Count()} record(s) from invoces");
      appDbContext.CustomerContractInvoces.RemoveAll(appDbContext);

      var contracts = from c in appDbContext.EmployeeContract select c;
      Console.WriteLine($"deleted {contracts.Count()} record(s) from contracts");
      appDbContext.EmployeeContract.RemoveAll(appDbContext);

      var customerContracts = from c in appDbContext.CustomerContract select c;
      Console.WriteLine($"deleted {customerContracts.Count()} record(s) from customerContracts");
      appDbContext.CustomerContract.RemoveAll(appDbContext);

      var contractors = from c in appDbContext.Contractor select c;
      Console.WriteLine($"deleted {contractors.Count()} record(s) from contractors");
      appDbContext.Contractor.RemoveAll(appDbContext);

      var customers = from c in appDbContext.Customer select c;
      Console.WriteLine($"deleted {customers.Count()} record(s) from customers");
      appDbContext.Customer.RemoveAll(appDbContext);

      var employees = from e in appDbContext.Employees select e;
      Console.WriteLine($"deleted {employees.Count()} record(s) from employees");
      appDbContext.Employees.RemoveAll(appDbContext);

      appDbContext.SaveChanges();
    }
  }
}