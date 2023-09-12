namespace DBMigration.Entities
{
  public class DocCustomerContract
  {
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public RefContractor contractor { get; set; } = null!;
    public RefCustomer customer { get; set; } = null!;
    public List<RefEmployee> resources { get; set; } = new List<RefEmployee>();
    public List<DocCustomerContractInvoce> Invoces { get; set; } = new List<DocCustomerContractInvoce>();
  }
}
