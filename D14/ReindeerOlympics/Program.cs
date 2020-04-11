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

      Console.WriteLine("\nPartI: The winning reinder has covered: {0} Km", distances.Max());


      foreach (var r in reindeers)
        r.Reset();
      
      for (int i = 0; i < duration; i++)
      {
        foreach (var r in reindeers)
          r.Increment();
        
        Utils.EvaluateAndScore(reindeers);
      }

      var list = reindeers.OrderByDescending(o => o.Points).ToList();
      var points = list[0].Points;

      Console.WriteLine("\nPartII: The winning reindeer has gathered: {0} points", points);
    }
  }
}
