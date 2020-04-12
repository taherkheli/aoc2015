using Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EggnogStorage
{
  class Program
  {
    static void Main()
    {
      int target = 150;
      var path = "input.txt";
      var containers = Utils.Parse(path);
      var n = containers.ToArray();
      var allCombinations = new List<List<Container>>();

      for (int k = 1; k < n.Length + 1; k++)
      {
        foreach (IEnumerable<Container> i in Combination.GetCombinations(n, k))
          allCombinations.Add(i.ToList());
      }

      var finder = new Finder(target, allCombinations);
      finder.Find();

      Console.WriteLine("\nPartI: The possible number of valid container combos is: {0}", finder.ValidCombos.Count);
    }




  }
}