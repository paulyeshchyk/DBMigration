namespace DBMigration.Navigator
{
  public interface INavigator
  {
    void DrawMenuAndWait(string? title);

    void SetNodes(List<NavigatorNode> nodes);

    void WaitForAnykeyPress();
  }
}