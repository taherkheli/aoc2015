namespace aoc.D07
{
  public static class Parser
  {
    public static List<Instruction> Parse(string path)
    {
      var result = new List<Instruction>();
      var wires = new List<Wire>();
      var lines = File.ReadLines(path);

      foreach (var line in lines)
        result.Add(Create(line, wires));
   
      return result;
    }

    private static Instruction Create(string s, List<Wire> wires)
    {
      Instruction result = new Instruction();

      //output
      var strings = s.Split("->");
      var s1 = strings[1].Trim().Trim(Environment.NewLine.ToCharArray());
      result.Output = GetWire(s1, wires);

      //inputs & op
      var s0 = strings[0].Trim().Split(' ');

      switch (s0.Length)
      {
        case 1:
          int x;
          if (int.TryParse(s0[0], out x))
            result.ConstInput = (ushort)x;
          else
            result.Input1 = GetWire(s0[0], wires);
          break;

        case 2:
          result.Op = Ops.NOT;
          result.Input1 = GetWire(s0[1], wires);
          break;

        case 3:
          int y;
          if (int.TryParse(s0[0], out y))
            result.ConstInput = (ushort)y;
          else
            result.Input1 = GetWire(s0[0], wires);
          
          result.Op = GetOp(s0[1]);

          if ((result.Op == Ops.LSHIFT) || (result.Op == Ops.RSHIFT))
            result.ConstInput = (ushort)int.Parse(s0[2]);
          else
            result.Input2 = GetWire(s0[2], wires);
          break;

        default:
          throw new Exception("Did not expect this!");         
      }

      if (result.Input1 != null)
        result.Output.Dependencies.Add(result.Input1);

      if (result.Input2 != null)
        result.Output.Dependencies.Add(result.Input2);

      return result;
    }

    private static Wire GetWire(string s, List<Wire> wires)
    {
      var temp = wires.Find(w => w.Id == s);

      if (temp == null)
        return new Wire(s);
      else
        return temp;
    }

    private static Ops GetOp(string s)
    {
      return s switch
      {
        "AND" => Ops.AND,
        "OR" => Ops.OR,
        "LSHIFT" => Ops.LSHIFT,
        "RSHIFT" => Ops.RSHIFT,
        "NONE" => Ops.NONE,
        _ => Ops.UNKNOWN,
      };
    }
  }
}
