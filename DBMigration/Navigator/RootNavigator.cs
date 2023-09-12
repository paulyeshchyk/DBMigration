using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMigration.Navigator
{
  public delegate void NodeBlock();
  public class RootNavigatorNode
  {
    public string title { get; set; } = string.Empty;
    public NodeBlock block { get; set; }

    public RootNavigatorNode(string title, NodeBlock block)
    {
      this.title = title;
      this.block = block;
    }

    

  }
  public class RootNavigator
  {
    private List<RootNavigatorNode> nodes = new List<RootNavigatorNode>();

    public RootNavigator() { 
    }
    
    public void AddNode(RootNavigatorNode node)
    {
      nodes.Add(node)
    }
  }
}
