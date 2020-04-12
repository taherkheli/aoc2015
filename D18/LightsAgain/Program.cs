using System;

namespace LightsAgain
{
  class Program
  {
    static void Main()
    {
      var path = "input.txt";
      var grid = new Grid(Utils.Parse(path));

      for (int i = 0; i < 100 ; i++)
        grid.Increment();

      int sum = 0;

      foreach (var light in grid.Lights)
        if (light.Status == Enum.Status.On)
          sum++;
 
      Console.WriteLine("\nPartI: The number of lights in ON state after 100 steps: {0}", sum);
    }
  }
}
