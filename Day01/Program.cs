using System;
using System.IO;

namespace Day01
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      Console.WriteLine("\n Instructions took Santa to floor: {0}", GetFloor(LoadInput(path)));
    }

    private static int GetFloor(string input)    
    {
      int floor = 0;
      var directions = input.ToCharArray();

      foreach (var direction in directions)
      {
        if ((direction != '(') && (direction != ')'))
          throw new ArgumentException("Bad input. only ( or ) is valid!");
        
        if (direction == '(')
          floor += 1;
        else
          floor -= 1;
      }

      return floor;
    }

    private static string LoadInput(string path)
    {
      return new StreamReader(path).ReadToEnd();
    }
  }
}
