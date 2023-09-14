namespace DBMigration.Entities
{
  public class DocEmployeeContractAddendum
  {
    public int Id { get; set; }
    public DocEmployeeContract Contract { get; set; } = null!;
    public string Addendum { get; set; } = string.Empty;
    public bool IsValid { get; set; } = true;
  }
}