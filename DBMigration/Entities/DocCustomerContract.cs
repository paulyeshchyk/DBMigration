namespace DBMigration.Entities
{
  public class DocCustomerContract
  {
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public RefContractor Contractor { get; set; } = null!;
    public RefCustomer Customer { get; set; } = null!;
    public List<RefEmployee> Resources { get; set; } = new List<RefEmployee>();
    public List<DocCustomerContractInvoce> Invoces { get; set; } = new List<DocCustomerContractInvoce>();
  }
}
