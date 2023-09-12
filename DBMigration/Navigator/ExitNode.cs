using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMigration.Navigator
{
  public class ExitNode : RootNavigatorNode
  {
    public ExitNode(string title, NodeBlock block) : base(title, block)
    {
    }
  }
}
