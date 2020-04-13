using LightsAgain.Enum;
using System;

namespace LightsAgain
{
  class Program
  {
    static void Main()
    {
      int steps = 100;  
      var path = "input.txt";
      var cfg = Utils.Parse(path);
      var grid = new Grid(cfg);
      for (int i = 0; i < steps; i++)
        grid.GoToNextState();

      int sum = 0;
      foreach (var light in grid.CurrState)
        if (light.Status == Status.On)
          sum++;

      Console.WriteLine("\nPartI: The number of lights in ON state after 100 steps: {0}", sum);
      

      grid = new Grid(cfg, true);
      for (int i = 0; i < steps; i++)
        grid.GoToNextState();

      sum = 0;
      foreach (var light in grid.CurrState)
        if (light.Status == Status.On)
          sum++;

      Console.WriteLine("\nPartII: The number of lights in ON state after 100 steps: {0}", sum);
    }
  }
}
