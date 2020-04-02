using System;

namespace StringParsing
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      var strings = Utils.Parse(path);
      int sumA = 0;
      int sumB = 0;

      foreach (var s in strings)
      {
        int x = Utils.GetCodeCharCount(s);
        sumA += x;
        int y = Utils.GetInMemoryCharCount(s);
        sumB += y;
      }

      Console.WriteLine("\nPartI: Difference in sums: {0}", sumA - sumB);
    }
  }
}