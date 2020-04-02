using System;
using System.Collections.Generic;

namespace BitwiseOps
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      var instructions = Utils.Parse(path);
      int count = instructions.Count;

      //get the two with constant values as the only input
      List<Instruction> ordererdList = new List<Instruction>(instructions.FindAll(i => i.Output.Dependencies.Count == 0));
      
      while (true)
      {
        List<Instruction> toBeAdded = new List<Instruction>();

        foreach (var item in instructions)
        {
          var canBeSolved = true;

          foreach (var dependency in item.Output.Dependencies)
          {
            if (IsALreadySolvable(dependency, ordererdList) == false)
            {
              canBeSolved = false;
              break;
            }
          }

          if (canBeSolved)
            toBeAdded.Add(item);
        }

        foreach (var item in toBeAdded)
        {
          if (!ordererdList.Contains(item))
            ordererdList.Add(item);
        }

        if (ordererdList.Count == count)
          break;
      }
      
      var wires = new List<Wire>();

      foreach (var item in ordererdList)
        wires.Add(new Wire(item.Output.Id));   

      foreach (var inst in ordererdList)
        inst.Execute(wires);

      var a = wires.Find(w => w.Id == "a");
      Console.WriteLine("\nPartI: wire '{0}' carries a signal: '{1}'", a.Id, a.Signal);
    }


    private static bool IsALreadySolvable(Wire w, List<Instruction> list)
    {
      bool result = false;

      foreach (var item in list)
      {
        if (item.Output.Id == w.Id)
        {
          result = true;
          break;
        }
      }

      return result;     
    }
  }
}