using System;

namespace HousesOnGrid
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      var dirs = Parser.Parse(path);
      var grid = new Grid(0, 0);
      
      foreach (var dir in dirs)
        grid.MoveSantasBehind(dir);      

      Console.WriteLine("\nPart I: Houses receiving atleast 1 giftr: {0}", grid.VisitedHouses.Count);

    }
  }
}
