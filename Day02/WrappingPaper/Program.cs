using System;

namespace WrappingPaper
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      int sum_wrapper = 0;
      int sum_ribbon = 0;
      var boxes = Parser.Parse(path);

      foreach (var box in boxes)
      {
        sum_wrapper += box.GetWrapperPaperNeeded();
        sum_ribbon += box.GetRibbonNeeded();
      }

      Console.WriteLine("\nPart I: Total wrapping paper to order: {0} sq. ft.", sum_wrapper);
      Console.WriteLine("\nPart II: Total ribbon to order: {0} ft.", sum_ribbon);
    }
  }
}