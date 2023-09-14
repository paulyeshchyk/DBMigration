using ConsoleTables;

namespace DBMigration.Navigator
{
  public interface ITableDrawer
  {
    public void DrawTable(string? Title, List<NavigatorNode> Nodes);
  }

  internal class TableDrawer : ITableDrawer
  {
    void ITableDrawer.DrawTable(string? Title, List<NavigatorNode> Nodes)
    {
      Console.Clear();

      var table = new ConsoleTable(Title);

      foreach (var node in Nodes.Select((value, i) => new { i, value }))
      {
        table.AddRow($"{node.i} - {node.value.Title}");
      }
      table.Write(ConsoleTables.Format.Minimal);
    }
  }
}