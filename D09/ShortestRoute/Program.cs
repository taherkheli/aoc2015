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

      var distances = new List<int>();

      foreach (var city in world.Cities)
        distances.Add(city.ShortestRouteDistance(world));
           
      Console.WriteLine("\nPartI: The distance of the shortest route is {0}", GetSmallest(distances));
    }

    private static int GetSmallest(List<int> list) 
    {
      int result = int.MaxValue;

      foreach (var item in list)
      {
        if (item < result)
          result = item;
      }

      return result;
    }
  }
}
