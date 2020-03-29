using System;

namespace Lights
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      var cmds = Utils.Parse(path);
      int size = 1000;
      var grid = new Grid(size, size);

      foreach (var cmd in cmds)
        grid.Execute(cmd);

      Console.WriteLine("\nPartI: Lit lights: {0}", grid.LitCount);      
    }
  }
}