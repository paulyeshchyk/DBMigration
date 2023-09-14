using DBMigration.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBMigration.Business
{
  public static class EmployeeContractManager
  {
    public static DocEmployeeContract? FindEmployeeContract(this DbSet<DocEmployeeContract> dbSet, RefEmployee employee, RefContractor contractor)
    {
      IQueryable<DocEmployeeContract> set = dbSet.Where(c => c.Employee == employee & c.Contractor == contractor);
      if (set.Any()) { return set.First(); }

      return null;
    }

    public static DocEmployeeContract FindOrCreateEmployeeContract(this DbSet<DocEmployeeContract> dbSet, RefEmployee employee, RefContractor contractor)
    {
      DocEmployeeContract? result = dbSet.FindEmployeeContract(employee, contractor);
      if (null != result) { return result; }

      Console.WriteLine($"Adding contract for: {employee.Name}");

      return dbSet.NewEmployeeContract(employee, contractor);
    }

    public static DocEmployeeContractAddendum FindOrCreateValidAddendum(this DbSet<DocEmployeeContractAddendum> dbSet, DocEmployeeContract contract)
    {
      IQueryable<DocEmployeeContractAddendum> set = dbSet.Where(a => a.IsValid == true && a.Contract == contract);
      if (set.Any()) { return set.First(); }

      return NewAddendum(dbSet, contract);
    }

    public static DocEmployeeContract NewEmployeeContract(this DbSet<DocEmployeeContract> dbSet, RefEmployee employee, RefContractor contractor)
    {
      var result = new DocEmployeeContract { Employee = employee, Contractor = contractor };
      dbSet.Add(result);
      return result;
    }

    private static DocEmployeeContractAddendum NewAddendum(DbSet<DocEmployeeContractAddendum> dbSet, DocEmployeeContract contract)
    {
      var result = new DocEmployeeContractAddendum { Contract = contract };
      contract.AddendumList.Add(result);
      dbSet.Add(result);
      return result;
    }
  }
}