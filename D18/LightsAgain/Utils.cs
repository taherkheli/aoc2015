using LightsAgain.Enum;
using System;
using System.IO;

namespace LightsAgain
{
  public static class Utils
  {
    public static int[] Parse(string path)
    {
      var file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);
      return Parse(lines);
    }

    public static int[] Parse(string[] lines)
    {
      var n = lines.Length;
      var lights = new int[n * n];  //assuming a perfect square 
      var charArrays = new char[n][];

      for (int i = 0; i < n; i++)
        charArrays[i] = lines[i].Trim().ToCharArray();

      for (int r = 0; r < n; r++)
        for (int c = 0; c < n; c++)
        {
          if (charArrays[r][c] == '#')
            lights[r * n + c] = 1;
          else
            lights[r * n + c] = 0;
        }

      return lights;
    }

    public static void Print(Grid grid)
    {
      int size = (int)Math.Sqrt(grid.CurrState.Length);

      for (int r = 0; r < size; r++)
      {
        for (int c = 0; c < size; c++)
        {
          var status = grid.CurrState[r * size + c].Status;

          if (status == Status.Off)
            Console.Write(".");
          else
            Console.Write("#");
        }
        Console.WriteLine("");
      }

      Console.WriteLine("");
    }
  }
}