namespace DBMigration.Entities
{
  public class DocCustomerContractInvoce
  {
    public int Id { get; set; }
    public int Price { get; set; }
    public DocCustomerContract Contract { get; set; } = null!;
    public bool IsClosed { get; set; }
  }
}
