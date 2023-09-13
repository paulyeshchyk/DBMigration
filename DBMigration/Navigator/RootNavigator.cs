using ConsoleTables;

namespace DBMigration.Navigator
{
  public delegate void NodeBlock(RootNavigator navigator);
  public class RootNavigatorNode
  {
    public string Title { get; set; } = string.Empty;
    public string Context { get; set; } = string.Empty;
    public NodeBlock ExecutionBlock { get; set; }

    public RootNavigatorNode(string context, string title, NodeBlock block)
    {
      this.Context = context;
      this.Title = title;
      this.ExecutionBlock = block;
    }
  }
  public class RootNavigator
  {
    private readonly List<RootNavigatorNode> nodes = new();

    public void Loop(string? title)
    {
      Agenda(title);
      Console.Write("Select command: ");
      var readKeyResult = Console.ReadLine();
      if (readKeyResult == null)
      {
        Loop(title);
        return;
      }

      string? blockTitle = null;
      NodeBlock? block = null;
      try
      {
        int index = int.Parse(readKeyResult);
        var node = nodes.ElementAt(index);
        block = node.ExecutionBlock;
        blockTitle = node.Title;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
      }
      if (block == null)
      {
        Loop(title);
        return;
      }
      block(this);
      //
      Loop(blockTitle);
    }

    public void AnyKeyBlock()
    {
      Console.WriteLine();
      Console.WriteLine("Press any key to continue");
      Console.ReadKey();
    }
    private void Agenda(string? title)
    {
      Console.Clear();
      var table = new ConsoleTable(title);

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
