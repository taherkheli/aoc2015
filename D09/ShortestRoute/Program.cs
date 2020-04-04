using System;
using System.Collections.Generic;

namespace ShortestRoute
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      var lines = Utils.Parse(path);
      var world = new World(lines);

      int shortest = int.MaxValue;
      int longest = int.MinValue;

      foreach (var city in world.Cities)
      {
        var d = city.ShortestAndLongestRouteDistance(world);

        if (d.Item1 < shortest)
          shortest = d.Item1;

        if (d.Item2 > longest)
          longest = d.Item2;
      }

      Console.WriteLine("\nPartI:  The distance of the shortest route is {0}", shortest);

      Console.WriteLine("\nPartII: The distance of the longest route is {0}", longest);
    }
  }
}
