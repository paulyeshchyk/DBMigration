using ConsoleTables;

namespace DBMigration.Navigator
{
  public delegate void NodeBlock(RootNavigator navigator);
  public class RootNavigatorNode
  {
    public string Title { get; set; } = string.Empty;
    public NodeBlock ExecutionBlock { get; set; }

    public RootNavigatorNode(string title, NodeBlock block)
    {
      this.Title = title;
      this.ExecutionBlock = block;
    }
  }
  public class RootNavigator
  {
    private readonly List<RootNavigatorNode> nodes = new();

    public void Loop()
    {
      Agenda();
      Console.Write("Select command: ");
      var readKeyResult = Console.ReadLine();
      if (readKeyResult == null)
      {
        Loop();
        return;
      }

      NodeBlock? block = null;
      try
      {
        int index = int.Parse(readKeyResult);
        var node = nodes.ElementAt(index);
        block = node.ExecutionBlock;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
      }
      if (block == null)
      {
        Loop();
        return;
      }
      block(this);
      //
      Loop();
    }

    public void AnyKeyBlock()
    {
      Console.WriteLine();
      Console.WriteLine("Press any key to continue");
      Console.ReadKey();
    }
    private void Agenda()
    {
      Console.Clear();
      var table = new ConsoleTable("Command");

      foreach (var node in nodes.Select((value, i) => new { i, value }))
      {
        table.AddRow($"{node.i} - {node.value.Title}");
      }
      table.Write(ConsoleTables.Format.Minimal);
    }

    public void DrawNodes(List<NavigatorNode> nodesToDraw)
    {
      nodes.Clear();
      foreach (var node in nodesToDraw)
      {
        nodes.Add(node);
      }
    }
  }
}
