using DBMigration.Navigator;

namespace DBMigration.Business
{
  public static class NavigatorNodeItems
  {
    public static readonly List<NavigatorNode> Level2DocsNodes = new()
    {
      new NavigatorNode("Документы", "Exit", NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode("Документы", "Контракты", NavigatorNodeActionsContractor.Level1ContractListBlock)
    };

    public static readonly List<NavigatorNode> LevelEmployeeNodes = new()
    {
      new NavigatorNode("Работники", "Exit", NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode("Работники","Список", NavigatorNodeActionsEmployee.Level1EmployeeListBlock),
      new NavigatorNode("Работники","Добавить",NavigatorNodeActionsEmployee.Level1EmployeeAddBlock),
      new NavigatorNode("Работники","Изменить",NavigatorNodeActionsEmployee.Level1EmployeeEditBlock),
      new NavigatorNode("Работники","Удалить", NavigatorNodeActionsEmployee.Level1EmployeeDeleteBlock)
    };

    public static readonly List<NavigatorNode> LevelRefsNodes = new()
    {
      new NavigatorNode("Справочники", "Exit", NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode("Справочники","Работники", NavigatorNodeActionsEmployee.Level1EmployeeBlock),
      new NavigatorNode("Справочники","Подрядчики",NavigatorNodeActionsContractor.Level1ContractorsListBlock),
      new NavigatorNode("Справочники","Заказчики", NavigatorNodeActionsCustomer.Level1CustomerListBlock)
    };

    public static List<NavigatorNode> LevelContextNodes = new()
    {
      new NavigatorNode("Контекст", "Exit", NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode("Контекст","Заполнить таблицы тестовыми данными", NavigatorNodeActionsContext.LevelContextAddDataBlock),
      new NavigatorNode("Контекст","Очистить таблицы", NavigatorNodeActionsContext.LevelContextWipeDataBlock),
    };

    public static List<NavigatorNode> LevelRootNodes = new()
    {
      new NavigatorNode("Стэнд", "Exit", NavigatorNodeActions.Level0ExitBlock),
      new NavigatorNode("Стэнд","Подготовить контекст", NavigatorNodeActionsContext.Level0GotoContextBlock),
      new NavigatorNode("Стэнд","Справочники", NavigatorNodeActionsRefs.Level0GotoReferencesBlock),
      new NavigatorNode("Стэнд","Документы", NavigatorNodeActionsDocs.Level0GotoDocBlock)
    };
  }
}