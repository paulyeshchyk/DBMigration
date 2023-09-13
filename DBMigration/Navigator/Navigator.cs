namespace DBMigration.Navigator
{
  public delegate void NodeBlock(Navigator navigator);
  public class Navigator
  {
    private readonly List<NavigatorNode> Nodes = new();
    private ITableDrawer TableDrawer { get; set; }

    public Navigator(ITableDrawer tableDrawer)
    {
      this.TableDrawer = tableDrawer;
    }

    private NavigatorNode? GetNodeForCommand(string? command)
    {
      NavigatorNode? result = null;
      if (string.IsNullOrEmpty(command)) { return result; }

      try
      {
        int index = int.Parse(command);
        result = Nodes.ElementAt(index);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
      }
      return result;
    }

    private void WaitForUserCommand(string? title)
    {
      Console.Write("Select command: ");
      var readKeyResult = Console.ReadLine();
      var node = GetNodeForCommand(readKeyResult);
      if (node == null)
      {
        DrawMenuAndWait(title);
        return;
      }
      node.ExecutionBlock(this);
      DrawMenuAndWait(node.Title);
    }

    public void DrawMenuAndWait(string? title)
    {
      this.TableDrawer.DrawTable(title, Nodes);
      WaitForUserCommand(title);
    }

    public static void WaitForAnykeyPress()
    {
      Console.WriteLine();
      Console.WriteLine("Press any key to continue");
      Console.ReadKey();
    }
    public void SetNodes(List<NavigatorNode> nodes)
    {
      this.Nodes.Clear();
      this.Nodes.AddRange(nodes);
    }
  }
}
