using DBMigration.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBMigration.Business.Tests
{
  [TestClass()]
  public class ContractManagerTests
  {
    [TestMethod()]
    public void RemoveAllTest()
    {
      using AppDbContext appDbContext = new();

      var employee = new Entities.RefEmployee() { Name = "Test" };
      var customer = new Entities.RefCustomer() { Name = "Test" };
      var contractor = new Entities.RefContractor() { Name = "Test" };
      var employeeContract = new Entities.DocEmployeeContract() { Employee = employee, Contractor = contractor };
      var contract = new Entities.DocCustomerContract() { Contractor = contractor, Customer = customer };
      var customerContractInvoce = new Entities.DocCustomerContractInvoce() { Contract = contract };
      var contractAddendum = new Entities.DocEmployeeContractAddendum() { Contract = employeeContract };

      appDbContext.Employees.Add(employee);
      appDbContext.Customer.Add(customer);
      appDbContext.Contractor.Add(contractor);
      appDbContext.EmployeeContract.Add(employeeContract);
      appDbContext.EmployeeContractAddendum.Add(contractAddendum);
      appDbContext.CustomerContract.Add(contract);
      appDbContext.CustomerContractInvoces.Add(customerContractInvoce);
      appDbContext.SaveChanges();

      ContextManager.WipeData();

      Assert.IsFalse(appDbContext.EmployeeContractAddendum.Any());
      Assert.IsFalse(appDbContext.EmployeeContract.Any());
      Assert.IsFalse(appDbContext.CustomerContractInvoces.Any());
      Assert.IsFalse(appDbContext.Employees.Any());
      Assert.IsFalse(appDbContext.CustomerContract.Any());
      Assert.IsFalse(appDbContext.Customer.Any());
      Assert.IsFalse(appDbContext.Contractor.Any());
    }

    [TestMethod()]
    public void PrepareDataTest()
    {
      ContextManager.PrepareData();
      using AppDbContext appDbContext = new();
      Assert.IsTrue(appDbContext.Employees.Where(employee => employee.Name.Equals("Kuzma A")).Any());
      Assert.IsTrue(appDbContext.Employees.Where(employee => employee.Name.Equals("Rybakov S")).Any());

      Assert.IsTrue(appDbContext.Contractor.Where(employee => employee.Name.Equals("Senla")).Any());
      Assert.IsTrue(appDbContext.EmployeeContract.Where(contract => contract.Employee.Name.Equals("Kuzma A") & contract.Contractor.Name.Equals("Senla")).Any());

      Assert.IsTrue(appDbContext.Customer.Where(customer => customer.Name.Equals("Thomson Reuters")).Any());
      Assert.IsTrue(appDbContext.Customer.Where(customer => customer.Name.Equals("MTV Co")).Any());

      Assert.IsTrue(
        appDbContext.CustomerContract
        .Where(
          customerContract => customerContract.Subject.Equals("Eikon") &&
          customerContract.Customer.Name.Equals("Thomson Reuters") &&
          customerContract.Contractor.Name.Equals("Senla")
        ).Any()
        );

      Assert.IsTrue(appDbContext.CustomerContractInvoces.Where(invoce => invoce.Contract.Subject.Equals("Eikon")).Any());
    }

    [TestMethod()]
    public void DrawTableTest()
    {
      Assert.IsTrue(true);
    }
  }
}