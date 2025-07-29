namespace aoc.D07
{
  public class Circuit
  {
    private List<Instruction> _instructions;

    public Circuit(List<Instruction> instructions)
    {
      _instructions = instructions;
    }

    public int Emulate(bool isPartII = false)
    {
      //get the two with constant values as the only input
      var orderedList = new List<Instruction>(_instructions.FindAll(i => i.Output?.Dependencies.Count == 0));

      while (true)
      {
        var toBeAdded = new List<Instruction>();

        foreach (var item in _instructions)
        {
          var canBeSolved = true;

          if (item.Output?.Dependencies != null)
          {
            foreach (var dependency in item.Output.Dependencies)
            {
              if (IsAlreadySolvable(dependency, orderedList) == false)
              {
                canBeSolved = false;
                break;
              }
            }
          }

          if (canBeSolved)
            toBeAdded.Add(item);
        }

        foreach (var item in toBeAdded)
        {
          if (!orderedList.Contains(item))
            orderedList.Add(item);
        }

        if (orderedList.Count == _instructions.Count)
          break;
      }

      var wires = new List<Wire>();

      foreach (var item in orderedList)
        if (item.Output != null)
          wires.Add(new Wire(item.Output.Id));

      foreach (var inst in orderedList)
        inst.Execute(wires);

      var wire_a = wires.Find(w => w.Id == "a") ?? throw new KeyNotFoundException("Wire 'a' not found");

      if (isPartII)
      {
        var inst_b = orderedList.Find(i => i.Output?.Id == "b");

        if (inst_b != null)
          inst_b.ConstInput = wire_a.Signal;

        foreach (var inst in orderedList)
          inst.Execute(wires);

        wire_a = wires.Find(w => w.Id == "a") ?? throw new KeyNotFoundException("Wire 'a' not found");
      }

      return wire_a.Signal;
    }

    private static bool IsAlreadySolvable(Wire w, List<Instruction> list)
    {
      bool result = false;

      foreach (var item in list)
      {
        if (item.Output?.Id == w.Id)
        {
          result = true;
          break;
        }
      }

      return result;
    }
  }
}
