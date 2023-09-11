namespace DBMigration.Entities
{
  public class DocEmployeeContract
  {
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ValidTillDate { get; set; } = DateTime.Now.AddDays(365);
    public RefEmployee Employee { get; set; } = null!;
    public RefContractor Contractor { get; set; } = null!;
  }
}
