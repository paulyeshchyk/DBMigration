using DBMigration.Navigator;
using DBMigration.Resources;

namespace DBMigration.Business
{
  public static class NavigatorNodeItems
  {
    public static readonly List<NavigatorNode> Level2DocsNodes = new()
    {
      new NavigatorNode(LocalizedStrings.NodeStand, LocalizedStrings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(LocalizedStrings.NodeDocument, LocalizedStrings.TitleContracts, NavigatorNodeActionsContractor.Level1ContractListBlock)
    };

    public static readonly List<NavigatorNode> LevelEmployeeNodes = new()
    {
      new NavigatorNode(LocalizedStrings.NodeStand, LocalizedStrings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(LocalizedStrings.NodeEmployees,LocalizedStrings.TitleEmployeeList, NavigatorNodeActionsEmployee.Level1EmployeeListBlock),
      new NavigatorNode(LocalizedStrings.NodeEmployees,LocalizedStrings.TitleAdd,NavigatorNodeActionsEmployee.Level1EmployeeAddBlock),
      new NavigatorNode(LocalizedStrings.NodeEmployees,LocalizedStrings.TitleEdit,NavigatorNodeActionsEmployee.Level1EmployeeEditBlock),
      new NavigatorNode(LocalizedStrings.NodeEmployees,LocalizedStrings.TitleDelete, NavigatorNodeActionsEmployee.Level1EmployeeDeleteBlock)
    };

    public static readonly List<NavigatorNode> LevelRefsNodes = new()
    {
      new NavigatorNode(LocalizedStrings.NodeStand, LocalizedStrings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(LocalizedStrings.NodeEmployees,LocalizedStrings.TitleEmployees, NavigatorNodeActionsEmployee.Level1EmployeeBlock),
      new NavigatorNode(LocalizedStrings.NodeReferences,LocalizedStrings.TitleContractors,NavigatorNodeActionsContractor.Level1ContractorsListBlock),
      new NavigatorNode(LocalizedStrings.NodeReferences,LocalizedStrings.TitleCustomers, NavigatorNodeActionsCustomer.Level1CustomerListBlock)
    };

    public static List<NavigatorNode> LevelContextNodes = new()
    {
      new NavigatorNode(LocalizedStrings.NodeStand, LocalizedStrings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(LocalizedStrings.NodeContext,LocalizedStrings.TitleFillTableWithFakeData, NavigatorNodeActionsContext.LevelContextAddDataBlock),
      new NavigatorNode(LocalizedStrings.NodeContext,LocalizedStrings.TitleWipeTables, NavigatorNodeActionsContext.LevelContextWipeDataBlock),
    };

    public static List<NavigatorNode> LevelTranslationNodes = new()
    {
      new NavigatorNode(LocalizedStrings.NodeStand, LocalizedStrings.TitleMainMenu, NavigatorNodeActions.Level1LevelUpBlock),
      new NavigatorNode(LocalizedStrings.NodeContext, LocalizedStrings.TitleTranslationsDefault, NavigatorNodeTranslationsContext.LevelGotoTranslationsDefaultBlock),
      new NavigatorNode(LocalizedStrings.NodeReferences, LocalizedStrings.TitleTranslationsRuRU, NavigatorNodeTranslationsContext.LevelGotoTranslationsRuRuBlock)
    };

    public static List<NavigatorNode> LevelRootNodes = new()
    {
      new NavigatorNode(LocalizedStrings.NodeStand, LocalizedStrings.TitleExit, NavigatorNodeActions.Level0ExitBlock),
      new NavigatorNode(LocalizedStrings.NodeContext,LocalizedStrings.TitleContextPreparation, NavigatorNodeActionsContext.Level0GotoContextBlock),
      new NavigatorNode(LocalizedStrings.NodeReferences,LocalizedStrings.TitleReferences, NavigatorNodeActionsRefs.Level0GotoReferencesBlock),
      new NavigatorNode(LocalizedStrings.NodeDocument,LocalizedStrings.TitleDocuments, NavigatorNodeActionsDocs.Level0GotoDocBlock),
      new NavigatorNode(LocalizedStrings.NodeDocument,LocalizedStrings.TitleTranslations, NavigatorNodeActions.Level0TranslationsBlock)
    };
  }
}