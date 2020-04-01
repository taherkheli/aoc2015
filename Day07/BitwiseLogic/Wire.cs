using System.Collections.Generic;

namespace BitwiseLogic
{
  public class Wire
  {
    private readonly string _id;
    private ushort _signal;
    private List<Wire> _dependencies;

    public Wire(string id)
    {
      _id = id;
      _dependencies = new List<Wire>();
    }

    public string Id => _id;
    public ushort Signal { get => _signal; set => _signal = value; }
    public List<Wire> Dependencies { get => _dependencies; set => _dependencies = value; }
  }
}
