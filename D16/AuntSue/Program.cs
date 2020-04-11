using System;
using System.Collections.Generic;

namespace AuntSue
{
  class Program
  {
    static void Main()
    {
      var path = "input.txt";
      var aunts = Utils.Parse(path);

      var dataToMatchAgainst = new Dictionary<string, int>()
      {
        { "children", 3 },
        { "cats", 7 },
        { "samoyeds", 2 },
        { "pomeranians", 3 },
        { "akitas", 0 },
        { "vizslas", 0 },
        { "goldfish", 5 },
        { "trees", 3 },
        { "cars", 2 },
        { "perfumes", 1 }
      };

      var auntId = -1;

      foreach (var aunt in aunts)
        if (aunt.MatcheDescription(dataToMatchAgainst))
        {
          auntId = aunt.Id;
          break;
        }

      Console.WriteLine("\nPartI: The aunt Sue that fits the data is: {0}", auntId);     

    }
  }
}
