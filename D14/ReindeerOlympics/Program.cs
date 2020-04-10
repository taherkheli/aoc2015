using System;
using System.Collections.Generic;
using System.Linq;

namespace ReindeerOlympics
{
  class Program
  {
    static void Main()
    {

      var path = "input.txt";
      var duration = 2503;
      var reindeers = Utils.Parse(path);
      
      var distances = new List<int>();

      foreach (var r in reindeers)
        distances.Add(r.DistanceTravelled(duration));

      Console.WriteLine("\nPartI: The winning reinder has covered :{0}", distances.Max());
    }
  }
}
