using System;

namespace NiceStrings
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      var strings = Utils.Parse(path);
      int niceCount = 0;

      foreach (var s in strings)
      {
        if (Utils.HasDisallowedChars(s))
          continue;

        if (!Utils.HasThreeVowels(s))
          continue;

        if (!Utils.HasOneDouble(s))
          continue;

        niceCount++;
      }

      Console.WriteLine("\nPartI: Nice Strings: {0}", niceCount);

      niceCount = 0;      

      foreach (var s in strings)
      {
        if (!Utils.HasSeparatedDouble(s))
          continue;

        if (!Utils.HasTwoNonOverlappingPairs(s))
          continue;

        niceCount++;
      }

      Console.WriteLine("\nPartII: Nice Strings: {0}", niceCount);
    }
  }
}
