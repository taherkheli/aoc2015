using HousesOnGrid.Enum;
using System;
using System.Linq;

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
        grid.Move(dir);

      Console.WriteLine("\nPart I: Santa is alone. Houses receiving atleast 1 gift: {0}", grid.VisitedHouses.Count);

      PartII(dirs);
    }

    private static void PartII(Dir[] dirs)
    {
      var grid_Santa = new Grid(0, 0);
      var grid_Robo_Santa = new Grid(0, 0);

      for (int i = 0; i < dirs.Length; i++)
      {
        if (i % 2 == 0)
          grid_Santa.Move(dirs[i]);
        else
          grid_Robo_Santa.Move(dirs[i]);
      }
      
      var union = Utils.GetUnion(grid_Santa.VisitedHouses, grid_Robo_Santa.VisitedHouses);
      Console.WriteLine("\nPart II: Santa is with Robo-Santa. Houses receiving atleast 1 gift: {0}", union.Count());      
    }
  }
}
