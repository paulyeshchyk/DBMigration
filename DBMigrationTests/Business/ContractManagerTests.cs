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
  }
}