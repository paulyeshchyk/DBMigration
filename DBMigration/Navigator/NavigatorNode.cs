namespace DBMigration.Navigator
{
  public class NavigatorNode
  {
    public string Title { get; set; } = string.Empty;
    public string Context { get; set; } = string.Empty;
    public NodeBlock ExecutionBlock { get; set; }

    public NavigatorNode(string context, string title, NodeBlock block)
    {
      this.Context = context;
      this.Title = title;
      this.ExecutionBlock = block;
    }
  }
}
