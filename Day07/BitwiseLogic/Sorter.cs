using System.Collections.Generic;

namespace BitwiseLogic
{
  public class Sorter
  {
    private readonly List<Wire> _visited = new List<Wire>();

    public Sorter()
    {
      _visited = new List<Wire>();
    }

    public List<Instruction> SortTopographically(List<Instruction> instructions)
    {
      var result = new List<Instruction>();
      List<Wire> allWires = new List<Wire>();

      foreach (var item in instructions)
        allWires.Add(item.Output);

      DFS(allWires);
      
      for (int i = 0; i < _visited.Count; i++)
      {
        var temp = instructions.Find(inst => inst.Output.Id == _visited[i].Id);

        if (temp != null)
          result.Add(temp);
      }

      return result;
    }

    private void DFS(List<Wire> allWires)
    {
      //assuming no cycles and a DAG      
      foreach (var wire in allWires)
      {
        var temp = _visited.Find(w => w.Id == wire.Id);

        if (temp == null)
          DFS_Visit(wire, allWires);        
      }
    }

    private void DFS_Visit(Wire s, List<Wire> allWires)
    {
      if (s.Dependencies.Count == 0)
      {
        var temp = _visited.Find(w => w.Id == s.Id);
        if (temp == null)
          _visited.Add(s);
      }
      else
      {
        foreach (var v in s.Dependencies)
        {
          var temp = _visited.Find(w => w.Id == s.Id);

          if (temp == null)
          {
            _visited.Add(s);
            temp = allWires.Find(w => w.Id == v.Id);

            if (temp != null)
              DFS_Visit(temp, allWires);
          }
        }
      }
    }
  }
}