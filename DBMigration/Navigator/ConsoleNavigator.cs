namespace DBMigration.Navigator
{
  public delegate void NodeBlock(ConsoleNavigator navigator);

  public class ConsoleNavigator : INavigator
  {
    private readonly List<NavigatorNode> Nodes = new();

    public ConsoleNavigator(ITableDrawer tableDrawer)
    {
      this.TableDrawer = tableDrawer;
    }

    private ITableDrawer TableDrawer { get; set; }

    public void DrawMenuAndWait(string? title)
    {
      this.TableDrawer.DrawTable(title, Nodes);
      WaitForUserCommand(title);
    }

    public void SetNodes(List<NavigatorNode> nodes)
    {
      this.Nodes.Clear();
      this.Nodes.AddRange(nodes);
    }

    public void WaitForAnykeyPress()
    {
      Console.WriteLine();
      Console.WriteLine("Press any key to continue");
      Console.ReadKey();
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
      DrawMenuAndWait(node.Context);
    }
  }
}