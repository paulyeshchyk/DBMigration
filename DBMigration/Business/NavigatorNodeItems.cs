using DBMigration.Navigator;
using DBMigration.Resources;

namespace DBMigration.Business
{
  public static class NavigatorNodeItems
  {
    public static readonly List<NavigatorNode> Level2DocsNodes = new()
    {
      new NavigatorNode(strings.NodeStand, strings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(strings.NodeDocument, strings.TitleContracts, NavigatorNodeActionsContractor.Level1ContractListBlock)
    };

    public static readonly List<NavigatorNode> LevelEmployeeNodes = new()
    {
      new NavigatorNode(strings.NodeStand, strings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(strings.NodeEmployees,strings.TitleEmployeeList, NavigatorNodeActionsEmployee.Level1EmployeeListBlock),
      new NavigatorNode(strings.NodeEmployees,strings.TitleAdd,NavigatorNodeActionsEmployee.Level1EmployeeAddBlock),
      new NavigatorNode(strings.NodeEmployees,strings.TitleEdit,NavigatorNodeActionsEmployee.Level1EmployeeEditBlock),
      new NavigatorNode(strings.NodeEmployees,strings.TitleDelete, NavigatorNodeActionsEmployee.Level1EmployeeDeleteBlock)
    };

    public static readonly List<NavigatorNode> LevelRefsNodes = new()
    {
      new NavigatorNode(strings.NodeStand, strings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(strings.NodeEmployees,strings.TitleEmployees, NavigatorNodeActionsEmployee.Level1EmployeeBlock),
      new NavigatorNode(strings.NodeReferences,strings.TitleContractors,NavigatorNodeActionsContractor.Level1ContractorsListBlock),
      new NavigatorNode(strings.NodeReferences,strings.TitleCustomers, NavigatorNodeActionsCustomer.Level1CustomerListBlock)
    };

    public static List<NavigatorNode> LevelContextNodes = new()
    {
      new NavigatorNode(strings.NodeStand, strings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(strings.NodeContext,strings.TitleFillTableWithFakeData, NavigatorNodeActionsContext.LevelContextAddDataBlock),
      new NavigatorNode(strings.NodeContext,strings.TitleWipeTables, NavigatorNodeActionsContext.LevelContextWipeDataBlock),
    };

    public static List<NavigatorNode> LevelTranslationNodes = new()
    {
      new NavigatorNode(strings.NodeStand, strings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(strings.NodeContext, strings.TitleTranslationsDefault, NavigatorNodeTranslationsContext.LevelGotoTranslationsDefaultBlock),
      new NavigatorNode(strings.NodeReferences, strings.TitleTranslationsRuRU, NavigatorNodeTranslationsContext.LevelGotoTranslationsRuRuBlock)
    };

    public static List<NavigatorNode> LevelRootNodes = new()
    {
      new NavigatorNode(strings.NodeStand, strings.TitleExit, NavigatorNodeActions.Level0ExitBlock),
      new NavigatorNode(strings.NodeContext,strings.TitleContextPreparation, NavigatorNodeActionsContext.Level0GotoContextBlock),
      new NavigatorNode(strings.NodeReferences,strings.TitleReferences, NavigatorNodeActionsRefs.Level0GotoReferencesBlock),
      new NavigatorNode(strings.NodeDocument,strings.TitleDocuments, NavigatorNodeActionsDocs.Level0GotoDocBlock),
      new NavigatorNode(strings.NodeDocument,strings.TitleTranslations, NavigatorNodeActions.Level0TranslationsBlock)
    };
  }
}